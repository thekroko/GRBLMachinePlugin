using CamBam.CAD;
using CamBam.Geom;
using CamBam.UI;
using CamBam.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;
using GRBLMachine.Utils;
using GRBLMachine.UI;
using CamBam.Library;
using CamBam.CAM;

namespace GRBLMachine
{

  public class ToolTraceEditmode : EditMode
  {
    // fresh, new positions from GRBL

    private double         _posiX;
    private double         _posiY;
    private double         _posiZ;

    // where to go until new _posi? come in

    private double         _trgtX;
    private double         _trgtY;
    private double         _trgtZ;

    // where are we now

    private double         _currX;
    private double         _currY;
    private double         _currZ;

    // increments for _curr? on next timer tick

    private double         _stepX;
    private double         _stepY;
    private double         _stepZ;

    // last tool position used to calculate delta? for matrix translation

    private double         _lastX;
    private double         _lastY;
    private double         _lastZ;

    // working cooordinate offsets

    private double         _WCO_x;
    private double         _WCO_y;
    private double         _WCO_z;

    // current feed from GRBL

    private double         _feed = 250;
    private double         _rpm  = 0;

    // current timer ticks in ms, cancels out timer latency
    private double         _tick = 30;
    double                 _lastTime;
    long                   _nDraws;
    double                 _calcTick;

    // tool data

    private double         _toolDiameter      = GRBLMachinePlugin.Props.DefaultToolDiameter;
    private double         _toolFluteLength   = GRBLMachinePlugin.Props.DefaultToolFluteLength;
    private double         _toolTotalLength   = GRBLMachinePlugin.Props.DefaultToolTotalLength;
    private double         _toolShankDiameter = GRBLMachinePlugin.Props.DefaultToolShankDiameter;
    private double         _toolVAngle        = GRBLMachinePlugin.Props.DefaultToolVAngle;
    private ToolProfiles   _toolProfile       = GRBLMachinePlugin.Props.DefaultToolProfile;

    private Tool           _tool;
    private ToolDefinition _toolDef           = null;

    // limit objects

    private Surface  _limitsOuter;
    private Surface  _limitsInner;
    private Polyline _limitsBottom;
    private Polyline _limitsTop;

    // the editmode that we replaced temporary

    private EditMode _orgEditMode = null;


    public ToolTraceEditmode(ICADView iv) : base(iv)
    {
      CreateTool  (CamBamUI.MainUI.ActiveView.ActiveTool());

      CreateLimits();

      ProductionExpander.ToolChanged    += ProductionExpander_ToolChanged;    

      GRBLMachinePlugin.Position        += GRBLMachinePlugin_Position;
      GRBLMachinePlugin.Speed           += GRBLMachinePlugin_Speed;
      GRBLMachinePlugin.PropertyChanged += GRBLMachinePlugin_PropertyChanged;
    }

    /// <summary>
    /// Initiate a tool drawing sequence
    /// </summary>
    public void Draw()
    {
      // the current time in ms
      double now      = (System.DateTime.Now - System.DateTime.MinValue).TotalMilliseconds;
      // avarage-out the ticker time
      _tick +=  (now -_lastTime);
      _tick /= 2;

      _lastTime = now;

      _nDraws++;

      // new current positions, compensate for tick-jitter
      _currX = (Math.Abs(_trgtX - _currX) > Math.Abs(_stepX)) ? _currX + (_stepX * _tick / _calcTick) : _trgtX;
      _currY = (Math.Abs(_trgtY - _currY) > Math.Abs(_stepY)) ? _currY + (_stepY * _tick / _calcTick) : _trgtY;
      _currZ = (Math.Abs(_trgtZ - _currZ) > Math.Abs(_stepZ)) ? _currZ + (_stepZ * _tick / _calcTick) : _trgtZ;

      // check for movement, if no movement, do a draw only once in 10 ticks to prevent burning precious CPU cycles ;)
      if (_stepX == 0 && _stepY == 0 && _stepZ == 0 && (_nDraws % 10 != 0))
        return;

      // do the draw
      DrawTool(_currX, _currY, _currZ);
    }

    /// <summary>
    /// Override for EditMode's OnPaint
    /// </summary>
    /// <param name="iv"></param>
    /// <param name="d3d"></param>
    public override void OnPaint(ICADView iv, Display3D d3d)
    {
      // paint the temporary replaced EditMode
      if (_orgEditMode != null)
        _orgEditMode.OnPaint(iv,d3d);

      // setup the drawing of the tool
      d3d.LineWidth = 2;

      if (GRBLMachinePlugin.Props.LaserModeEnable == EnabledDisabled.Enabled)
      {
        double transparency = GRBLMachinePlugin.Props.LaserTransparency;

        if (_rpm != 0)
          transparency = 100f - (((double)_rpm / (double)GRBLMachinePlugin.Props.MaximumSpindleSpeed) * 100);

        d3d.LineColor ( Color.FromArgb((int)(255f * ((100f - transparency                            ) / 100)),GRBLMachinePlugin.Props.LaserColor));
      }
      else
        d3d.LineColor ( Color.FromArgb((int)(255f * ((100f - GRBLMachinePlugin.Props.ToolTransparency) / 100)),GRBLMachinePlugin.Props.ToolColor));

      d3d.LineStyle = LineStyle.Solid;

      // paint the tool
      _tool.Paint(d3d);

      // paint the bounding box
      if (_limitsOuter != null && GRBLMachinePlugin.Props.DrawLimits == EnabledDisabled.Enabled)
      {
        d3d.LineColor(Color.FromArgb((int)(255f * ((100f - GRBLMachinePlugin.Props.LimitsTransparency) / 100)),GRBLMachinePlugin.Props.LimitsColor));

        _limitsTop   .Paint(d3d);
        _limitsBottom.Paint(d3d);
        _limitsOuter .Paint(d3d);
        _limitsInner .Paint(d3d);
      }
    }

#region base overrides 

    //
    // to 'miss' as least as possible functionality due to the 'replacement', call the replacement's methods
    //

    public override bool PaintSelection
    {
      get
      {
        return _orgEditMode != null ? _orgEditMode.PaintSelection 
                                    : base        .PaintSelection;
      }
    }

    public override bool CheckForLayer(bool prompt)
    {
      return _orgEditMode != null ? _orgEditMode.CheckForLayer(prompt) 
                                  : base        .CheckForLayer(prompt);
    }

    public override bool AllowRepeatCancel()
    {
      return _orgEditMode != null ? _orgEditMode.AllowRepeatCancel()
                                  : base        .AllowRepeatCancel();
    }

    public override bool OnKeyDown(object sender, KeyEventArgs e)
    {
      return _orgEditMode != null ? _orgEditMode.OnKeyDown(sender, e)
                                  : base        .OnKeyDown(sender, e);
    }

    public override bool OnKeyPress(object sender, KeyPressEventArgs e)
    {
      return _orgEditMode != null ? _orgEditMode.OnKeyPress(sender, e)
                                  : base        .OnKeyPress(sender, e);
    }

    public override bool OnKeyUp(object sender, KeyEventArgs e)
    {
      return _orgEditMode != null ? _orgEditMode.OnKeyUp(sender, e)
                                  : base        .OnKeyUp(sender, e);
    }

    public override bool OnMouseDown(object sender, MouseEventArgs e)
    {
      return _orgEditMode != null ? _orgEditMode.OnMouseDown(sender, e)
                                  : base        .OnMouseDown(sender, e);
    }

    public override bool OnMouseMove(object sender, MouseEventArgs e)
    {
      return _orgEditMode != null ? _orgEditMode.OnMouseMove(sender, e)
                                  : base        .OnMouseMove(sender, e);
    }

    public override bool OnMouseUp(object sender, MouseEventArgs e)
    {
      return _orgEditMode != null ? _orgEditMode.OnMouseUp(sender, e)
                                  : base        .OnMouseUp(sender, e);
    }

    public override bool OnMouseWheel(MouseEventArgs e)
    {
      return _orgEditMode != null ? _orgEditMode.OnMouseWheel(e)
                                  : base        .OnMouseWheel(e);
    }      
      
    public override bool Repeat()
    {
      return _orgEditMode != null ? _orgEditMode.Repeat()
                                  : base        .Repeat();
    }

    public override void ReturnCancel()
    {
      if (_orgEditMode != null)     _orgEditMode.ReturnCancel();
      else                          base        .ReturnCancel();
    }

    public override void ReturnOK()
    {
      if (_orgEditMode != null)     _orgEditMode.ReturnOK();
      else                          base        .ReturnOK();
    }

#endregion // base overrides
    
#region Privates

    /// <summary>
    /// Build a new tool-visual
    /// </summary>
    private void CreateTool(ToolDefinition tool)
    { 
      _toolDiameter      = GRBLMachinePlugin.Props.LaserModeEnable == EnabledDisabled.Enabled ? GRBLMachinePlugin.Props.DefaultLaserDiameter : GRBLMachinePlugin.Props.DefaultToolDiameter;
      _toolFluteLength   = GRBLMachinePlugin.Props.DefaultToolFluteLength;
      _toolTotalLength   = GRBLMachinePlugin.Props.DefaultToolTotalLength;
      _toolShankDiameter = GRBLMachinePlugin.Props.DefaultToolShankDiameter;
      _toolVAngle        = GRBLMachinePlugin.Props.DefaultToolVAngle;
      _toolProfile       = GRBLMachinePlugin.Props.DefaultToolProfile;

      if (tool != null)
      {
        if      (tool.Diameter      != 0)
          _toolDiameter      = tool.Diameter;

        if      (tool.FluteLength   != 0)
          _toolFluteLength   = tool.FluteLength;

        if      (tool.Length        != 0)
          _toolTotalLength   = tool.Length;

        if      (tool.ShankDiameter != 0)
          _toolShankDiameter = tool.ShankDiameter;

        if      (tool.VeeAngle      != 0)
          _toolVAngle        = tool.VeeAngle;

        if      (tool.ToolProfile   != ToolProfiles.Unspecified)
          _toolProfile       = tool.ToolProfile;
      }

      _toolDef = tool;

      if (GRBLMachinePlugin.Props.LaserModeEnable == EnabledDisabled.Enabled)
        _tool = new Laser(_toolDiameter);
      else
        switch (_toolProfile)
        {
          case ToolProfiles.BallNose: _tool = new BallNose(_toolDiameter,_toolFluteLength, _toolShankDiameter, _toolTotalLength); break;
          case ToolProfiles.BullNose: _tool = new EndMill (_toolDiameter,_toolFluteLength, _toolShankDiameter, _toolTotalLength); break;
          case ToolProfiles.Drill:    _tool = new Drill   (_toolDiameter,_toolFluteLength, _toolShankDiameter, _toolTotalLength); break;
          case ToolProfiles.EndMill:  _tool = new EndMill (_toolDiameter,_toolFluteLength, _toolShankDiameter, _toolTotalLength); break;
          case ToolProfiles.VCutter:  _tool = new V_Cutter(_toolDiameter,_toolVAngle,      _toolShankDiameter, _toolTotalLength); break;
          default:                    _tool = new EndMill (_toolDiameter,_toolFluteLength, _toolShankDiameter, _toolTotalLength); break;
        }

      _lastX = 0;
      _lastY = 0;
      _lastZ = 0;
    }

    private void CreateLimits()
    {
      // @TODO Get the coordinate- vs drawing units right :)

      _limitsBottom = new Polyline();

      _limitsBottom.Add(0,0,0);
      _limitsBottom.Add(                                          0,GRBLMachinePlugin.Props.Y.AxisMaximumTravel,0);
      _limitsBottom.Add(GRBLMachinePlugin.Props.X.AxisMaximumTravel,GRBLMachinePlugin.Props.Y.AxisMaximumTravel,0);
      _limitsBottom.Add(GRBLMachinePlugin.Props.X.AxisMaximumTravel,                                          0,0);
      _limitsBottom.Closed = true;

      _limitsOuter = _limitsBottom.Extrude(1f,GRBLMachinePlugin.Props.Z.AxisMaximumTravel,0);

      if (_limitsOuter != null)
      {
        _limitsTop = new Polyline(_limitsBottom);

        _limitsBottom.Transform.Translate(-_WCO_x,-_WCO_y,-_WCO_z);
        _limitsBottom.ApplyTransformation();

        _limitsTop   .Transform.Translate(-_WCO_x,-_WCO_y,-_WCO_z + GRBLMachinePlugin.Props.Z.AxisMaximumTravel);
        _limitsTop   .ApplyTransformation();
        _limitsOuter .Transform.Translate(-_WCO_x,-_WCO_y,-_WCO_z + GRBLMachinePlugin.Props.Z.AxisMaximumTravel);
        _limitsOuter .ApplyTransformation();

        _limitsInner = new Surface(_limitsOuter);
        _limitsInner .InvertFaces();
      }
    }

    /// <summary>
    /// Really draw the tool on the view
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    private void DrawTool(double x, double y, double z)
    {
      CamBamUI ui = CamBamUI.MainUI;

      // setup tool translation

      Matrix4x4F matrix4x4F = new Matrix4x4F();

      // move the identity matrix to our delta? positions

      matrix4x4F.Translate(x - _lastX, y - _lastY, z - _lastZ);

      _lastX = x;
      _lastY = y;
      _lastZ = z;

      // tell the tool
      _tool.ApplyTransformation(matrix4x4F);

      // hijack the current EditMode
      _orgEditMode                = _ActiveView.CurrentEditMode;
      _ActiveView.CurrentEditMode = this;

      // trigger OnPaint
      _ActiveView.RepaintEditMode();

      _ActiveView.CurrentEditMode = _orgEditMode;

      _orgEditMode = null;
    }

    /// <summary>
    /// Calculate the next target position and step-rates
    /// </summary>
    private void CalcNext()
    {
      double step     = (_feed / 60) / (1000 / (_calcTick = _tick));

      double deltaX   = Math.Abs(_posiX - _trgtX);
      double deltaY   = Math.Abs(_posiY - _trgtY);
      double deltaZ   = Math.Abs(_posiZ - _trgtZ);
      double deltaMax = Math.Max(Math.Max(deltaX,deltaY),deltaZ);

      _currX = _trgtX;
      _trgtX = _posiX;
      _stepX = (_trgtX - _currX) == 0 ? 0 : ((_trgtX - _currX) > 0 ? step : -step);

      _currY = _trgtY;
      _trgtY = _posiY;
      _stepY = (_trgtY - _currY) == 0 ? 0 : ((_trgtY - _currY) > 0 ? step : -step);

      _currZ = _trgtZ;
      _trgtZ = _posiZ;
      _stepZ = (_trgtZ - _currZ) == 0 ? 0 : ((_trgtZ - _currZ) > 0 ? step : -step);

      // scale the steps based upon the largest delta, from which GRBL is reporting the current feed.
      // this smoothens out jaggy/jerky diagonal moves
      if (deltaMax != 0)
      {
        _stepX *= (Math.Abs(deltaX) / deltaMax);
        _stepY *= (Math.Abs(deltaY) / deltaMax);
        _stepZ *= (Math.Abs(deltaZ) / deltaMax);
      }
    }

#endregion // Privates

#region Eventhandlers

  /// <summary>
  /// Listen to any property changes coming from either GRBL or the PropertyGrid
  /// </summary>
  /// <param name="name"></param>
  /// <param name="newvalue"></param>
  private void GRBLMachinePlugin_PropertyChanged(string name, object newvalue)
    {
      switch (name)
      {
        case "DefaultToolDiameter":      _toolDiameter      = GRBLMachinePlugin.Props.DefaultToolDiameter;      CreateTool  (_toolDef);   break;
        case "DefaultToolFluteLength":   _toolFluteLength   = GRBLMachinePlugin.Props.DefaultToolFluteLength;   CreateTool  (_toolDef);   break;
        case "DefaultToolTotalLength":   _toolTotalLength   = GRBLMachinePlugin.Props.DefaultToolTotalLength;   CreateTool  (_toolDef);   break;
        case "DefaultToolShankDiameter": _toolShankDiameter = GRBLMachinePlugin.Props.DefaultToolShankDiameter; CreateTool  (_toolDef);   break;
        case "DefaultToolVAngle":        _toolVAngle        = GRBLMachinePlugin.Props.DefaultToolVAngle;        CreateTool  (_toolDef);   break;
        case "DefaultToolProfile":       _toolProfile       = GRBLMachinePlugin.Props.DefaultToolProfile;       CreateTool  (_toolDef);   break;
        case "LaserModeEnable":                                                                                 CreateTool  (_toolDef);   break;

        case "AxisMaximumTravel":                                                                               CreateLimits();           break;
      }
    }

    private void GRBLMachinePlugin_Speed(double feed, int rpm)
    {
      if (feed != 0)
        _feed = feed.GetUnitsFromReportAndDrawing(GRBLMachinePlugin.Props.ReportInInches, CamBamUI.MainUI.ActiveView.CADFile.DrawingUnits);
      
      _rpm = rpm;
    }

    private void GRBLMachinePlugin_Position(PosType type, double x, double y, double z)
    {
      if      (type == PosType.MachineCoordinates || 
               type == PosType.WorkCoordinates    )
      {
        Units drawingUnits = CamBamUI.MainUI.ActiveView.CADFile.DrawingUnits;

        if (!double.IsNaN(x))
          _posiX = x.GetWorkOrMachinePosition(type, _WCO_x, PosType.WorkCoordinates, GRBLMachinePlugin.Props.ReportInInches, drawingUnits);

        if (!double.IsNaN(y))
          _posiY = y.GetWorkOrMachinePosition(type, _WCO_y, PosType.WorkCoordinates, GRBLMachinePlugin.Props.ReportInInches, drawingUnits);

        if (!double.IsNaN(z))
          _posiZ = z.GetWorkOrMachinePosition(type, _WCO_z, PosType.WorkCoordinates, GRBLMachinePlugin.Props.ReportInInches, drawingUnits);

        CalcNext();
      }
      else if (type == PosType.WCO)
      {
        bool needNewLimits = (_WCO_x != x) || (_WCO_y != y) || (_WCO_z != z);

        if (!double.IsNaN(x))
          _WCO_x = x;

        if (!double.IsNaN(y))
          _WCO_y = y;

        if (!double.IsNaN(z))
          _WCO_z = z;

        if (GRBLMachinePlugin.Props.DrawLimits == EnabledDisabled.Enabled && needNewLimits)
          CreateLimits();
      }
    }

    private void ProductionExpander_ToolChanged(CamBam.Library.ToolDefinition tooldef)
    {
      CreateTool(tooldef);
    }

#endregion // Eventhandlers

  }
}