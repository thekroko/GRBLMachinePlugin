using CamBam.Geom;


namespace CamBam.CAD.Solids.UI
{
  public partial class DrawDiscPanel : DrawSolidWithPositionPanel
  {
    public DrawDiscPanel()
    {
      InitializeComponent();
    }

    public override Solid DrawInstance
    {
      get
      {
        return new Disc(new Point3F((double)PositionX.Value,(double)PositionY.Value,(double)PositionZ.Value),(double)Diameter.Value / 2, (int)Steps.Value);
      }
    }

    public override Solid PlainInstance { get { return new Disc(); } }

    public override void SetControlsToDefault(Solid.SolidProps props)
    {
      base.SetControlsToDefault(props);

      Diameter.Value = (decimal)(props as Disc.DiscProps).Diameter;
    }
  }
}
