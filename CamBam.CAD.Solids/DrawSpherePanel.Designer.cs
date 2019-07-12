namespace CamBam.CAD.Solids.UI
{
  partial class DrawSpherePanel
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
      this.label4 = new System.Windows.Forms.Label();
      this.Diameter = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.DomesCombo = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.PositionZ)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Steps)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Diameter)).BeginInit();
      this.SuspendLayout();
      // 
      // PositionY
      // 
      this.PositionY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      // 
      // PositionX
      // 
      this.PositionX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 83);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(69, 17);
      this.label4.TabIndex = 13;
      this.label4.Text = "Diameter:";
      // 
      // Diameter
      // 
      this.Diameter.DecimalPlaces = 3;
      this.Diameter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      this.Diameter.Location = new System.Drawing.Point(81, 81);
      this.Diameter.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
      this.Diameter.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
      this.Diameter.Name = "Diameter";
      this.Diameter.Size = new System.Drawing.Size(75, 22);
      this.Diameter.TabIndex = 14;
      this.Diameter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(162, 83);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(56, 17);
      this.label5.TabIndex = 15;
      this.label5.Text = "Domes:";
      // 
      // DomesCombo
      // 
      this.DomesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.DomesCombo.FormattingEnabled = true;
      this.DomesCombo.Location = new System.Drawing.Point(223, 80);
      this.DomesCombo.Name = "DomesCombo";
      this.DomesCombo.Size = new System.Drawing.Size(90, 24);
      this.DomesCombo.TabIndex = 16;
      // 
      // DrawSpherePanel
      // 
      this.Controls.Add(this.DomesCombo);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.Diameter);
      this.Controls.Add(this.label4);
      this.Name = "DrawSpherePanel";
      this.Size = new System.Drawing.Size(429, 117);
      this.Controls.SetChildIndex(this.Steps, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.Diameter, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.DomesCombo, 0);
      ((System.ComponentModel.ISupportInitialize)(this.PositionZ)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Steps)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Diameter)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown Diameter;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox DomesCombo;
  }
}
