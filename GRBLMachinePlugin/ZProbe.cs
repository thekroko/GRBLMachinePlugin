using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GRBLMachine.UI {
  class ZProbe {
    /// <summary>
    /// Executes a ZProbe, stopping when the probe triggers. Will set Workspace Z to ZProbe Z
    /// </summary>
    public static void ExecuteZProbe() {
      ThreadedGCodeExecute(
        () => ConnectionExpander.WriteCOMPort("G43.1 Z0"), // Remove any existing tool offset
        () => ConnectionExpander.WriteCOMPort("G10 L2 P0 Z0"), // Reset WCS to absolute machine 0 (Z-Probe target Z is based on WCS origin)
        () => ConnectionExpander.WriteCOMPortFmt("G38.2 F200 Z{0}", GRBLMachinePlugin.Props.ZProbeToolDropTargetZ), // Perform Z-Probe
        () => ConnectionExpander.WriteCOMPort("G10 L20 P0 Z0"), // Set WCS Z to probe Z
        () => ConnectionExpander.WriteCOMPortFmt("G43.1 Z{0}", GRBLMachinePlugin.Props.ZProbeToolOffset), // Set tool offset again
        () => ConnectionExpander.WriteCOMPort('?')
      );
    }

    /// <summary>
    ///  Threaded execute of GCode which waits for the machine to become idle, and which
    ///  aborts on ALARM conditions.
    ///  Do not use for critical/low latency applications (uses fixed wait)
    /// </summary>
    private static void ThreadedGCodeExecute(params Action[] actions) {
      new Thread(() => {
        // Remove any existing tool offset
        foreach (Action gcode in actions) {
          while (!ConnectionExpander.IsCOMPortIdle || GRBLMachinePlugin.CurrentMachineState != GRBLMachinePlugin.MachineState.Idle)
            Thread.Sleep(100);
          if (GRBLMachinePlugin.CurrentMachineState == GRBLMachinePlugin.MachineState.Alarm)
            return; // abort
          gcode();
        }
      }) { IsBackground = true }.Start();
    }
  }
}
