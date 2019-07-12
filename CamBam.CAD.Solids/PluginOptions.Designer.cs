namespace CamBam.CAD.Solids.UI
{
  partial class PluginOptions
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.propertyInspector = new CamBam.UI.XPropertyGrid();
      this.SuspendLayout();
      // 
      // propertyInspector
      // 
      this.propertyInspector.BackColor = System.Drawing.SystemColors.Control;
      this.propertyInspector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.propertyInspector.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyInspector.Location = new System.Drawing.Point(0, 0);
      this.propertyInspector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.propertyInspector.Name = "propertyInspector";
      this.propertyInspector.SelectedObject = null;
      this.propertyInspector.SelectedObjects = null;
      this.propertyInspector.Size = new System.Drawing.Size(482, 347);
      this.propertyInspector.TabIndex = 5;
      // 
      // PluginOptions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(482, 347);
      this.Controls.Add(this.propertyInspector);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "PluginOptions";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "CamBam.CAD.Solids Plugin - Properties";
      this.ResumeLayout(false);

    }

    #endregion

    private CamBam.UI.XPropertyGrid propertyInspector;
  }
}