using System;
using System.Windows.Forms;
using CamBam.CAD.Solids.Plugin;
using System.ComponentModel;

namespace CamBam.CAD.Solids.UI
{
  public partial class DrawSolidPanel : UserControl
  {
    public DrawSolidPanel()
    {
      InitializeComponent();
    }      

    [Browsable(false)]
    public virtual Solid DrawInstance     { get { return new Solid(); } }
    [Browsable(false)]
    public virtual Solid PlainInstance    { get { return new Solid(); } }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (SolidsPlugin.Props.Solids != null)
        SetControlsToDefault(SolidsPlugin.Props.Solids[PlainInstance]);
    }

    public virtual void SetControlsToDefault(Solid.SolidProps props)
    {
    }
  }
}
