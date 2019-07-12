using CamBam.UI;
using System;
using System.Globalization;

namespace GRBLMachine.UI
{
  public partial class JoggingExpander : Expander
  {
    private const  string       V1JOG           = "$J=F4000 ";
    private        bool         _toolChangeBusy = false;
    private static CultureInfo  EN_US           = new CultureInfo("en-US");
    private        string       _jogLeadIn      = null;

    public JoggingExpander()
    {

      InitializeComponent();

      StepXY.Text                           = GRBLMachinePlugin.Props.JogStepXY.ToString();
      StepZ .Text                           = GRBLMachinePlugin.Props.JogStepZ .ToString();
      Inches.Checked                        = GRBLMachinePlugin.Props.JogStepUnit == InchMM.Inches;
      Millimeters.Checked                   = GRBLMachinePlugin.Props.JogStepUnit == InchMM.Millimeters;

      ConnectionExpander.Connected         += ConnectionExpander_Connected;
      ConnectionExpander.Disconnected      += ConnectionExpander_Disconnected;

      ProductionExpander.ToolChangeStarted += ProductionExpander_ToolChangeStarted;
      ProductionExpander.ToolChangeEnded   += ProductionExpander_ToolChangeEnded;

      GRBLMachinePlugin .PropertyChanged   += GRBLMachinePlugin_PropertyChanged;
      GRBLMachinePlugin .State             += GRBLMachinePlugin_State;
    }

    private void ProductionExpander_ToolChangeEnded()
    {
      _toolChangeBusy = false;

      if (ContentPanel.Enabled)
      {
        HomeButton  .Enabled = GRBLMachinePlugin.Props.HomingCycleEnable == EnabledDisabled.Enabled;
        OriginButton.Enabled = true;
        ResetXButton.Enabled = true;
        ResetYButton.Enabled = true;
        WCSButton   .Enabled = true;
      }
    }

    private void ProductionExpander_ToolChangeStarted()
    {
      _toolChangeBusy = true;

      if (ContentPanel.Enabled)
      {
        HomeButton  .Enabled = false;
        OriginButton.Enabled = false;
        ResetXButton.Enabled = false;
        ResetYButton.Enabled = false;
        WCSButton   .Enabled = false;
      }
    }

    private void GRBLMachinePlugin_State(GRBLMachinePlugin.MachineState state, int code)
    {
      if (state == GRBLMachinePlugin.MachineState.Idle || state == GRBLMachinePlugin.MachineState.Jog)
      {
        if (!ContentPanel.Enabled)
        {
          ContentPanel.Enabled = true;

          if (_toolChangeBusy)
          {
            HomeButton  .Enabled = false;
            OriginButton.Enabled = false;
            ResetXButton.Enabled = false;
            ResetYButton.Enabled = false;
            WCSButton   .Enabled = false;
          }
        }
      }
      else
      {
        if (ContentPanel.Enabled)
          ContentPanel.Enabled = false;
      }

      if (_jogLeadIn == null)
        _jogLeadIn = ConnectionExpander.GrblIsV1 ? V1JOG : string.Empty;
    }

    private void GRBLMachinePlugin_PropertyChanged(string name, object newvalue)
    {
      switch (name)
      {
        case "JogStepXY":         StepXY     .Text    = GRBLMachinePlugin.Props.JogStepXY.ToString();                         break;
        case "JogStepZ":          StepZ      .Text    = GRBLMachinePlugin.Props.JogStepZ .ToString();                         break;
        case "JogStepUnit":       Inches     .Checked = GRBLMachinePlugin.Props.JogStepUnit       == InchMM.Inches;
                                  Millimeters.Checked = GRBLMachinePlugin.Props.JogStepUnit       == InchMM.Millimeters;      break;
        case "HomingCycleEnable": HomeButton .Enabled = GRBLMachinePlugin.Props.HomingCycleEnable == EnabledDisabled.Enabled; break;
      }
    }

    private void ConnectionExpander_Disconnected()
    {
      ContentPanel.Enabled = false;
    }

    private void ConnectionExpander_Connected()
    {
      ContentPanel.Enabled = true;
    }

    private void X_Min_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 X-" + StepXY.Text);
    }

    private void X_Plus_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 X+" + StepXY.Text);
    }

    private void Y_Min_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 Y-" + StepXY.Text);
    }

    private void Y_Plus_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 Y+" + StepXY.Text);
    }

    private void Z_Min_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 Z-" + StepZ.Text);
    }

    private void Z_Plus_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (Inches.Checked ? "G20" : "G21") + " G91 Z+" + StepZ.Text);
    }

    private void ResetXButton_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort("G10 P0 L20 X0");
    }

    private void ResetYButton_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort("G10 P0 L20 Y0");
    }

    private void ResetZButton_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort("G10 P0 L20 Z0");
    }

    private void HomeButton_Click(object sender, EventArgs e)
    {
        ConnectionExpander.WriteCOMPort("$H");
    }

    private void OriginButton_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort("G91 G21 G0 Z" + GRBLMachinePlugin.Props.JogZPullup.ToString(EN_US));
      ConnectionExpander.WriteCOMPort("G90 G0 X0 Y0");
      ConnectionExpander.WriteCOMPort("G90 G0 Z0");
    }

    private void WCSButton_Click(object sender, EventArgs e)
    {
      ConnectionExpander.WriteCOMPort("G10 P0 L20 X0 Y0 Z0");
    }

    private void Inches_CheckedChanged(object sender, EventArgs e)
    {
      GRBLMachinePlugin.Props.JogStepUnit = Inches.Checked ? InchMM.Inches : InchMM.Millimeters;

      CamBamUI.MainUI.ObjectProperties.Refresh();
    }

    private void StepXY_TextChanged(object sender, EventArgs e)
    {
      try {
        GRBLMachinePlugin.Props.JogStepXY = double.Parse(StepXY.Text);

        CamBamUI.MainUI.ObjectProperties.Refresh();
      }
      catch (FormatException) { }
    }

    private void StepZ_TextChanged(object sender, EventArgs e)
    {
      try {
        GRBLMachinePlugin.Props.JogStepZ = double.Parse(StepZ.Text);

        CamBamUI.MainUI.ObjectProperties.Refresh();
      }
      catch (FormatException) { }
    }
  }
}
