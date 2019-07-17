using CamBam;
using CamBam.CAD;
using CamBam.Geom;
using CamBam.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace GRBLMachine.UI
{
  public partial class JoggingExpander : Expander {
    private const string V1JOG = "$J=F4000 ";
    private bool _toolChangeBusy = false;
    private static CultureInfo EN_US = new CultureInfo("en-US");
    private string _jogLeadIn = null;

    public JoggingExpander() {

      InitializeComponent();

      StepXY.Text = GRBLMachinePlugin.Props.JogStepXY.ToString();
      StepZ.Text = GRBLMachinePlugin.Props.JogStepZ.ToString();
      Inches.Checked = GRBLMachinePlugin.Props.JogStepUnit == InchMM.Inches;
      Millimeters.Checked = GRBLMachinePlugin.Props.JogStepUnit == InchMM.Millimeters;

      ConnectionExpander.Connected += ConnectionExpander_Connected;
      ConnectionExpander.Disconnected += ConnectionExpander_Disconnected;

      ProductionExpander.ToolChangeStarted += ProductionExpander_ToolChangeStarted;
      ProductionExpander.ToolChangeEnded += ProductionExpander_ToolChangeEnded;

      GRBLMachinePlugin.PropertyChanged += GRBLMachinePlugin_PropertyChanged;
      GRBLMachinePlugin.State += GRBLMachinePlugin_State;
    }

    private void ProductionExpander_ToolChangeEnded() {
      _toolChangeBusy = false;

      if (ContentPanel.Enabled) {
        HomeButton.Enabled = GRBLMachinePlugin.Props.HomingCycleEnable == EnabledDisabled.Enabled;
        OriginButton.Enabled = true;
        ResetXButton.Enabled = true;
        ResetYButton.Enabled = true;
        WCSButton.Enabled = true;
      }
    }

    private void ProductionExpander_ToolChangeStarted() {
      _toolChangeBusy = true;

      if (ContentPanel.Enabled) {
        HomeButton.Enabled = false;
        OriginButton.Enabled = false;
        ResetXButton.Enabled = false;
        ResetYButton.Enabled = false;
        WCSButton.Enabled = false;
      }
    }

    private void GRBLMachinePlugin_State(GRBLMachinePlugin.MachineState state, int code) {
      if (state == GRBLMachinePlugin.MachineState.Idle || state == GRBLMachinePlugin.MachineState.Jog) {
        if (!ContentPanel.Enabled) {
          ContentPanel.Enabled = true;

          if (_toolChangeBusy) {
            HomeButton.Enabled = false;
            OriginButton.Enabled = false;
            ResetXButton.Enabled = false;
            ResetYButton.Enabled = false;
            WCSButton.Enabled = false;
          }
        }
      } else {
        if (ContentPanel.Enabled)
          ContentPanel.Enabled = false;
      }

      if (_jogLeadIn == null)
        _jogLeadIn = ConnectionExpander.GrblIsV1 ? V1JOG : string.Empty;
    }

    private void GRBLMachinePlugin_PropertyChanged(string name, object newvalue) {
      switch (name) {
        case "JogStepXY": StepXY.Text = GRBLMachinePlugin.Props.JogStepXY.ToString(); break;
        case "JogStepZ": StepZ.Text = GRBLMachinePlugin.Props.JogStepZ.ToString(); break;
        case "JogStepUnit": Inches.Checked = GRBLMachinePlugin.Props.JogStepUnit == InchMM.Inches;
          Millimeters.Checked = GRBLMachinePlugin.Props.JogStepUnit == InchMM.Millimeters; break;
        case "HomingCycleEnable": HomeButton.Enabled = GRBLMachinePlugin.Props.HomingCycleEnable == EnabledDisabled.Enabled; break;
      }
    }

    private void ConnectionExpander_Disconnected() {
      ContentPanel.Enabled = false;
    }

    private void ConnectionExpander_Connected() {
      ContentPanel.Enabled = true;
    }

    private void X_Min_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 X-" + StepXY.Text);
    }

    private void X_Plus_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 X+" + StepXY.Text);
    }

    private void Y_Min_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 Y-" + StepXY.Text);
    }

    private void Y_Plus_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 Y+" + StepXY.Text);
    }

    private void Z_Min_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 Z-" + StepZ.Text);
    }

    private void Z_Plus_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 Z+" + StepZ.Text);
    }

    private void ResetXButton_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort("G10 P0 L20 X0");
    }

    private void ResetYButton_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort("G10 P0 L20 Y0");
    }

    private void ResetZButton_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort("G10 P0 L20 Z0");
    }

    private void HomeButton_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort("$H");
    }

    private void OriginButton_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort("G91 G21 G0 Z" + GRBLMachinePlugin.Props.JogZPullup.ToString(EN_US));
      ConnectionExpander.WriteCOMPort("G90 G0 X0 Y0");
      ConnectionExpander.WriteCOMPort("G90 G0 Z0");
    }

    private void OriginXYButton_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort("G91 G21 G0 Z" + GRBLMachinePlugin.Props.JogZPullup.ToString(EN_US));
      ConnectionExpander.WriteCOMPort("G90 G0 X0 Y0");
    }

    private void WCSButton_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort("G10 P0 L20 X0 Y0 Z0");
    }

    private void Inches_CheckedChanged(object sender, EventArgs e) {
      GRBLMachinePlugin.Props.JogStepUnit = Inches.Checked ? InchMM.Inches : InchMM.Millimeters;

      if (CamBamUI.MainUI != null)
        CamBamUI.MainUI.ObjectProperties.Refresh();
    }

    private void StepXY_TextChanged(object sender, EventArgs e) {
      try {
        GRBLMachinePlugin.Props.JogStepXY = double.Parse(StepXY.Text);

        CamBamUI.MainUI.ObjectProperties.Refresh();
      } catch (FormatException) { }
    }

    private void StepZ_TextChanged(object sender, EventArgs e) {
      try {
        GRBLMachinePlugin.Props.JogStepZ = double.Parse(StepZ.Text);

        CamBamUI.MainUI.ObjectProperties.Refresh();
      } catch (FormatException) { }
    }

    #region Mouse Jogging Button
    bool _mouseIsJogging = false;
    Point _mouseJogStart;
    Point _mouseJogDelta;
    System.Windows.Forms.Timer _jogTimer = new System.Windows.Forms.Timer() { Interval = 200 };

    private void MouseJog_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
      Console.WriteLine($"Jogger Mouse Down {e.Location}");
      _mouseJogStart = e.Location;
      MouseJog.Capture = true;
      _mouseIsJogging = true;
      _jogTimer.Tick += _jogTimer_Tick;
      _jogTimer.Start();
    }

    private void MouseJog_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
      Console.WriteLine($"Jogger Mouse Up {e.Location}");
      _mouseJogDelta = Point.Empty;
      _mouseIsJogging = false;
      _jogTimer.Stop();
      _jogTimer.Tick -= _jogTimer_Tick;
      ConnectionExpander.WriteCOMPort((char)0x85); // Jog cancel
    }

    private void MouseJog_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
      if (MouseJog.Capture) {
        _mouseJogDelta = new Point(e.Location.X - _mouseJogStart.X, e.Location.Y - _mouseJogStart.Y);
        Console.WriteLine($"Jogger Mouse Move {e.Location} (Delta: {_mouseJogDelta}");
      }
    }

    private void _jogTimer_Tick(object sender, EventArgs e) {
      if (!_mouseIsJogging || GRBLMachinePlugin.CurrentMachineState == GRBLMachinePlugin.MachineState.Alarm) {
        _jogTimer.Stop();
        return;
      }
      /*if (!ConnectionExpander.IsCOMPortIdle) {
        return; // Still moving
      }*/

      const float px2mm = 0.5f;
      const float maxMmPerMove = 10;
      const float nominalFeed = 1000;

      float relX = Math.Abs(_mouseJogDelta.X) * px2mm;
      float relY = Math.Abs(_mouseJogDelta.Y) * px2mm;
      float largestDelta = Math.Max(relX, relY);
      float speedPercent = 1.0f;
      
      if (largestDelta > maxMmPerMove) {
        // Make sure we never move more than 5mm per jog command
        relX *= maxMmPerMove / largestDelta;
        relY *= maxMmPerMove / largestDelta;
        speedPercent = largestDelta / maxMmPerMove;
      }
      float moveX = relX * Math.Sign(_mouseJogDelta.X);
      float moveY = relY * -Math.Sign(_mouseJogDelta.Y);
      float feed = speedPercent * nominalFeed;

      ConnectionExpander.WriteCOMPort((char)0x85); // Jog cancel for previous jog
      ConnectionExpander.WriteCOMPortFmt("$J=G91 G21 X{0:+#;-#;+0} Y{1:+#;-#;+0} F{2}", moveX, moveY, feed);
    }
    #endregion

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      EventHandler ev = null;
      switch (keyData) {
        case Keys.Up:
          ev = Y_Plus_Click;
          break;
        case Keys.Down:
          ev = Y_Min_Click;
          break;
        case Keys.Left:
          ev = X_Min_Click;
          break;
        case Keys.Right:
          ev = X_Plus_Click;
          break;
        case Keys.PageDown:
          ev = Z_Min_Click;
          break;
        case Keys.PageUp:
          ev = Z_Plus_Click;
          break;
      }
      if (ev != null && !StepXY.Focused && !StepZ.Focused) {
        Console.WriteLine($"Keyboard Jog: {keyData}");
        if (Y_Plus.Enabled && ConnectionExpander.IsCOMPortIdle) ev(this, EventArgs.Empty);
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void ZProbeButton_Click(object sender, EventArgs e) {
      OriginButton.Enabled = false; // Will run your router drill into the workpiece ...
      ThreadedGCodeExecute(
        () => ConnectionExpander.WriteCOMPort("G43.1 Z0"), // Remove any existing tool offset
        () => ConnectionExpander.WriteCOMPort("G10 L2 P0 Z0"), // Reset WCS to absolute machine 0 (Z-Probe target Z is based on WCS origin)
        () => ConnectionExpander.WriteCOMPortFmt("G38.2 F200 Z{0}", GRBLMachinePlugin.Props.ZProbeToolDropTargetZ), // Perform Z-Probe
        () => ConnectionExpander.WriteCOMPort("G10 L20 P0 Z0"), // Set WCS Z to probe Z
        () => ConnectionExpander.WriteCOMPortFmt("G43.1 Z{0}", GRBLMachinePlugin.Props.ZProbeToolOffset) // Set tool offset again
      );
    }

    /// <summary>
    ///  Threaded execute of GCode which waits for the machine to become idle, and which
    ///  aborts on ALARM conditions.
    ///  Do not use for critical/low latency applications (uses fixed wait)
    /// </summary>
    private void ThreadedGCodeExecute(params Action[] actions) {
      new Thread(() => {
        // Remove any existing tool offset
        foreach (Action gcode in actions) {
          while (!ConnectionExpander.IsCOMPortIdle)
            Thread.Sleep(100);
          if (GRBLMachinePlugin.CurrentMachineState == GRBLMachinePlugin.MachineState.Alarm)
            return; // abort
          gcode();
        }
      }) { IsBackground = true }.Start();
    }

    private void PosA_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort("G28");
    }

    private void PosB_Click(object sender, EventArgs e) {
      ConnectionExpander.WriteCOMPort("G30");
    }

    private void storeCurrentPositionToolStripMenuItem_Click(object sender, EventArgs e) {
      ToolStripItem item = (sender as ToolStripItem);
      if (item != null) {
        ContextMenuStrip owner = item.Owner as ContextMenuStrip;
        if (owner != null) {
          if (owner.SourceControl == PosA)
            ConnectionExpander.WriteCOMPort("G28.1");
          if (owner.SourceControl == PosB)
            ConnectionExpander.WriteCOMPort("G30.1");
        }
      }
    }

    private void Goto_Click(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(GotoText.Text)) {
        ConnectionExpander.WriteCOMPortFmt("$J=G53 {0}", GotoText.Text);
      }
    }

    private void GotoMouse_Click(object sender, EventArgs e) {
      MoveToLocationMode editMode = new MoveToLocationMode(CamBamUI.MainUI.ActiveView);
      editMode.DefaultValue = (object)null;
      editMode.Prompt = "Select Move Destination";
      editMode.OnReturnOK += (o,ea) => {
        Point3F moveDelta = editMode.MoveDestination - editMode.MoveSource;
        ThisApplication.AddLogMessage("MoveDelta = " + moveDelta);
        ConnectionExpander.WriteCOMPortFmt("$J=G91 G21 X{0:+#;-#;+0} Y{1:+#;-#;+0} F4000", moveDelta.X, moveDelta.Y);
      };
      CamBamUI.MainUI.ActiveView.SetEditMode((EditMode)editMode);
      CamBamUI.MainUI.ActiveView.RepaintEditMode();
    }

    private void SwitchTo1_Click(object sender, EventArgs e) {
      StepXY.Text = StepZ.Text = "1";
    }

    private void SwitchTo5_Click(object sender, EventArgs e) {
      StepXY.Text = StepZ.Text = "5";
    }

    private void SwitchTo10_Click(object sender, EventArgs e) {
      StepXY.Text = StepZ.Text = "10";
    }
  }
}
