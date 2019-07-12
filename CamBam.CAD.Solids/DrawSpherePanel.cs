using CamBam.Geom;

namespace CamBam.CAD.Solids.UI
{
  public partial class DrawSpherePanel : DrawSolidWithPositionPanel
  {
    public DrawSpherePanel()
    {
      InitializeComponent();

      DomesCombo.Items.Add(Sphere.Domes.Both);
      DomesCombo.Items.Add(Sphere.Domes.Top);
      DomesCombo.Items.Add(Sphere.Domes.Bottom);

      DomesCombo.SelectedItem = Sphere.Domes.Both;
    }

    public override Solid DrawInstance
    {
      get
      {
        return new Sphere(new Point3F((double)PositionX.Value,(double)PositionY.Value,(double)PositionZ.Value),(double)Diameter.Value / 2, (int)Steps.Value, (Sphere.Domes)DomesCombo.SelectedItem);
      }
    }

    public override Solid PlainInstance { get { return new Sphere(); } }

    public override void SetControlsToDefault(Solid.SolidProps props)
    {
      base.SetControlsToDefault(props);

      Diameter  .Value        = (decimal)(props as Sphere.SphereProps).Diameter;
      DomesCombo.SelectedItem =          (props as Sphere.SphereProps).Domes;
    }
  }
}
