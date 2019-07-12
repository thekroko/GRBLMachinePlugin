using System;
using System.Threading;

namespace GRBLMachine.Utils
{

/**
* Semaphore is a straightforward implementation of EWD's well-known
* synchronization primitive. It's counter can be initialized to any
* nonnegative value -- by default, it is zero.
*/

  public sealed class GRBLSemaphore
  {
#region Private Instance Data

    private int   enters;
    private int   exits;

    /** The standard EWD's semaphore value */
    private int	  counter;
    /** The number of threads currently executing a wait on this semaphore */
    private int	  waiting     = 0;
    /** A flag indicating the interrupted status of this semaphore */
    private bool  interrupted = false;
    /** A sync-object allowing to implement waiting and signalling via Monitor */
    object	      guard	      = new object();
#endregion

#region Public Constructor / Destructor

   /**
    * Initializing constructor.
    * @param value the initial semaphore count
    */
    public GRBLSemaphore   (int value)
    {
      counter = value >= 0 ? value : 0;
    }

   /**
    * destructor
    */
    ~GRBLSemaphore()
    {
      guard = null;
    }
#endregion

#region Private Methods
   /*
    * Hide the Monitor methods and replace them with more 
    * comprehensive names
    */

    private void synchronized()
    {
      Monitor.Enter(guard);
      enters++;
    }

    private bool wait_synchronized(int millis)
    {
      return Monitor.Wait(guard,(millis != 0 ? millis : Timeout.Infinite));
    }
    
    private void signal_synchronized()
    {
      Monitor.Pulse(guard);
    }

    private void end_synchronized()
    {
      Monitor.Exit(guard);
      exits++;
    }
    
   /**
    * Modified wait(millies), counts the number of threads waiting on
    * this semaphore.
    *
    * Note: no synchro needed, 'cause Wait has to be called from
    * withing critical section anyway needs to be owner of the
    * 'guard-lock'.
    *
    * @param millis the timeout value in milliseconds
    */
    private bool DoWait(int millis)
    {
      bool result = true;

      waiting++;

      try
      {          
        result = wait_synchronized(millis);
      }
      finally
      {
        waiting--;
      }					         

      return result;
    }

#endregion

#region Public Methods

    public int Count
    {
      get
      {
        return counter;
      }
    }

   /**
    * Increments internal counter, possibly awakening a thread
    * wait()ing in acquire().
    *
    * Note: implements EWD's V-operation (Verhoog)
    */
    public void Release()
    { 
      synchronized();

      try
      {
        // pick a single thread wich is waiting on this semaphore and wake it up
        if (waiting > 0)
          signal_synchronized();
      }
      finally 
      {
        counter++;
        end_synchronized();
      }
    }

   /**
    * Decrements internal counter, blocking if the counter is already
    * zero.
    *
    * Note: implements EWD's P-operation (Prolaag)
    *
    *@throws ThreadInterruptedException when <code>Acquire()</code> would
    * block and the interrupted flag has been set.
    */
    public void Acquire()
    {
      synchronized();

      try
      {
        // The while loop below looks like an attempt to do some busy-waiting to
        // acquire this semaphore. But is is not! There is a shear number of
        // reasons to do it the way it's done. Just the most important one:
        // - Implement the ability to interrupt the wait action.
        //   (see the Interrupt() function which notifies all waiting threads with
        //   the purpose to let them examine the 'interrupted' flag.
        while (counter == 0)
        {
          // if during the wait or outside the acquire, we were interrupted and
          // during this same wait there has been no Release(),
          // signal the caller with a 'stone' that the party is over.
          // In other words, it doesnt make sense to call Acquire() again
          // since no Release()'s will arrive anymore.
          if (interrupted)
            throw new ThreadInterruptedException("Semaphore was interrupted");
          else
            DoWait(0);
        }
      }
      finally 
      {
        counter--;
        end_synchronized();
      }
    }

   /**
    * The timed version of acquire.
    *
    * @param millis the time to wait for this semaphore. 0 has the same behaviour
    * like <code>Aquire()</code>
    *
    * @throws ThreadInterruptedException
    * @throws TimeoutException
    * @see PhSemaphore.Acquire
    */
    public void Acquire(int millis)
    {
      synchronized();

      try
      {
        if (millis < 0)
          millis = 0;

        while (counter == 0)
        {
          long start = DateTime.Now.Ticks;

          if (millis < 0)
            throw new TimeoutException("Semaphore timed out");

          if      ( interrupted )
            throw new ThreadInterruptedException("Semaphore was interrupted");

          else if (!DoWait(millis))
            throw new TimeoutException("Semaphore timed out");

          if (millis > 0)
          {
            long now = DateTime.Now.Ticks;

            millis -= (int)((now - start) / 10000); // Ticks is in 0.1uSec resolution, we need 1 mS

            if (millis == 0)
              millis--;
          }
        }
      }
      finally
      {
        counter--;
        end_synchronized();
      }
    }

   /**
    * Raise the interrupted flag, indicating this semaphore should not
    * block anymore when counted down to 0. But instead throw a
    * <code>Semaphore.SemInterruptedException</code>.
    *
    * After setting the inteerupted flag, notify all 'waiting' threads so the
    * flag can be examined.
    *
    */
    public void Interrupt()
    {
      synchronized();

      try
      {

        interrupted = true;

        for (int i = 0; i != waiting; i++)
          signal_synchronized();

      }
      finally
      {
        end_synchronized();
      }

    }

   /**
      * Reset the semaphore to an operational state after an interrupt has occurred
      *
      *@param value the new value to start counting on.
      */
    public void Reset(int value) 
    {
      synchronized();

      try
      {
        counter = 0;

        for (int i = 0; i != waiting; i++)
          signal_synchronized();

        interrupted = false;
        counter = value >= 0 ? value : 0;
      }
      finally
      {
        end_synchronized();
      } 
    }
    
#endregion    
  }
}
