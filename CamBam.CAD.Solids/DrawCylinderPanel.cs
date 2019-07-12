using CamBam.Geom;

namespace CamBam.CAD.Solids.UI
{
  public partial class DrawCylinderPanel : DrawSolidWithPositionPanel
  {
    public DrawCylinderPanel()
    {
      InitializeComponent();
    }

    public override Solid DrawInstance
    {
      get
      {
        return new Cylinder(new Point3F((double)PositionX.Value,(double)PositionY.Value,(double)PositionZ.Value),(double)Diameter.Value / 2,(double)Height.Value, (int)Steps.Value, (double)Taper.Value);
      }
    }

    public override Solid PlainInstance { get { return new Cylinder(); } }

    public override void SetControlsToDefault(Solid.SolidProps props)
    {
      base.SetControlsToDefault(props);

      Diameter.Value = (decimal)(props as Cylinder.CylinderProps).Diameter;
      Height  .Value = (decimal)(props as Cylinder.CylinderProps).Height;
      Taper   .Value = (decimal)(props as Cylinder.CylinderProps).Taper;
    }
  }
}
