namespace CamBam.CAD.Solids.UI
{
  partial class DrawSolidWithPositionPanel
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
      this.PositionZ = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      this.PositionY = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.PositionX = new System.Windows.Forms.NumericUpDown();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label4 = new System.Windows.Forms.Label();
      this.Steps = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.PositionZ)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionX)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Steps)).BeginInit();
      this.SuspendLayout();
      // 
      // PositionZ
      // 
      this.PositionZ.DecimalPlaces = 3;
      this.PositionZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      this.PositionZ.Location = new System.Drawing.Point(237, 25);
      this.PositionZ.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
      this.PositionZ.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
      this.PositionZ.Name = "PositionZ";
      this.PositionZ.Size = new System.Drawing.Size(68, 22);
      this.PositionZ.TabIndex = 11;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(210, 27);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(21, 17);
      this.label3.TabIndex = 10;
      this.label3.Text = "Z:";
      // 
      // PositionY
      // 
      this.PositionY.DecimalPlaces = 3;
      this.PositionY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      this.PositionY.Location = new System.Drawing.Point(136, 25);
      this.PositionY.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
      this.PositionY.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
      this.PositionY.Name = "PositionY";
      this.PositionY.Size = new System.Drawing.Size(68, 22);
      this.PositionY.TabIndex = 9;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(109, 27);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(21, 17);
      this.label2.TabIndex = 8;
      this.label2.Text = "Y:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(21, 17);
      this.label1.TabIndex = 6;
      this.label1.Text = "X:";
      // 
      // PositionX
      // 
      this.PositionX.DecimalPlaces = 3;
      this.PositionX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      this.PositionX.Location = new System.Drawing.Point(33, 25);
      this.PositionX.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
      this.PositionX.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
      this.PositionX.Name = "PositionX";
      this.PositionX.Size = new System.Drawing.Size(68, 22);
      this.PositionX.TabIndex = 7;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.PositionY);
      this.groupBox1.Controls.Add(this.PositionZ);
      this.groupBox1.Controls.Add(this.PositionX);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(318, 64);
      this.groupBox1.TabIndex = 12;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Position";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(325, 27);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(48, 17);
      this.label4.TabIndex = 13;
      this.label4.Text = "Steps:";
      // 
      // Steps
      // 
      this.Steps.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
      this.Steps.Location = new System.Drawing.Point(379, 25);
      this.Steps.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
      this.Steps.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
      this.Steps.Name = "Steps";
      this.Steps.Size = new System.Drawing.Size(48, 22);
      this.Steps.TabIndex = 14;
      this.Steps.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
      // 
      // DrawSolidWithPositionPanel
      // 
      this.Controls.Add(this.Steps);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.groupBox1);
      this.Name = "DrawSolidWithPositionPanel";
      this.Size = new System.Drawing.Size(429, 80);
      ((System.ComponentModel.ISupportInitialize)(this.PositionZ)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionX)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Steps)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    protected System.Windows.Forms.NumericUpDown PositionZ;
    private System.Windows.Forms.Label label3;
    protected System.Windows.Forms.NumericUpDown PositionY;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    protected System.Windows.Forms.NumericUpDown PositionX;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label4;
    protected System.Windows.Forms.NumericUpDown Steps;
  }
}
