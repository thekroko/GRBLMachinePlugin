using System;
using System.Windows.Forms;
using CamBam.UI;
using System.ComponentModel;
using CamBam.Extensions;

namespace GRBLMachine.UI
{
  public partial class GRBLMachinePage : UserControl
  {
    public GRBLMachinePage()
    {
      InitializeComponent();

      this.Dock = DockStyle.Fill;

      if (!DesignMode)
        Application.Idle += Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      try
      {
        CamBamUI   ui   = CamBam.UI.CamBamUI.MainUI;
        TabControl tabs = ui.SysTabs.Tabs();

        if (tabs.SelectedIndex == tabs.TabPages.IndexOf(GRBLMachinePlugin.Page) && ui.ObjectProperties.SelectedObject != GRBLMachinePlugin.Props)
          ui.ObjectProperties.SelectedObject = GRBLMachinePlugin.Props;
      }
      catch (Exception) { }
    }

    [Browsable(false)]
    public static bool IsSelected 
    {
      get
      {
        return CamBamUI.MainUI.SysTabs.Tabs().SelectedTab == GRBLMachinePlugin.Page;
      }
    }
  }
}
