using CamBam.Values;
using CamBam.Library;
using CamBam.Util;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;
using System;
using GRBLMachine.UI;
using CamBam.CAM;

namespace GRBLMachine
{
  public enum PosType
  {
    [Browsable(false)]
    Unknown,
    MachineCoordinates,
    WorkCoordinates,
    [Browsable(false)]
    WCO
  }

  public enum InchMM : int
  {
    [Browsable(false)]
    Unknown      = -1,
    Inches       =  1,
    Millimeters  =  0
  }

  public enum EnabledDisabled : int
  {
    Disabled = 0,
    Enabled  = 1
  }

  [TypeConverter(typeof(EnumWithAttributeTranslateTypeConverter))]
  public enum InvertMask : int
  {
    None = 0,
    X    = 1,
    Y    = 2,
    [Description("X + Y")]
    X_Y  = 3,
    Z    = 4,
    [Description("X + Z")]
    X_Z  = 5,
    [Description("Y + Z")]
    Y_Z  = 6,
    All  = 7
  }

  [TypeConverter(typeof(EnumWithAttributeTranslateTypeConverter))]
  public enum IgnoreProcessPassOn : int
  {
    [Description("Ignore")]
    Ignore  = 0,
    [Description("Process in GRBLMachine")]
    Process = 1,
    [Description("Pass On to GRBL")]
    PassOn  = 2
  }

  [CamBam.Values.HasAdvancedProperties]
  [TypeConverter(typeof(ExpandableObjectConverter))]
  public class AxisProps  : CBLibraryItem
  {
    private int index = 0;

    public AxisProps()
    {
    }

    public AxisProps(ICBLibraryItem parent = null, int index = 0)
    {
      this.Parent = parent;
      this.index  = index;
    }

    [Browsable(false)]
    [XmlIgnore]
    public new string Name          { get { return "GRBL AxisProps"; } }

    [DisplayName("Maximum Rate")]
    [DefaultValue(3000.0)]
    [Description("$110,$111,$112 (axis maximum rate, mm/min)")]
    [CBKeyValue]
    public double MaximumRate       { get; set; }

    [DisplayName("Acceleration")]
    [DefaultValue(100.0)]
    [Description("$120,$121,$122 (axis acceleration, mm/sec^2)")]
    [CBAdvancedValue]
    public double Acceleration      { get; set; }

    [DisplayName("Maximum Travel")]
    [DefaultValue(200.0)]
    [Description("$130,$131,$132 (axis maximum travel, millimeters)")]
    [CBAdvancedValue]
    public double AxisMaximumTravel { get; set; }

    [DisplayName("Resolution")]
    [DefaultValue(400.0)]
    [Description("$100,$101,S102 (axis travel resolution, step/mm)")]
    [CBAdvancedValue]
    public double Resolution        { get; set; }


    public override string ToString()
    {
      return "";
    }

    public override void PropertyChanged(string propertyname, object newvalue)
    {
      if (!GRBLMachinePlugin.Connected || (GRBLMachinePlugin.CurrentMachineState != GRBLMachinePlugin.MachineState.Idle && GRBLMachinePlugin.CurrentMachineState != GRBLMachinePlugin.MachineState.Jog))
      {
        MessageBox.Show("Machine not " + (GRBLMachinePlugin.Connected ? "idle" : "connected") + ",\r\n\r\n changes will not be send to the machine", "GRBL Machine",MessageBoxButtons.OK,MessageBoxIcon.Information);
      }
      else
      {
        PropertyInfo prop = GetType().GetProperty(propertyname);

        if (prop != null)
        {
          object[] attr = prop.GetCustomAttributes(typeof(DescriptionAttribute),true);

          if (attr.Length != 0 && (attr[0] as DescriptionAttribute).Description.StartsWith("$"))
          {
            string[] dollar = (attr[0] as DescriptionAttribute).Description.Split(',',' ');
            string   val    = newvalue.ToString();

            if      (newvalue.GetType().IsEnum)
              val = ((int)newvalue).ToString();
            else if (newvalue is Boolean)
              val = ((bool)newvalue) ? "1" : "0";

            ConnectionExpander.WriteCOMPort(dollar[index] + "=" + val);
          }
        }

        GRBLMachinePlugin.PropertyChange(propertyname,newvalue);

        base.PropertyChanged(propertyname, newvalue);
      }
    }
  }

  [CamBam.Values.HasAdvancedProperties]
  public class GRBLProps : CBLibraryItem
  {

    public GRBLProps()
    {
      X = new AxisProps(this, 0);
      Y = new AxisProps(this, 1);
      Z = new AxisProps(this, 2);

      X.AxisMaximumTravel      = 200;
      Y.AxisMaximumTravel      = 300;
      Z.AxisMaximumTravel      = 50;

      Baudrate                 = 115200;

      EnableVisualStyles       =(Environment.OSVersion.Platform != PlatformID.Unix && Environment.OSVersion.Version.Major > 5) ? EnabledDisabled.Enabled : EnabledDisabled.Disabled;

      JogStepXY                = 10;
      JogStepZ                 = 5;
      JogStepUnit              = InchMM.Millimeters;
      JogZPullup               = 1;

      ToolChangeProcess        = IgnoreProcessPassOn.Process;
      ToolChangeUnits          = InchMM.Millimeters;
      ToolChangeZ              = 20;
      ToolChangePlungeFeed     = 100;
      ToolChangePlungeDistance = 5;

      DisplayPosType           = PosType.MachineCoordinates;
      TrackMachine             = EnabledDisabled.Enabled;
      DrawLimits               = EnabledDisabled.Enabled;

      DefaultToolDiameter      = 2;
      DefaultToolFluteLength   = 10;
      DefaultToolTotalLength   = 31.5;
      DefaultToolShankDiameter = 3.175;
      DefaultToolVAngle        = 45;
      DefaultToolProfile       = ToolProfiles.EndMill;
      ToolColor                = Color.Silver;
      ToolColorARGB            = Color.Silver.ToArgb();
      ToolTransparency         = 0;

      DefaultLaserDiameter     = 0.15;
      LaserColor               = Color.DeepSkyBlue;
      LaserColorARGB           = Color.DeepSkyBlue.ToArgb();
      LaserTransparency        = 85;

      LimitsColor              = Color.DarkGreen;
      LimitsColorARGB          = Color.DarkGreen.ToArgb();
      LimitsTransparency       = 90;

      ReportInInches           = InchMM.Unknown;

      DisplayExpanded          = true;
      ProductionExpanded       = false;
      JoggingExpanded          = false;
      ConsoleExpanded          = false;
      ConnectionExpanded       = true;
      AboutExpanded            = false;

      base.Name                = "GRBL Machine";
    }


    [Browsable(false)]
    [XmlIgnore]
    public new string Name                   { get { return "GRBL Machine"; } }

    [Browsable(false)]
    [XmlIgnore]
    public bool AllowNameEdit                { get { return false; } }

[Category("Communication")]
    [DisplayName("COM Port")]
    [Description("The port your GRBL machine is connected to")]
    [CBKeyValue]
    public string COMPort                    { get; set; }

  [Category("Communication")]
    [DisplayName("Baudrate")]
    [Description("The baudrate at which your GRBL machine is communicating")]
    [CBAdvancedValue]
    public int Baudrate                      { get; set; }

  [Category("Communication")]
    [DisplayName("Auto Connect")]
    [Description("Connect to your GRBL machine at startup")]
    [CBKeyValue]
    public bool AutoConnect                  { get; set; }

[Category("(General)")]
    [DisplayName("Visual Styles")]
    [Description("Enable/disable Windows' Visual Styles")]
    [CBAdvancedValue]
    public EnabledDisabled EnableVisualStyles{ get; set; }


[Category("[Display]")]
    [DisplayName("Display Positions in")]
    [Description("Set which coordinate system to use")]
    [CBKeyValue]
    public PosType DisplayPosType            { get; set; }

  [Category("[Display]")]
    [DisplayName("Track Machine Tool in Drawing")]
    [Description("Track machine's tool position in the drawing view")]
    [CBKeyValue]
    public EnabledDisabled TrackMachine      { get; set; }

  [Category("[Display]")]
    [DisplayName("Draw Machine Bounds in Drawing")]
    [Description("Draw the machine's bounding box in the drawing view")]
    [CBKeyValue]
    public EnabledDisabled DrawLimits        { get; set; }

  [Category("[Display]")]
    [XmlIgnore] // hack to satisfy an XMLDeserializer bug: Does not want to deserialize 'Color', so use ARGB values instead
    [DisplayName("Bounding Box Color")]
    [Description("The color with which to paint the machine's bounding box")]
    [CBAdvancedValue]
    public Color LimitsColor                 { get; set; }

    [Browsable(false)]
    public int LimitsColorARGB               { get; set; }

  [Category("[Display]")]
    [DisplayName("Bounding Box Transparency")]
    [Description("The transparency percentage (0 = opaque, 100 = invisible)")]
    [CBAdvancedValue]
    public int   LimitsTransparency          { get; set; }

[Category("[Display-Laser]")]
    [XmlIgnore] // hack to satisfy an XMLDeserializer bug: Does not want to deserialize 'Color', so use ARGB values instead
    [DisplayName("Color")]
    [Description("The color of the laser beam")]
    [CBAdvancedValue]
    public Color LaserColor                  { get; set; }

    [Browsable(false)]
    public int LaserColorARGB                { get; set; }

  [Category("[Display-Laser]")]
    [DisplayName("Laser Off Transparency")]
    [Description("The transparency percentage of the laser beam when the laser is off (0 = opaque, 100 = invisible)")]
    [CBAdvancedValue]
    public int   LaserTransparency           { get; set; }

[Category("[Display-Laser]")]
    [DisplayName("Default Laser Beam Width")]
    [Description("Default width of the laser beam")]
    [CBAdvancedValue]
    public double DefaultLaserDiameter       { get; set; }



[Category("[Display-Tool]")]
    [DisplayName("Default Diameter")]
    [Description("Default diameter to use when no diameter has been specified, for V-Cutters: the effective diameter when plunged, for Laser: the width the laserbeam at stock surface")]
    [CBAdvancedValue]
    public double DefaultToolDiameter        { get; set; }

  [Category("[Display-Tool]")]
    [DisplayName("Default Flute Length")]
    [Description("Default tool flute length to use when no tool flute length has been specified")]
    [CBAdvancedValue]
    public double DefaultToolFluteLength     { get; set; }

  [Category("[Display-Tool]")]
    [DisplayName("Default Total Length")]
    [Description("Default tool total length to use when no tool total length has been specified")]
    [CBAdvancedValue]
    public double DefaultToolTotalLength     { get; set; }

  [Category("[Display-Tool]")]
    [DisplayName("Default V-Angle")]
    [Description("Default v-angle to use when no v-angle has been specified")]
    [CBAdvancedValue]
    public double DefaultToolVAngle          { get; set; }

  [Category("[Display-Tool]")]
    [DisplayName("Default Shank Diameter")]
    [Description("Default shank diameter to use when no shank diameter has been specified")]
    [CBAdvancedValue]
    public double DefaultToolShankDiameter   { get; set; }

  [Category("[Display-Tool]")]
    [DisplayName("Default Profile")]
    [Description("Default profile to use when no profile has been specified")]
    [CBAdvancedValue]
    public ToolProfiles DefaultToolProfile   { get; set; }

  [Category("[Display-Tool]")]
    [XmlIgnore] // hack to satisfy an XMLDeserializer bug: Does not want to deserialize 'Color', so use ARGB values instead
    [DisplayName("Color")]
    [Description("The color with whioch to paint the machine's tool")]
    [CBAdvancedValue]
    public Color ToolColor                   { get; set; }

    [Browsable(false)]
    public int ToolColorARGB                 { get; set; }

  [Category("[Display-Tool]")]
    [DisplayName("Transparency")]
    [Description("The transparency percentage (0 = opaque, 100 = invisible)")]
    [CBAdvancedValue]
    public int   ToolTransparency            { get; set; }


[Category("[Jogging]")]
    [DisplayName("Step Distance XY")]
    [Description("Step distance in X and Y Axis")]
    [CBKeyValue]
    public double JogStepXY                  { get; set; }

  [Category("[Jogging]")]
    [DisplayName("Step Distance Z")]
    [Description("Step distance in Z Axis")]
    [CBKeyValue]
    public double JogStepZ                   { get; set; }

  [Category("[Jogging]")]
    [DisplayName("Step Unit")]
    [Description("Step in Inches or Millimeters")]
    [CBKeyValue]
    public InchMM JogStepUnit                { get; set; }

  [Category("[Jogging]")]
    [DisplayName("Z-Axis pull up")]
    [Description("Distance in mm to move the Z-Axis when moving to 0,0,0")]
    [CBAdvancedValue]
    public double JogZPullup                 { get; set; }


[Category("[ToolChange]")]
    [DisplayName("GCODE M6 (Tool Change)")]
    [Description("What to do with tool change M6 codes")]
    [CBKeyValue]
    public IgnoreProcessPassOn ToolChangeProcess{ get; set; }
 
  [Category("[ToolChange]")]
    [DisplayName("Machine Position X")]
    [Description("Toolchange X-position in machine-coordinates")]
    [CBKeyValue]
    public double ToolChangeX                { get; set; }

  [Category("[ToolChange]")]
    [DisplayName("Machine Position Y")]
    [Description("Toolchange Y-position in machine-coordinates")]
    [CBKeyValue]
    public double ToolChangeY                { get; set; }

  [Category("[ToolChange]")]
    [DisplayName("Machine Position Z")]
    [Description("Toolchange Z-position in machine-coordinates")]
    [CBKeyValue]
    public double ToolChangeZ                { get; set; }

  [Category("[ToolChange]")]
    [DisplayName("Units")]
    [Description("Toolchange units")]
    [CBKeyValue]
    public InchMM ToolChangeUnits            { get; set; }

  [Category("[ToolChange]")]
    [DisplayName("Plunge distance")]
    [Description("Distance to plunge before reaching original Z position")]
    [CBAdvancedValue]
    public double ToolChangePlungeDistance   { get; set; }

  [Category("[ToolChange]")]
    [DisplayName("Plunge feed")]
    [Description("Feed used during plunging")]
    [CBAdvancedValue]
    public double ToolChangePlungeFeed       { get; set; }


[Category("Stepper")]
    [XmlIgnore]
    [DisplayName("Pulse Time")]
    [Description("$0 (Step pulse time, microseconds)")]
    [CBAdvancedValue]
    public int StepPulseTime                 { get; set; }

  [Category("Stepper")]
    [XmlIgnore]
    [DisplayName("Idle Delay")]
    [Description("$1 (Step idle delay, milliseconds)")]
    [CBAdvancedValue]
    public int StepIdleDelay                 { get; set; }

  [Category("Stepper")]
    [XmlIgnore]
    [DisplayName("Invert Pulse")]
    [Description("$2 (Step pulse invert, mask)")]
    [CBAdvancedValue]
    public InvertMask StepPulseInvert        { get; set; }

  [Category("Stepper")]
    [XmlIgnore]
    [DisplayName("Invert Direction")]
    [Description("$3 (Step direction invert, mask)")]
    [CBAdvancedValue]
    public InvertMask StepDirectionInvert    { get; set; }

  [Category("Stepper")]
    [XmlIgnore]
    [DisplayName("Invert Enable Pin")]
    [Description("$4 (Invert step enable pin, boolean)")]
    [CBAdvancedValue]
    public bool InvertStepEnablePin          { get; set; }


[Category("Limits")]
    [XmlIgnore]
    [DisplayName("Invert Limit Pins")]
    [Description("$5 (Invert limit pins, boolean)")]
    [CBAdvancedValue]
    public bool InvertLimitPins              { get; set; }

  [Category("Limits")]
    [XmlIgnore]
    [DisplayName("Invert Probe Pin")]
    [Description("$6 (Invert probe pin, boolean)")]
    [CBAdvancedValue]
    public bool InvertProbePin               { get; set; }

  [Category("Limits")]
    [XmlIgnore]
    [DisplayName("Soft")]
    [Description("$20 (Soft limits enable, boolean)")]
    [CBKeyValue]
    public EnabledDisabled SoftLimitsEnable  { get; set; }

  [Category("Limits")]
    [XmlIgnore]
    [DisplayName("Hard")]
    [Description("$21 (Hard limits enable, boolean)")]
    [CBKeyValue]
    public EnabledDisabled HardLimitsEnable  { get; set; }


[Category("Homing")]
    [XmlIgnore]
    [DisplayName("Cycle")]
    [Description("$22 (Homing cycle enable, boolean)")]
    [CBKeyValue]
    public EnabledDisabled HomingCycleEnable { get; set; }

  [Category("Homing")]
    [XmlIgnore]
    [DisplayName("Invert Direction")]
    [Description("$23 (Homing direction invert, mask)")]
    [CBAdvancedValue]
    public InvertMask HomingDirectionInvert  { get; set; }

  [Category("Homing")]
    [XmlIgnore]
    [DisplayName("Locate Feed Rate")]
    [Description("$24 (Homing locate feed rate, mm/min)")]
    [CBAdvancedValue]
    public double HomingLocateFeedRate       { get; set; }

  [Category("Homing")]
    [XmlIgnore]
    [DisplayName("Search Seek Rate")]
    [Description("$25 (Homing search seek rate, mm/min)")]
    [CBAdvancedValue]
    public double HomingSearchSeekRate       { get; set; }

  [Category("Homing")]
    [XmlIgnore]
    [DisplayName("Switch Debounce Delay")]
    [Description("$26 (Homing switch debounce delay, milliseconds)")]
    [CBAdvancedValue]
    public int  HomingSwitchDebounceDelay    { get; set; }

  [Category("Homing")]
    [XmlIgnore]
    [DisplayName("Switch Pull-off Distance")]
    [Description("$27 (Homing switch pull-off distance, millimeters)")]
    [CBAdvancedValue]
    public double HomingSwitchPullOffDistance{ get; set; }

    
[Category("Report")]
    [XmlIgnore]
    [DisplayName("Status Options")]
    [Description("$10 (Status report options, mask)")]
    [CBAdvancedValue]
    public int StatusReportOptions           { get; set; }

  [Category("Report")]
    [XmlIgnore]
    [DisplayName("Units in")]
    [Description("$13 (Report in inches, boolean)")]
    [CBKeyValue]
    public InchMM ReportInInches             { get; set; }


[Category("Misc")]
    [XmlIgnore]
    [DisplayName("Junction deviation")]
    [Description("$11 (Junction deviation, millimeters)")]
    [CBAdvancedValue]
    public double JunctionDeviation          { get; set; }

  [Category("Misc")]
    [XmlIgnore]
    [DisplayName("Arc tolerance")]
    [Description("$12 (Arc tolerance, millimeters)")]
    [CBAdvancedValue]
    public double ArcTolerance               { get; set; }


[Category("Spindle")]
    [XmlIgnore]
    [DisplayName("Maximum Speed")]
    [Description("$30 (Maximum spindle speed, RPM)")]
    [CBKeyValue]
    public int MaximumSpindleSpeed           { get; set; }

  [Category("Spindle")]
    [XmlIgnore]
    [DisplayName("Minimum Speed")]
    [Description("$31 (Minimum spindle speed, RPM)")]
    [CBKeyValue]
    public int MinimumSpindleSpeed           { get; set; }

  [Category("Spindle")]
    [XmlIgnore]
    [DisplayName("Laser-mode")]
    [Description("$32 (Laser-mode enable, boolean)")]
    [CBKeyValue]
    public EnabledDisabled LaserModeEnable   { get; set; }


[Category("Axes")]
    [XmlIgnore]
    [DefaultValue(typeof(AxisProps), "Default")]
    [DisplayName("X-Axis")]
    [Description("X-Axis properties")]
    [CBKeyValue]
    public AxisProps X                       { get; set; }

  [Category("Axes")]
    [XmlIgnore]
    [DisplayName("Y-Axis")]
    [Description("Y-Axis properties")]
    [CBKeyValue]
    public AxisProps Y                       { get; set; }

  [Category("Axes")]
    [XmlIgnore]
    [DisplayName("Z-Axis")]
    [Description("Z-Axis properties")]
    [CBKeyValue]
    public AxisProps Z                       { get; set; }


[Category("Startup")]
    [XmlIgnore]
    [DisplayName("Startup Block 1")]
    [Description("$N0 Startup Block 1")]
    [CBKeyValue]
    public string Startup1                   { get; set; }

  [Category("Startup")]
    [XmlIgnore]
    [DisplayName("Startup Block 2")]
    [Description("$N1 Startup Block 2")]
    [CBKeyValue]
    public string Startup2                   { get; set; }


    [Browsable(false)]
    public bool DisplayExpanded              { get; set; }

    [Browsable(false)]
    public bool ProductionExpanded           { get; set; }

    [Browsable(false)]
    public bool JoggingExpanded              { get; set; }

    [Browsable(false)]
    public bool ConsoleExpanded              { get; set; }

    [Browsable(false)]
    public bool ConnectionExpanded           { get; set; }

    [Browsable(false)]
    public bool AboutExpanded                { get; set; }

    [Browsable(false)]
    public int  SelectedTab                  { get; set; }

    public override void PropertyChanged(string propertyname, object newvalue)
    {
      PropertyInfo prop = GetType().GetProperty(propertyname);

      if (prop != null)
      {
        object[]     attr = prop.GetCustomAttributes(typeof(DescriptionAttribute),true);

        if (attr.Length != 0 && (attr[0] as DescriptionAttribute).Description.StartsWith("$"))
        {
          if (!GRBLMachinePlugin.Connected || (GRBLMachinePlugin.CurrentMachineState != GRBLMachinePlugin.MachineState.Idle && GRBLMachinePlugin.CurrentMachineState != GRBLMachinePlugin.MachineState.Jog))
          {
            MessageBox.Show("Machine not " + (GRBLMachinePlugin.Connected ? "idle" : "connected") + ",\r\n\r\n changes will not be send to the machine", "GRBL Machine",MessageBoxButtons.OK,MessageBoxIcon.Information);
          }
          else
          {
            string[] dollar = (attr[0] as DescriptionAttribute).Description.Split(' ');

            string   val    = newvalue.ToString();

            if      (newvalue.GetType().IsEnum)
              val = ((int)newvalue).ToString();
            else if (newvalue is Boolean)
              val = ((bool)newvalue) ? "1" : "0";

            ConnectionExpander.WriteCOMPort(dollar[0] + "=" + val);

            GRBLMachinePlugin.PropertyChange(propertyname,newvalue);

            base.PropertyChanged(propertyname, newvalue);
          }
        }
        else
        {
          GRBLMachinePlugin.PropertyChange(propertyname,newvalue);

          base.PropertyChanged(propertyname, newvalue);
        }
      }
    }
  }
}