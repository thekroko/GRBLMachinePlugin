using CamBam.UI;
using CamBam.Extensions;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using GRBLMachine.Utils;
using System.Media;
using System.Globalization;

namespace GRBLMachine.UI
{
  public partial class DisplayExpander : Expander
  {
    private double                         _WCO_x;
    private double                         _WCO_y;
    private double                         _WCO_z;

    private double                         _last_x;
    private double                         _last_y;
    private double                         _last_z;

    private GRBLMachinePlugin.MachineState _lastState;
    private int                            _lastCode;

    private PosType                        _lastPosType;

    private bool                           _connected;

    private ToolTraceEditmode              _tracer;

    public DisplayExpander()
    {
      InitializeComponent();

      ContentPanel      .Font           = LCDFont.Load(20.0f);

      FeedLabel         .Font           = LCDFont.Load(10.0f);
      RPMLabel          .Font           = LCDFont.Load(10.0f);
      StatusLabel       .Font           = LCDFont.Load(22.0f);

      GRBLMachinePlugin.Position        += GRBLMachinePlugin_Position;
      GRBLMachinePlugin.State           += GRBLMachinePlugin_State;
      GRBLMachinePlugin.Speed           += GRBLMachinePlugin_Speed;
      GRBLMachinePlugin.PropertyChanged += GRBLMachinePlugin_PropertyChanged;
      GRBLMachinePlugin.Responding      += GRBLMachinePlugin_Responding;


      ConnectionExpander.Connected      += ConnectionExpander_Connected;
      ConnectionExpander.Disconnected   += ConnectionExpander_Disconnected;

      if (!DesignMode)
      {
        if (CamBamUI.MainUI != null && CamBamUI.MainUI.SysTabs != null)
          CamBamUI.MainUI.SysTabs.Tabs().SelectedIndexChanged += DisplayExpander_SelectedIndexChanged;

        GRBLMachinePlugin_State(GRBLMachinePlugin.MachineState.Idle,0);
        SetCoordinates         (GRBLMachinePlugin.Props.DisplayPosType);
        SetFeedUnits           (GRBLMachinePlugin.Props.ReportInInches);

  #if DEBUG
        GRBLMachinePlugin_Position(PosType.WCO,               -10, -20, -30);
        GRBLMachinePlugin_Position(PosType.MachineCoordinates,  5,   6,   7);
  #endif
        if (CamBamUI.MainUI != null && CamBamUI.MainUI.ActiveView != null)
          _tracer = new ToolTraceEditmode(CamBamUI.MainUI.ActiveView);
      }
    }

#region Privates

    private string GetPositionString(PosType type, double pos, double offset)
    {
      double p = pos.GetWorkOrMachinePosition(type, offset, GRBLMachinePlugin.Props.DisplayPosType);

      return (p > 0 ? "+" : "") + p.ToString("0. 000");
    }

    private void SetCoordinates(PosType pos)
    {
      switch (pos)
      {
        case PosType.MachineCoordinates:
          WPos       .Checked        = false;
          WPos       .Enabled        = true;
          MPos       .Checked        = true;
          MPos       .Enabled        = false;
          Coordinates.Text           = "MPos";
          break;
        case PosType.WorkCoordinates:
          MPos       .Checked        = false;
          MPos       .Enabled        = true;
          WPos       .Checked        = true;
          WPos       .Enabled        = false;
          Coordinates.Text           = "WPos";
          break;
      }

      GRBLMachinePlugin_Position(_lastPosType, _last_x, _last_y, _last_z);
    }

    private void SetFeedUnits(InchMM unit)
    {
      switch (unit)
      {
        case InchMM.Millimeters: 
          FeedUnitInches     .Checked = false;
          FeedUnitInches     .Enabled = true;
          FeedUnitMillimeters.Checked = true;
          FeedUnitMillimeters.Enabled = false;
          FeedUnits          .Text    = "mm/min";
          break;
        case InchMM.Inches:
          FeedUnitMillimeters.Checked = false;
          FeedUnitMillimeters.Enabled = true;
          FeedUnitInches     .Checked = true;
          FeedUnitInches     .Enabled = false;
          FeedUnits          .Text    = "Inch/min";
          break;
        default:
          FeedUnitMillimeters.Checked = false;
          FeedUnitMillimeters.Enabled = true;
          FeedUnitInches     .Checked = false;
          FeedUnitInches     .Enabled = true;
          FeedUnits          .Text    = "???/min";
          break;
      }
    }

#endregion // Privates

#region Eventhandlers

    private void GRBLMachinePlugin_PropertyChanged(string name, object newvalue)
    {
      switch (name)
      {
        case "DisplayPosType":      SetCoordinates((PosType)newvalue);                      break;
        case "ReportInInches":      SetFeedUnits  ((InchMM) newvalue);                      break;
        case "TrackMachine":        CamBam.UI.CamBamUI.MainUI.ActiveView.RepaintEditMode(); break;
      }
    }

    private void GRBLMachinePlugin_Responding(GRBLMachinePlugin.Response response, int code)
    {
      switch (response)
      {
        case GRBLMachinePlugin.Response.alarm: 
          SystemSounds.Hand.Play();
          if (code > 0)
            AlarmTip.Show(ConnectionExpander.AlarmDict[code],this,0,     0,10000);
          break;
        case GRBLMachinePlugin.Response.error: 
          SystemSounds.Beep.Play();
          if (code > 0)
            ErrorTip.Show(ConnectionExpander.ErrorDict[code],this,0,Height,10000);
          break;
      }
    }

    private void ConnectionExpander_Connected()
    {
      _connected = true;

      X_AxisContextMenu   .Enabled   = true;
      Z_AxisContextMenu   .Enabled   = true;
      Y_AxisContextMenu   .Enabled   = true;
      FeedUnitsContextMenu.Enabled   = true;

      ContentPanel        .ForeColor = Color.Chartreuse;
    }

    private void ConnectionExpander_Disconnected()
    {
      _connected     = false;

      ContentPanel        .ForeColor = Color.Yellow;

      X_AxisContextMenu   .Enabled   = false;
      Z_AxisContextMenu   .Enabled   = false;
      Y_AxisContextMenu   .Enabled   = false;
      FeedUnitsContextMenu.Enabled   = false;

      X_Pos    .Text = Y_Pos.Text = Z_Pos.Text = "----. ---";
      FeedLabel.Text =                                "----";
      RPMLabel .Text =                               "-----";
    }

    private void GRBLMachinePlugin_Speed(double feed, int rpm)
    {
      FeedLabel.Text = feed.ToString();
      RPMLabel .Text = rpm .ToString();
    }

    private void GRBLMachinePlugin_State(GRBLMachinePlugin.MachineState state, int code)
    {
      if (_lastState != GRBLMachinePlugin.MachineState.Hold  && state == GRBLMachinePlugin.MachineState.Hold)
        System.Media.SystemSounds.Asterisk.Play();

      _lastState           = state;
      _lastCode            = code;

      StatusLabel.Text     = state.ToString().ToUpper();

      Hold  .Enabled       = state != GRBLMachinePlugin.MachineState.Hold;
      Resume.Enabled       = state == GRBLMachinePlugin.MachineState.Hold;
      Alarm .Enabled       = state == GRBLMachinePlugin.MachineState.Alarm;

      X_OriginZero.Enabled = Y_OriginZero.Enabled = Z_OriginZero.Enabled
                           = state == GRBLMachinePlugin.MachineState.Idle;

      if (state == GRBLMachinePlugin.MachineState.Idle || state == GRBLMachinePlugin.MachineState.Jog)
      {
        X_AxisContextMenu   .Enabled = true;
        Z_AxisContextMenu   .Enabled = true;
        Y_AxisContextMenu   .Enabled = true;
        FeedUnitsContextMenu.Enabled = true;
      }
      else
      {
        X_AxisContextMenu   .Enabled = false;
        Z_AxisContextMenu   .Enabled = false;
        Y_AxisContextMenu   .Enabled = false;
        FeedUnitsContextMenu.Enabled = false;
      }
    }

    private void GRBLMachinePlugin_Position(PosType type, double x, double y, double z)
    {
      if      (type == PosType.MachineCoordinates || 
               type == PosType.WorkCoordinates    )
      {
        _lastPosType = type;

        if (!double.IsNaN(x))
          X_Pos.Text = GetPositionString(type, _last_x = x, _WCO_x);

        if (!double.IsNaN(y))
          Y_Pos.Text = GetPositionString(type, _last_y = y, _WCO_y);

        if (!double.IsNaN(z))
          Z_Pos.Text = GetPositionString(type, _last_z = z, _WCO_z);
      }
      else if (type == PosType.WCO)
      {
        if (!double.IsNaN(x))
          _WCO_x = x;

        if (!double.IsNaN(y))
          _WCO_y = y;

        if (!double.IsNaN(z))
          _WCO_z = z;
      }
    }

    private void X_Axis_Click(object sender, EventArgs e)
    {
        X_AxisContextMenu.Show(Cursor.Position);
    }

    private void Y_Axis_Click(object sender, EventArgs e)
    {
        Y_AxisContextMenu.Show(Cursor.Position);

    }
    private void Z_Axis_Click(object sender, EventArgs e)
    {
        Z_AxisContextMenu.Show(Cursor.Position);
    }

    private void StatusLabel_Click(object sender, EventArgs e)
    {
        StateContextMenu.Show(Cursor.Position);
    }

    private void Hold_Click(object sender, EventArgs e)
    {
      if (_connected)
        ConnectionExpander.WriteCOMPort('!');
    }

    private void Resume_Click(object sender, EventArgs e)
    {
      if (_connected)
        ConnectionExpander.WriteCOMPort('~');
    }

    private void ResetXMenu_Click(object sender, EventArgs e)
    {
      if (_connected)
        ConnectionExpander.WriteCOMPort("G10 P0 L20 X0");
    }

    private void ResetYMenu_Click(object sender, EventArgs e)
    {
      if (_connected)
        ConnectionExpander.WriteCOMPort("G10 P0 L20 Y0");
    }

    private void ResetZMenu_Click(object sender, EventArgs e)
    {
      if (_connected)
        ConnectionExpander.WriteCOMPort("G10 P0 L20 Z0");
    }

    private void Alarm_Click(object sender, EventArgs e)
    {
      if (!_connected)
        return;

      ConnectionExpander.WriteCOMPort((char)0x18);
      Thread            .Sleep(250);
      ConnectionExpander.WriteCOMPort("$X");

      /**if (MessageBox.Show("GRBL has been reset,\r\nperforming a Homing Cycle and/or\r\nreset your WCS origin is highly recommended !\r\n\r\nMove to WCS origin (0.0.0) now ?","GRBLMachine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        ConnectionExpander.WriteCOMPort("G91 G21 G0 Z" + GRBLMachinePlugin.Props.JogZPullup.ToString(new CultureInfo("en-US")));
        ConnectionExpander.WriteCOMPort("G90 G0 X0 Y0");
        ConnectionExpander.WriteCOMPort("G90 G0 Z0");
      }*/
    }

    private void WPos_Click(object sender, EventArgs e)
    {
      if (!_connected)
        return;

      GRBLMachinePlugin.PropertyChange("DisplayPosType",GRBLMachinePlugin.Props.DisplayPosType = PosType.WorkCoordinates);
      CamBamUI.MainUI.ObjectProperties.Refresh();
    }

    private void MPos_Click(object sender, EventArgs e)
    {
      if (!_connected)
        return;

      GRBLMachinePlugin.PropertyChange("DisplayPosType",GRBLMachinePlugin.Props.DisplayPosType = PosType.MachineCoordinates);
      CamBamUI.MainUI.ObjectProperties.Refresh();
    }

    private void FeedUnitMillimeters_Click(object sender, EventArgs e)
    {
      if (!_connected)
        return;

      ConnectionExpander.WriteCOMPort("$13=0");
      GRBLMachinePlugin.PropertyChange("ReportInInches",GRBLMachinePlugin.Props.ReportInInches = InchMM.Millimeters);
      CamBamUI.MainUI.ObjectProperties.Refresh();
    }

    private void FeedUnitInches_Click(object sender, EventArgs e)
    {
      if (!_connected)
        return;

      ConnectionExpander.WriteCOMPort("$13=1");
      GRBLMachinePlugin.PropertyChange("ReportInInches",GRBLMachinePlugin.Props.ReportInInches = InchMM.Inches);
      CamBamUI.MainUI.ObjectProperties.Refresh();
    }

    private void FeedUnits_Click(object sender, EventArgs e)
    {
      FeedUnitsContextMenu.Show(Cursor.Position);
    }

    private void Coordinates_Click(object sender, EventArgs e)
    {
      CoordinateContextMenu.Show(Cursor.Position);
    }

    private void TrackTimer_Tick(object sender, EventArgs e)
    {
      if (_tracer != null && GRBLMachinePage.IsSelected && GRBLMachinePlugin.Props.TrackMachine == EnabledDisabled.Enabled)
        _tracer.Draw();
    }

    private void DisplayExpander_SelectedIndexChanged(object sender, EventArgs e)
    {
      CamBamUI.MainUI.ActiveView.RefreshView();
    }

    #endregion // Eventhandlers

    private void BlinkTimer_Tick(object sender, EventArgs e)
    {
      if (_lastState == GRBLMachinePlugin.MachineState.Alarm || _lastState == GRBLMachinePlugin.MachineState.Hold)
        StatusLabel.ForeColor = StatusLabel.ForeColor == Color.Black ? Color.Red : Color.Black;
      else if (StatusLabel.ForeColor != Color.Chartreuse)
        StatusLabel.ForeColor = Color.Chartreuse;
    }
  }
}
