namespace CamBam.CAD.Solids.UI
{
  partial class DrawRodPanel
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
      this.Height = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.Taper = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.PositionZ)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Steps)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Diameter)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Height)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Taper)).BeginInit();
      this.SuspendLayout();
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
      this.Diameter.Size = new System.Drawing.Size(70, 22);
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
      this.label5.Location = new System.Drawing.Point(165, 83);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(53, 17);
      this.label5.TabIndex = 15;
      this.label5.Text = "Height:";
      // 
      // Height
      // 
      this.Height.DecimalPlaces = 3;
      this.Height.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      this.Height.Location = new System.Drawing.Point(221, 81);
      this.Height.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
      this.Height.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
      this.Height.Name = "Height";
      this.Height.Size = new System.Drawing.Size(70, 22);
      this.Height.TabIndex = 16;
      this.Height.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(300, 83);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(50, 17);
      this.label6.TabIndex = 17;
      this.label6.Text = "Taper:";
      // 
      // Taper
      // 
      this.Taper.DecimalPlaces = 3;
      this.Taper.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      this.Taper.Location = new System.Drawing.Point(356, 81);
      this.Taper.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.Taper.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      this.Taper.Name = "Taper";
      this.Taper.Size = new System.Drawing.Size(70, 22);
      this.Taper.TabIndex = 18;
      // 
      // DrawRodPanel
      // 
      this.Controls.Add(this.Taper);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.Height);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.Diameter);
      this.Controls.Add(this.label4);
      this.Name = "DrawRodPanel";
      this.Size = new System.Drawing.Size(429, 117);
      this.Controls.SetChildIndex(this.Steps, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.Diameter, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.Height, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.Taper, 0);
      ((System.ComponentModel.ISupportInitialize)(this.PositionZ)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Steps)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Diameter)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Height)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Taper)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown Diameter;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.NumericUpDown Height;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown Taper;
  }
}
