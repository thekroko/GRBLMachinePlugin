namespace CamBam.CAD.Solids.UI
{
  public partial class DrawSolidWithPositionPanel : DrawSolidPanel
  {
    public DrawSolidWithPositionPanel()
    {
      InitializeComponent();
    }

    public override void SetControlsToDefault(Solid.SolidProps props)
    {
      base.SetControlsToDefault(props);

      PositionX.Value  = (decimal)props.DefaultPosition.X;
      PositionY.Value  = (decimal)props.DefaultPosition.Y;
      PositionZ.Value  = (decimal)props.DefaultPosition.Z;

      Steps    .Value  =          props.DefaultSteps;
    }
  }
}
