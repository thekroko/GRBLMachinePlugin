using CamBam.CAD.Solids.Plugin;
using CamBam.UI;
using System;
using System.Windows.Forms;

namespace CamBam.CAD.Solids.UI
{
  public partial class DrawSolidForm : Form
  {
    public DrawSolidForm()
    {
      InitializeComponent();

      foreach (Layer layer in CamBamUI.MainUI.ActiveView.CADFile.Layers)
        LayerCombo.Items.Add(layer);

      LayerCombo.SelectedItem = CamBamUI.MainUI.ActiveView.CADFile.ActiveLayer;

      AsSurface .Checked      = SolidsPlugin.Props.DrawAsSurface;
    }

    public DrawSolidForm(Solid solid) : this()
    {
      artist = solid.UI;

      Text              = string.Format(Text,              solid.DisplayName);
      ContentGroup.Text = string.Format(ContentGroup.Text, solid.DisplayName);

      this.ContentPanel.SuspendLayout();
      this.ContentGroup.SuspendLayout();
      this.SuspendLayout();

      ContentPanel.Controls.Add(artist);

      this.ContentPanel.ResumeLayout(false);
      this.ContentPanel.PerformLayout();
      this.ContentGroup.ResumeLayout(false);
      this.ContentGroup.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private DrawSolidPanel artist;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (SolidsPlugin.Props.Solids != null)
        artist.SetControlsToDefault(SolidsPlugin.Props.Solids[artist.PlainInstance]);
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
      CamBamUI.MainUI.ActiveView.CADFile.Add(AsSurface.Checked ? new Surface(artist.DrawInstance) : artist.DrawInstance, LayerCombo.SelectedItem as Layer);
      CamBamUI.MainUI.ActiveView.RefreshView();
      Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void Apply_Button_Click(object sender, EventArgs e)
    {
      CamBamUI.MainUI.ActiveView.CADFile.Add(AsSurface.Checked ? new Surface(artist.DrawInstance) : artist.DrawInstance, LayerCombo.SelectedItem as Layer);
      CamBamUI.MainUI.ActiveView.RefreshView();
    }
  }
}
