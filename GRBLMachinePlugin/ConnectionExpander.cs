using CamBam.UI;
using GRBLMachine.Properties;
using GRBLMachine.Utils;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Threading;
using System.Globalization;
using System.Drawing;

namespace GRBLMachine.UI
{
  public partial class ConnectionExpander : Expander
  {
    public static  readonly Dictionary<int,string> ErrorDict = new Dictionary<int, string>();
    public static  readonly Dictionary<int,string> AlarmDict = new Dictionary<int, string>();

    public static  string               GrblVersion          = "1.1";
    public static  bool                 GrblIsV1             = true;

    private const  int                  BUFMAX               = 100;
    private const  string               GUID_DEVCLASS_PORTS  = "{4d36e978-e325-11ce-bfc1-08002be10318}";

    private static SerialPort           _serialPort;
    private static ConnectionExpander   _this;
    private static Thread               _readThread;
    private static GRBLSemaphore        _writeSemaphore      = new GRBLSemaphore(BUFMAX);
    private static Queue<int>           _writeQueue          = new Queue<int>   (BUFMAX);
    private static char[]               _charBuf             = new char[1];
    private static bool                 _firstParse;
    private static CultureInfo          EN_US                = new CultureInfo("en-US");


    static ConnectionExpander()
    {
      ErrorDict.Add( 1, "G-code words consist of a letter and a value.\r\nLetter was not found. ");
      ErrorDict.Add( 2, "Numeric value format is not valid\r\nor missing an expected value. ");
      ErrorDict.Add( 3, "GRBL '$' system command was not recognized or supported. ");
      ErrorDict.Add( 4, "Negative value received for an expected positive value. ");
      ErrorDict.Add( 5, "Homing cycle is not enabled via settings. ");
      ErrorDict.Add( 6, "Minimum step pulse time must be greater than 3usec ");
      ErrorDict.Add( 7, "EEPROM read failed.\r\nReset and restored to default values. ");
      ErrorDict.Add( 8, "GRBL '$' command cannot be used unless GRBL is IDLE.\r\nEnsures smooth operation during a job. ");
      ErrorDict.Add( 9, "G-code locked out during alarm or jog state ");
      ErrorDict.Add(10, "Soft limits cannot be enabled without homing also enabled. ");
      ErrorDict.Add(11, "Max characters per line exceeded.\r\nLine was not processed and executed. ");
      ErrorDict.Add(12, "(Compile Option) GRBL '$' setting value exceeds\r\nthe maximum step rate supported. ");
      ErrorDict.Add(13, "Safety door detected as opened and door state initiated. ");
      ErrorDict.Add(14, "(GRBL-Mega Only) Build info or startup line\r\nexceeded EEPROM line length limit. ");
      ErrorDict.Add(15, "Jog target exceeds machine travel.\r\nCommand ignored. ");
      ErrorDict.Add(16, "Jog command with no '=' or contains prohibited g-code. ");
      ErrorDict.Add(20, "Unsupported or invalid g-code command found in block. ");
      ErrorDict.Add(21, "More than one g-code command from\r\nsame modal group found in block. ");
      ErrorDict.Add(22, "Feed rate has not yet been set or is undefined. ");
      ErrorDict.Add(23, "G-code command in block requires an integer value. ");
      ErrorDict.Add(24, "Two G-code commands that both require the use\r\nof the  XYZ  axis words were detected in the block. ");
      ErrorDict.Add(25, "A G-code word was repeated in the block. ");
      ErrorDict.Add(26, "A G-code command implicitly or explicitly requires\r\nXYZ axis words in the block, but none were detected. ");
      ErrorDict.Add(27, "N  line number value is not within the valid range of  1  -  9,999,999 . ");
      ErrorDict.Add(28, "A G-code command was sent, but is missing some\r\nrequired  P  or  L  value words in the line. ");
      ErrorDict.Add(29, "GRBL supports six work coordinate systems  G54-G59.\r\nG59.1 ,  G59.2 , and  G59.3  are not supported. ");
      ErrorDict.Add(30, "The  G53  G-code command requires either\r\na G0 seek or G1 feed motion mode to be active.\r\nA different motion was active. ");
      ErrorDict.Add(31, "There are unused axis words in the block\r\nand G80 motion mode cancel is active. ");
      ErrorDict.Add(32, "A  G2  or  G3  arc was commanded but there are no\r\nXYZ  axis words in the selected plane to trace the arc. ");
      ErrorDict.Add(33, "The motion command has an invalid target.\r\nG2 ,  G3 , and  G38.2  generates this error,\r\nif the arc is impossible to generate or\r\nif the probe target is the current position. ");
      ErrorDict.Add(34, "A  G2  or  G3  arc, traced with the radius definition,\r\nhad a mathematical error when computing the arc geometry.\r\nTry either breaking up the arc into semi-circles or quadrants,\r\nor redefine them with the arc offset definition. ");
      ErrorDict.Add(35, "A  G2  or  G3  arc, traced with the offset definition, is missing the  IJK  offset word in the selected plane to trace the arc. ");
      ErrorDict.Add(36, "There are unused, leftover G-code words that aren't\r\nused by any command in the block. ");
      ErrorDict.Add(37, "The  G43.1  dynamic tool length offset command cannot\r\napply an offset to an axis other than its configured axis.\r\nThe GRBL default axis is the Z-axis.");

      AlarmDict.Add( 1, "Hard limit triggered.\r\n\r\nMachine position is likely lost due\r\nto sudden and immediate halt.\r\n\r\nRe-homing is highly recommended. ");
      AlarmDict.Add( 2, "G-code motion target exceeds machine travel.\r\n\r\nMachine position safely retained.\r\n\r\nAlarm may be unlocked. ");
      AlarmDict.Add( 3, "Reset while in motion.\r\n\r\nGRBL cannot guarantee position.\r\nLost steps are likely.\r\n\r\nRe-homing is highly recommended. ");
      AlarmDict.Add( 4, "Probe fail.\r\n\r\nThe probe is not in the expected initial state before starting probe cycle,\r\nwhere G38.2 and G38.3 is not triggered and G38.4 and G38.5 is triggered. ");
      AlarmDict.Add( 5, "Probe fail.\r\n\r\nProbe did not contact the workpiece within the programmed travel for G38.2 and G38.4. ");
      AlarmDict.Add( 6, "Homing fail.\r\n\r\nReset during active homing cycle. ");
      AlarmDict.Add( 7, "Homing fail.\r\n\r\nSafety door was opened during active homing cycle. ");
      AlarmDict.Add( 8, "Homing fail.\r\n\r\nCycle failed to clear limit switch when pulling off.\r\n\r\nTry increasing pull-off setting or check wiring. ");
      AlarmDict.Add( 9, "Homing fail.\r\n\r\nCould not find limit switch within search distance.\r\nDefined as  1.5 * max_travel  on search and  5 * pulloff  on locate phases. ");
    }

    public ConnectionExpander()
    {
      _this                                = this;

      InitializeComponent();

      _serialPort                          = ThePort;

      COMPort.Items.Clear();
      COMPort.Items.AddRange(SerialPort.GetPortNames());
      COMPort.SelectedItem                 = GRBLMachinePlugin.Props.COMPort;

      Baudrate.SelectedItem                = GRBLMachinePlugin.Props.Baudrate.ToString();

      AutoConnect.Checked                  = GRBLMachinePlugin.Props.AutoConnect;

      WqlEventQuery          insertQuery   = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity'");
      ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);

      insertWatcher.EventArrived          += new EventArrivedEventHandler(DeviceInsertedEvent);
      insertWatcher.Start();

      WqlEventQuery          removeQuery   = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity'");
      
      ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);

      removeWatcher.EventArrived          += new EventArrivedEventHandler(DeviceRemovedEvent);
      removeWatcher.Start();

      Connected                           += ConnectionExpander_Connected;
      Disconnected                        += ConnectionExpander_Disconnected;

      GRBLMachinePlugin.PropertyChanged   += Props_PropertyChanged;

      AutoConnect.CheckedChanged          += AutoConnect_CheckedChanged;
    }

#region Publics

    /// <summary>
    /// True if all pending commands have been executed (i.e. no move & similar is pending)
    /// </summary>
    public static bool IsCOMPortIdle
    {
      get
      {
        return _writeQueue.Count == 0;
      }
    }

    /// <summary>
    /// True if nearly all pending commands have been executed (i.e. no move & similar is pending)
    /// </summary>
    public static bool IsCOMPortNearlyIdle {
      get {
        return _writeQueue.Count <= 1;
      }
    }

    public static bool WriteCOMPort(char data)
    {
      try
      {
        if (_serialPort.IsOpen)
        {
          _charBuf[0] = data;

          lock(_serialPort)
            _serialPort.Write(_charBuf,0,1);

          return true;
        }

        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public static bool WriteCOMPortFmt(string format, params object[] args) {
      return WriteCOMPort(string.Format(CultureInfo.InvariantCulture, format, args));
    }

    public static bool WriteCOMPort(string data)
    {
      if (!_this.InvokeRequired)
      {
        new Thread(new ParameterizedThreadStart(WriteCOMPortAsync)) { Name = "WriteCOMPortAsync", IsBackground = true }.Start(data);

        return true;
      }

      try
      {
        if (_serialPort.IsOpen)
        {
          if ((data.Length + 1) > BUFMAX)
          {
            GRBLMachinePlugin.Respond(GRBLMachinePlugin.Response.error,0);

            return false;
          }

          GRBLMachinePlugin.Log(">>> " + data);

          for (int i = 0; i != (data.Length + 1); i++)
            _writeSemaphore.Acquire();

          lock(_serialPort)
            _serialPort.Write(data + '\r');

          lock (_writeQueue)
            _writeQueue.Enqueue(data.Length + 1);

          return true;
        }
        else
        {
          ClearWriteQueue();
          GRBLMachinePlugin.Log(data);
          return false;
        }
      }
      catch (ThreadInterruptedException)
      {
        ClearWriteQueue();
        throw;
      }
      catch (Exception)
      {
        ClearWriteQueue();
        return false;
      }
    }

    public        delegate void ConnectDisconnectHandler();
    public static event         ConnectDisconnectHandler Connected;
    public static event         ConnectDisconnectHandler Disconnected;

#endregion // Publics

#region Overrides

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (GRBLMachinePlugin.Props.AutoConnect)
        OpenCOMPort();
      else
        Disconnect();
    }

#endregion // Publics

#region Privates

    private static bool OpenCOMPort(bool reportException = true)
    {
      if (string.IsNullOrEmpty(GRBLMachinePlugin.Props.COMPort))
        return false;

      try
      {
        if (_serialPort.IsOpen) { 
          _serialPort.Close();
          _serialPort.Dispose();

          _serialPort = new SerialPort();

          System.Threading.Thread.Sleep(100);
        }

        _serialPort.PortName     = GRBLMachinePlugin.Props.COMPort;
        _serialPort.DataBits     = 8;
        _serialPort.StopBits     = System.IO.Ports.StopBits.One;
        _serialPort.Parity       = System.IO.Ports.Parity.None;
        _serialPort.BaudRate     = GRBLMachinePlugin.Props.Baudrate;
        _serialPort.Handshake    = System.IO.Ports.Handshake.None;
        _serialPort.ReadTimeout  = -1;
        _serialPort.RtsEnable    = false;
        _serialPort.DtrEnable    = false;

        _serialPort.Open();

        GRBLMachinePlugin.Log("Opened: " + _serialPort.PortName);

        if (_readThread == null)
        {
          _readThread              = new System.Threading.Thread(ReadThread);
          _readThread.IsBackground = true;
          _readThread.Name         = "PortReader";
          _readThread.Start();
        }

        _serialPort.RtsEnable    = true;
        _serialPort.DtrEnable    = true;

        ClearWriteQueue();

        System.Threading.Thread.Sleep(10);

        Connect();

        return true;
      }
      catch (Exception e)
      {
        if (reportException)
          GRBLMachinePlugin.Log(e.ToString());

        Disconnect();
        return false;
      }
    }

    private static bool CloseCOMPort(bool immediate = false)
    {
      _this.StatusTimer.Enabled = false;

      try
      {
        _serialPort.DtrEnable = false;
        _serialPort.RtsEnable = false;

        _serialPort.Close();
        _serialPort.Dispose();

        GRBLMachinePlugin.Log("Closed: " + _serialPort.PortName);

        _serialPort = new SerialPort();

        if (!immediate)
          System.Threading.Thread.Sleep(2000);

        Disconnect();

        return true;
      }
      catch (Exception)
      {
        try
        {
          _serialPort.Close();
          _serialPort.Dispose();
        }
        catch (Exception) { }

        Disconnect();

        return false;
      }
    }

    private static void WriteCOMPortAsync(object data)
    {
      WriteCOMPort(data as string);
    }

    private static void Connect()
    {
      if (Connected != null)
        Connected();
    }

    private static void Disconnect()
    {
      if (Disconnected != null)
        Disconnected();
    }

    private static void ReadThread()
    {
      _firstParse = true;

      while (true)
      {
        try
        {
          string incoming = _serialPort.ReadLine().Trim(' ','\t','\r','\n');
          _this.InvokeOnUI(() => 
          {
            Parse(incoming);
          }); 
        }
        catch (System.IO.IOException)
        {
          _readThread = null;
          return;
        }
        catch (InvalidOperationException)
        {
          _readThread = null;
          return;
        }
        catch (Exception e)
        {
          GRBLMachinePlugin.Log(e.ToString());
        }
      } 
    } 

    private static void ClearWriteQueue()
    {
      lock (_writeQueue)
      {
        _writeQueue    .Clear();
        _writeSemaphore.Reset(BUFMAX);
      }
    }

    private static void Parse(string message)
    {
      XPropertyGrid grid = CamBamUI.MainUI.ObjectProperties;

      GRBLMachinePlugin.Log(message, message.StartsWith("<"));

      if (_firstParse && message.StartsWith("Grbl"))
      {
        string[] greetz = message.Split(' ');

        if (greetz.Length > 1)
        {
          GrblVersion = greetz[1];
          GrblIsV1    = GrblVersion.CompareTo("1.1a") >= 0;

          _this.VersionLabel.Text = GrblVersion;
          _this.VersionLabel.ForeColor = GrblIsV1 ? Color.LimeGreen : (GrblVersion.CompareTo("0.8") >= 0 ? Color.Orange : Color.Red);
        }

        _firstParse               = false;

        WriteCOMPort("$$");
        WriteCOMPort("$N");

        _this.StatusTimer.Enabled = true;
      }

      if (message.StartsWith("<") && message.EndsWith(">"))
      {
        if (!GrblIsV1)
        {
          //Version < 1.1 ==> "<Idle,MPos:0.000,0.000,0.000,WPos:0.000,0.000,0.000>"
          char[] charmessage = message.ToCharArray();

          charmessage[message.IndexOf(",MPos:")] = '|';
          charmessage[message.IndexOf(",WPos:")] = '|';

          message = new string(charmessage); // ==> "<Idle|MPos:0.000,0.000,0.000|WPos:0.000,0.000,0.000>"
        }

        string[] report = message.Split('<','|','>');


        if (report.Length > 2)
        {
          // report[0] = ""
          // report[1] = Idle
          string[] states = report[1].Split(':');

          GRBLMachinePlugin.Stat((GRBLMachinePlugin.MachineState)Enum.Parse(typeof(GRBLMachinePlugin.MachineState),states[0],true), states.Length > 1 ? int.Parse(states[1]) : -1);

          if (report.Length > 3) // report[2] = MPos:0.000,0.000,0.00
          {
            string[] pos = report[2].Split(':',',');

            PosType type = PosType.Unknown;
            double  x    = double.NaN;
            double  y    = double.NaN;
            double  z    = double.NaN;

            if (pos.Length > 0)
              switch (pos[0].ToUpper())
              {
                case "MPOS": type = PosType.MachineCoordinates; break;
                case "WPOS": type = PosType.WorkCoordinates; break;
              }
            if (pos.Length > 1)
              x = double.Parse(pos[1], EN_US);
            if (pos.Length > 2)
              y = double.Parse(pos[2], EN_US);
            if (pos.Length > 3)
              z = double.Parse(pos[3], EN_US);

            GRBLMachinePlugin.Pos(type,x,y,z);

            if (report.Length > 4) // report[3] = WPos:0.000,0.000,0.000
            {
              string[] speeds = report[3].Split(':',',');

              switch (speeds[0].ToUpper())
              {
                case "F":
                  GRBLMachinePlugin.Speeds(double.Parse(speeds[1], EN_US),0);
                  break;
                case "FS":
                  GRBLMachinePlugin.Speeds(double.Parse(speeds[1], EN_US),int.Parse(speeds[2], EN_US));
                  break;
                case "WPOS":
                  {
                    double  wx = double.NaN;
                    double  wy = double.NaN;
                    double  wz = double.NaN;

                    if (speeds.Length > 1)
                      wx = double.Parse(speeds[1], EN_US);
                    if (speeds.Length > 2)
                      wy = double.Parse(speeds[2], EN_US);
                    if (speeds.Length > 3)
                      wz = double.Parse(speeds[3], EN_US);

                    if (!double.IsNaN(wx) && !double.IsNaN(x))
                      wx = (x - wx);
                    if (!double.IsNaN(wy) && !double.IsNaN(y))
                      wy = (y - wy);
                    if (!double.IsNaN(wz) && !double.IsNaN(z))
                      wz = (z - wz);

                    GRBLMachinePlugin.Pos(PosType.WCO,wx,wy,wz);
                  }
                  break;
              }

              if (report.Length > 5)
              {
                pos = report[4].Split(':',',');

                switch (pos[0].ToUpper())
                {
                  case "WCO":
                    type = PosType.Unknown;
                    x    = double.NaN;
                    y    = double.NaN;
                    z    = double.NaN;

                    if (pos.Length > 0)
                      type = (PosType)Enum.Parse(typeof(PosType),pos[0],true);
                    if (pos.Length > 1)
                      x = double.Parse(pos[1], EN_US);
                    if (pos.Length > 2)
                      y = double.Parse(pos[2], EN_US);
                    if (pos.Length > 3)
                      z = double.Parse(pos[3], EN_US);

                    GRBLMachinePlugin.Pos(type,x,y,z);
                    break;
                  case "OV":
                    break;
                }
              }
            }
          }
        }
      }
      else if (message.Equals    ("ok",   StringComparison.OrdinalIgnoreCase))
      {
        lock (_writeQueue)
        {
          if (_writeQueue.Count == 0)
            _writeSemaphore.Reset(BUFMAX);
          else
          {
            int n = _writeQueue.Dequeue();

            for (int i = 0; i != n; i++)
              _writeSemaphore.Release();
          }
        }

        GRBLMachinePlugin.Respond(GRBLMachinePlugin.Response.ok);
      }
      else if (message.StartsWith("error",StringComparison.OrdinalIgnoreCase))
      {
        string[] error = message.Split(':');
        int      code  = (error.Length > 1 && GrblIsV1) ? int.Parse(error[1]) : 0;

        if (code > 0)
          GRBLMachinePlugin.Log(ErrorDict[code]);

        ClearWriteQueue();

        GRBLMachinePlugin.Respond(GRBLMachinePlugin.Response.error, code);
      }
      else if (message.StartsWith("alarm",StringComparison.OrdinalIgnoreCase))
      {
        string[] alarm = message.Split(':');
        int      code  = (alarm.Length > 1 && GrblIsV1) ? int.Parse(alarm[1]) : 0;

        if (code > 0)
          GRBLMachinePlugin.Log(AlarmDict[code]);

        ClearWriteQueue();

        GRBLMachinePlugin.Respond(GRBLMachinePlugin.Response    .alarm, code);
        GRBLMachinePlugin.Stat   (GRBLMachinePlugin.MachineState.Alarm, code);
      }
      else if (message.StartsWith("$N"))
      {
        string[] dollar = message.Split('=');

        switch (dollar[0])
        {
          case "$N0":  GRBLMachinePlugin.Props.Startup1                    =                  dollar[1];break; //Startup Block 0
          case "$N1":  GRBLMachinePlugin.Props.Startup2                    =                  dollar[1];break; //Startup Block 0
        }

        if (grid.SelectedObject == GRBLMachinePlugin.Props)
          grid.Refresh();
      }
      else if (message.StartsWith("$"))
      {
        string[] dollar = message.Split('=',';','(');
        double   val    = double.Parse(dollar[1], EN_US);

        switch (dollar[0])
        {
          case "$0":   GRBLMachinePlugin.Props.StepPulseTime               = (int)            val;      break; //(Step pulse time, microseconds)
          case "$1":   GRBLMachinePlugin.Props.StepIdleDelay               = (int)            val;      break; //(Step idle delay, milliseconds)
          case "$2":   GRBLMachinePlugin.Props.StepPulseInvert             = (InvertMask)     val;      break; //(Step pulse invert, mask)
          case "$3":   GRBLMachinePlugin.Props.StepDirectionInvert         = (InvertMask)     val;      break; //(Step direction invert, mask)
          case "$4":   GRBLMachinePlugin.Props.InvertStepEnablePin         =                  val != 0; break; //(Invert step enable pin, boolean)
          case "$5":   GRBLMachinePlugin.Props.InvertLimitPins             =                  val != 0; break; //(Invert limit pins, boolean)
          case "$6":   GRBLMachinePlugin.Props.InvertProbePin              =                  val != 0; break; //(Invert probe pin, boolean)
          case "$10":  GRBLMachinePlugin.Props.StatusReportOptions         = (int)            val;      break; //(Status report options, mask)
          case "$11":  GRBLMachinePlugin.Props.JunctionDeviation           =                  val;      break; //(Junction deviation, millimeters)
          case "$12":  GRBLMachinePlugin.Props.ArcTolerance                =                  val;      break; //(Arc tolerance, millimeters)
          case "$13":  GRBLMachinePlugin.Props.ReportInInches              = (InchMM)         val;      GRBLMachinePlugin.PropertyChange("ReportInInches",(InchMM)val);
                                                                                                        break; //(Report in inches, boolean)
          case "$20":  GRBLMachinePlugin.Props.SoftLimitsEnable            = (EnabledDisabled)val;      break; //(Soft limits enable, boolean)
          case "$21":  GRBLMachinePlugin.Props.HardLimitsEnable            = (EnabledDisabled)val;      break; //(Hard limits enable, boolean)
          case "$22":  GRBLMachinePlugin.Props.HomingCycleEnable           = (EnabledDisabled)val;      GRBLMachinePlugin.PropertyChange("HomingCycleEnable",(EnabledDisabled)val);
                                                                                                        break; //(Homing cycle enable, boolean)
          case "$23":  GRBLMachinePlugin.Props.HomingDirectionInvert       = (InvertMask)     val;      break; //(Homing direction invert, mask)
          case "$24":  GRBLMachinePlugin.Props.HomingLocateFeedRate        =                  val;      break; //(Homing locate feed rate, mm/min)
          case "$25":  GRBLMachinePlugin.Props.HomingSearchSeekRate        =                  val;      break; //(Homing search seek rate, mm/min)
          case "$26":  GRBLMachinePlugin.Props.HomingSwitchDebounceDelay   = (int            )val;      break; //(Homing switch debounce delay, milliseconds)
          case "$27":  GRBLMachinePlugin.Props.HomingSwitchPullOffDistance =                  val;      break; //(Homing switch pull-off distance, millimeters)
          case "$30":  GRBLMachinePlugin.Props.MaximumSpindleSpeed         = (int)            val;      break; //(Maximum spindle speed, RPM)
          case "$31":  GRBLMachinePlugin.Props.MinimumSpindleSpeed         = (int)            val;      break; //(Minimum spindle speed, RPM)
          case "$32":  GRBLMachinePlugin.Props.LaserModeEnable             = (EnabledDisabled)val;      GRBLMachinePlugin.PropertyChange("LaserModeEnable",(EnabledDisabled)val);
                                                                                                        break; //(Laser-mode enable, boolean)
          case "$100": GRBLMachinePlugin.Props.X.Resolution                =                  val;      break; //(X-axis travel resolution, step/mm)
          case "$101": GRBLMachinePlugin.Props.Y.Resolution                =                  val;      break; //(Y-axis travel resolution, step/mm)
          case "$102": GRBLMachinePlugin.Props.Z.Resolution                =                  val;      break; //(Z-axis travel resolution, step/mm)
          case "$110": GRBLMachinePlugin.Props.X.MaximumRate               =                  val;      break; //(X-axis maximum rate, mm/min)
          case "$111": GRBLMachinePlugin.Props.Y.MaximumRate               =                  val;      break; //(Y-axis maximum rate, mm/min)
          case "$112": GRBLMachinePlugin.Props.Z.MaximumRate               =                  val;      break; //(Z-axis maximum rate, mm/min)
          case "$120": GRBLMachinePlugin.Props.X.Acceleration              =                  val;      break; //(X-axis acceleration, mm/sec^2)
          case "$121": GRBLMachinePlugin.Props.Y.Acceleration              =                  val;      break; //(Y-axis acceleration, mm/sec^2)
          case "$122": GRBLMachinePlugin.Props.Z.Acceleration              =                  val;      break; //(Z-axis acceleration, mm/sec^2)
          case "$130": GRBLMachinePlugin.Props.X.AxisMaximumTravel         =                  val;      GRBLMachinePlugin.PropertyChange("AxisMaximumTravel",val);
                                                                                                        break; //(X-axis maximum travel, millimeters)
          case "$131": GRBLMachinePlugin.Props.Y.AxisMaximumTravel         =                  val;      GRBLMachinePlugin.PropertyChange("AxisMaximumTravel",val);
                                                                                                        break; //(Y-axis maximum travel, millimeters)
          case "$132": GRBLMachinePlugin.Props.Z.AxisMaximumTravel         =                  val;      GRBLMachinePlugin.PropertyChange("AxisMaximumTravel",val);
                                                                                                        break; //(Z-axis maximum travel, millimeters)
          default:
            break;
        }

        if (grid.SelectedObject == GRBLMachinePlugin.Props)
          grid.Refresh();
      }
    }
    
#endregion // Privates

#region Eventhandlers

    private void Props_PropertyChanged(string name, object newvalue)
    {
      switch (name)
      {
        case "COMPort":     COMPort.SelectedItem  = newvalue;             break;
        case "Baudrate":    Baudrate.SelectedItem = newvalue.ToString();  break;
        case "AutoConnect": AutoConnect.Checked   = (bool)newvalue;       break;
      }
    }

    private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
    {
      ManagementBaseObject instance  = (ManagementBaseObject)e.NewEvent["TargetInstance"];
      string               classGUID = instance["ClassGuid"] as string;
        

      if (GUID_DEVCLASS_PORTS.Equals(classGUID, StringComparison.OrdinalIgnoreCase))
      {
        InvokeOnUI(() => 
        {
          RefreshButton_Click(this, EventArgs.Empty);
        });
      }
    }

    private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
    {
      ManagementBaseObject instance  = (ManagementBaseObject)e.NewEvent["TargetInstance"];
      string               classGUID = instance["ClassGuid"] as string;
        

      if (GUID_DEVCLASS_PORTS.Equals(classGUID, StringComparison.OrdinalIgnoreCase))
      {
        string name = instance["Name"] as string;

        if (name.Contains(GRBLMachinePlugin.Props.COMPort))
          CloseCOMPort(true);

        InvokeOnUI(() => 
        {
          RefreshButton_Click(this, EventArgs.Empty);
        });
      }
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
      string oldPort = COMPort.SelectedItem as string;

      COMPort.Items.Clear();
      COMPort.Items.AddRange(SerialPort.GetPortNames());
      COMPort.SelectedItem = oldPort;

      if (COMPort.SelectedItem == null)
        CloseCOMPort(true);
    }

    private void COMPort_SelectionChangeCommitted(object sender, EventArgs e)
    {
      GRBLMachinePlugin.Props.COMPort = COMPort.SelectedItem as string;

      if (CamBamUI.MainUI != null && CamBamUI.MainUI.ObjectProperties.SelectedObject == GRBLMachinePlugin.Props)
        CamBamUI.MainUI.ObjectProperties.Refresh();
    }

    private void Baudrate_SelectionChangeCommitted(object sender, EventArgs e)
    {
      GRBLMachinePlugin.Props.Baudrate = int.Parse(Baudrate.SelectedItem as string);

      if (CamBamUI.MainUI != null && CamBamUI.MainUI.ObjectProperties.SelectedObject == GRBLMachinePlugin.Props)
        CamBamUI.MainUI.ObjectProperties.Refresh();
    }

    private void AutoConnect_CheckedChanged(object sender, EventArgs e)
    {
      GRBLMachinePlugin.Props.AutoConnect = AutoConnect.Checked;

      if (CamBamUI.MainUI != null && CamBamUI.MainUI.ObjectProperties.SelectedObject == GRBLMachinePlugin.Props)
        CamBamUI.MainUI.ObjectProperties.Refresh();
    }

    private void ConnectButton_Click(object sender, EventArgs e)
    {
      if (_serialPort.IsOpen)
        CloseCOMPort(true);
      else if (!string.IsNullOrEmpty(GRBLMachinePlugin.Props.COMPort) && GRBLMachinePlugin.Props.Baudrate != 0)
        OpenCOMPort(true);
    }

    private void StatusTimer_Tick(object sender, EventArgs e)
    {
      WriteCOMPort('?');
    }

    private void ConnectionExpander_Disconnected()
    {
      StatusTimer  .Enabled         = false;
      COMPort      .Enabled         = true;
      RefreshButton.Enabled         = true;
      Baudrate     .Enabled         = true;
      ConnectButton.Text            = "CONNECT !";
      ConnectButton.BackgroundImage = Resources.media_stop;
    }

    private void ConnectionExpander_Connected()
    {
      COMPort      .Enabled         = false;
      RefreshButton.Enabled         = false;
      Baudrate     .Enabled         = false;
      ConnectButton.Text            = "CLOSE !";
      ConnectButton.BackgroundImage = Resources.media_stop_red;
    }

    #endregion  // privates

  }
}
