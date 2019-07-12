﻿namespace CamBam.CAD.Solids.UI
{
  partial class DrawDiscPanel
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
      ((System.ComponentModel.ISupportInitialize)(this.PositionZ)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PositionX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Steps)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Diameter)).BeginInit();
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
      this.Diameter.Size = new System.Drawing.Size(65, 22);
      this.Diameter.TabIndex = 14;
      this.Diameter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // DrawDiscPanel
      // 
      this.Controls.Add(this.Diameter);
      this.Controls.Add(this.label4);
      this.Name = "DrawDiscPanel";
      this.Size = new System.Drawing.Size(429, 117);
      this.Controls.SetChildIndex(this.Steps, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.Diameter, 0);
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
  }
}
