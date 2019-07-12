using System;
using System.Windows.Forms;
using CamBam.UI;
using CamBam.CAD.Solids.Plugin;

namespace CamBam.CAD.Solids.UI
{
  public partial class PluginOptions : Form
  {
    public PluginOptions()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      propertyInspector.SelectedObject = SolidsPlugin.Props;

      XPropertyGridMetrics m           = propertyInspector.GetMetrics();
      m.ShowAdvanced                   = false;

      propertyInspector.ApplyMetrics(m);
    }
  }
}
