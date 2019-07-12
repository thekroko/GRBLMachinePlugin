using CamBam.Geom;

namespace CamBam.CAD.Solids.UI
{
  public partial class DrawRodPanel : DrawSolidWithPositionPanel
  {
    public DrawRodPanel()
    {
      InitializeComponent();
    }

    public override Solid DrawInstance
    {
      get
      {
        return new Rod(new Point3F((double)PositionX.Value,(double)PositionY.Value,(double)PositionZ.Value),(double)Diameter.Value / 2,(double)Height.Value, (int)Steps.Value, (double)Taper.Value);
      }
    }

    public override Solid PlainInstance { get { return new Rod(); } }

    public override void SetControlsToDefault(Solid.SolidProps props)
    {
      base.SetControlsToDefault(props);

      Diameter.Value = (decimal)(props as Rod.RodProps).Diameter;
      Height  .Value = (decimal)(props as Rod.RodProps).Height;
      Taper   .Value = (decimal)(props as Rod.RodProps).Taper;
    }
  }
}
