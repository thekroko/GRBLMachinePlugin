namespace GRBLMachine.UI
{
  partial class JoggingExpander : Expander
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoggingExpander));
      this.X_Plus = new GRBLMachine.UI.GRBLButton();
      this.X_Min = new GRBLMachine.UI.GRBLButton();
      this.Y_Plus = new GRBLMachine.UI.GRBLButton();
      this.Y_Min = new GRBLMachine.UI.GRBLButton();
      this.Z_Plus = new GRBLMachine.UI.GRBLButton();
      this.Z_Min = new GRBLMachine.UI.GRBLButton();
      this.StepXY = new System.Windows.Forms.TextBox();
      this.StepZ = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.Inches = new System.Windows.Forms.RadioButton();
      this.Millimeters = new System.Windows.Forms.RadioButton();
      this.ResetXButton = new GRBLMachine.UI.GRBLButton();
      this.ResetYButton = new GRBLMachine.UI.GRBLButton();
      this.ResetZButton = new GRBLMachine.UI.GRBLButton();
      this.HomeButton = new GRBLMachine.UI.GRBLButton();
      this.OriginButton = new GRBLMachine.UI.GRBLButton();
      this.WCSButton = new GRBLMachine.UI.GRBLButton();
      this.ContentPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // ContentPanel
      // 
      this.ContentPanel.Controls.Add(this.WCSButton);
      this.ContentPanel.Controls.Add(this.OriginButton);
      this.ContentPanel.Controls.Add(this.HomeButton);
      this.ContentPanel.Controls.Add(this.ResetZButton);
      this.ContentPanel.Controls.Add(this.ResetYButton);
      this.ContentPanel.Controls.Add(this.ResetXButton);
      this.ContentPanel.Controls.Add(this.Millimeters);
      this.ContentPanel.Controls.Add(this.Inches);
      this.ContentPanel.Controls.Add(this.label1);
      this.ContentPanel.Controls.Add(this.StepZ);
      this.ContentPanel.Controls.Add(this.StepXY);
      this.ContentPanel.Controls.Add(this.Z_Min);
      this.ContentPanel.Controls.Add(this.Z_Plus);
      this.ContentPanel.Controls.Add(this.Y_Min);
      this.ContentPanel.Controls.Add(this.Y_Plus);
      this.ContentPanel.Controls.Add(this.X_Min);
      this.ContentPanel.Controls.Add(this.X_Plus);
      this.ContentPanel.Enabled = false;
      this.ContentPanel.Size = new System.Drawing.Size(363, 164);
      // 
      // HeaderLabel
      // 
      this.HeaderLabel.Size = new System.Drawing.Size(374, 23);
      this.HeaderLabel.Text = "Jogging";
      // 
      // X_Plus
      // 
      this.X_Plus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.X_Plus.BackColor = System.Drawing.SystemColors.ControlDark;
      this.X_Plus.BackgroundImage = global::GRBLMachine.Properties.Resources.arrow_right_blue;
      this.X_Plus.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.arrow_right_gray;
      this.X_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.X_Plus.Font = new System.Drawing.Font("Arial Black", 7.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.X_Plus.ForeColor = System.Drawing.Color.Yellow;
      this.X_Plus.Location = new System.Drawing.Point(274, 61);
      this.X_Plus.Name = "X_Plus";
      this.X_Plus.Size = new System.Drawing.Size(36, 36);
      this.X_Plus.TabIndex = 0;
      this.X_Plus.Text = "X+";
      this.TheToolTip.SetToolTip(this.X_Plus, "Step in X+ direction");
      this.X_Plus.UseVisualStyleBackColor = false;
      this.X_Plus.Click += new System.EventHandler(this.X_Plus_Click);
      // 
      // X_Min
      // 
      this.X_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.X_Min.BackColor = System.Drawing.SystemColors.ControlDark;
      this.X_Min.BackgroundImage = global::GRBLMachine.Properties.Resources.arrow_left_blue;
      this.X_Min.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.arrow_left_gray;
      this.X_Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.X_Min.Font = new System.Drawing.Font("Arial Black", 7.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.X_Min.ForeColor = System.Drawing.Color.Yellow;
      this.X_Min.Location = new System.Drawing.Point(190, 61);
      this.X_Min.Name = "X_Min";
      this.X_Min.Size = new System.Drawing.Size(36, 36);
      this.X_Min.TabIndex = 1;
      this.X_Min.Text = "X-";
      this.TheToolTip.SetToolTip(this.X_Min, "Step in X- direction");
      this.X_Min.UseVisualStyleBackColor = false;
      this.X_Min.Click += new System.EventHandler(this.X_Min_Click);
      // 
      // Y_Plus
      // 
      this.Y_Plus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Y_Plus.BackColor = System.Drawing.SystemColors.ControlDark;
      this.Y_Plus.BackgroundImage = global::GRBLMachine.Properties.Resources.arrow_up_blue;
      this.Y_Plus.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.arrow_up_gray;
      this.Y_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.Y_Plus.Font = new System.Drawing.Font("Arial Black", 7.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Y_Plus.ForeColor = System.Drawing.Color.Yellow;
      this.Y_Plus.Location = new System.Drawing.Point(232, 40);
      this.Y_Plus.Name = "Y_Plus";
      this.Y_Plus.Size = new System.Drawing.Size(36, 36);
      this.Y_Plus.TabIndex = 2;
      this.Y_Plus.Text = "Y+";
      this.TheToolTip.SetToolTip(this.Y_Plus, "Step in Y+ direction");
      this.Y_Plus.UseVisualStyleBackColor = false;
      this.Y_Plus.Click += new System.EventHandler(this.Y_Plus_Click);
      // 
      // Y_Min
      // 
      this.Y_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Y_Min.BackColor = System.Drawing.SystemColors.ControlDark;
      this.Y_Min.BackgroundImage = global::GRBLMachine.Properties.Resources.arrow_down_blue;
      this.Y_Min.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.arrow_down_gray;
      this.Y_Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.Y_Min.Font = new System.Drawing.Font("Arial Black", 7.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Y_Min.ForeColor = System.Drawing.Color.Yellow;
      this.Y_Min.Location = new System.Drawing.Point(232, 81);
      this.Y_Min.Name = "Y_Min";
      this.Y_Min.Size = new System.Drawing.Size(36, 36);
      this.Y_Min.TabIndex = 3;
      this.Y_Min.Text = "Y-";
      this.TheToolTip.SetToolTip(this.Y_Min, "Step in Y- direction");
      this.Y_Min.UseVisualStyleBackColor = false;
      this.Y_Min.Click += new System.EventHandler(this.Y_Min_Click);
      // 
      // Z_Plus
      // 
      this.Z_Plus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Z_Plus.BackColor = System.Drawing.SystemColors.ControlDark;
      this.Z_Plus.BackgroundImage = global::GRBLMachine.Properties.Resources.arrow_up_blue;
      this.Z_Plus.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.arrow_up_gray;
      this.Z_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.Z_Plus.Font = new System.Drawing.Font("Arial Black", 7.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Z_Plus.ForeColor = System.Drawing.Color.Yellow;
      this.Z_Plus.Location = new System.Drawing.Point(316, 40);
      this.Z_Plus.Name = "Z_Plus";
      this.Z_Plus.Size = new System.Drawing.Size(36, 36);
      this.Z_Plus.TabIndex = 4;
      this.Z_Plus.Text = "Z+";
      this.TheToolTip.SetToolTip(this.Z_Plus, "Step in X+ direction");
      this.Z_Plus.UseVisualStyleBackColor = false;
      this.Z_Plus.Click += new System.EventHandler(this.Z_Plus_Click);
      // 
      // Z_Min
      // 
      this.Z_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Z_Min.BackColor = System.Drawing.SystemColors.ControlDark;
      this.Z_Min.BackgroundImage = global::GRBLMachine.Properties.Resources.arrow_down_blue;
      this.Z_Min.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.arrow_down_gray;
      this.Z_Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.Z_Min.Font = new System.Drawing.Font("Arial Black", 7.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Z_Min.ForeColor = System.Drawing.Color.Yellow;
      this.Z_Min.Location = new System.Drawing.Point(316, 81);
      this.Z_Min.Name = "Z_Min";
      this.Z_Min.Size = new System.Drawing.Size(36, 36);
      this.Z_Min.TabIndex = 5;
      this.Z_Min.Text = "Z-";
      this.TheToolTip.SetToolTip(this.Z_Min, "Step in Z- direction");
      this.Z_Min.UseVisualStyleBackColor = false;
      this.Z_Min.Click += new System.EventHandler(this.Z_Min_Click);
      // 
      // StepXY
      // 
      this.StepXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.StepXY.Location = new System.Drawing.Point(232, 12);
      this.StepXY.Name = "StepXY";
      this.StepXY.Size = new System.Drawing.Size(36, 22);
      this.StepXY.TabIndex = 6;
      this.StepXY.Text = "10";
      this.StepXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.TheToolTip.SetToolTip(this.StepXY, "Step value for X and Y directions");
      this.StepXY.TextChanged += new System.EventHandler(this.StepXY_TextChanged);
      // 
      // StepZ
      // 
      this.StepZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.StepZ.Location = new System.Drawing.Point(316, 12);
      this.StepZ.Name = "StepZ";
      this.StepZ.Size = new System.Drawing.Size(36, 22);
      this.StepZ.TabIndex = 7;
      this.StepZ.Text = "5";
      this.StepZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.TheToolTip.SetToolTip(this.StepZ, "Step value in Z directions");
      this.StepZ.TextChanged += new System.EventHandler(this.StepZ_TextChanged);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(187, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 17);
      this.label1.TabIndex = 8;
      this.label1.Text = "Step:";
      // 
      // Inches
      // 
      this.Inches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Inches.AutoSize = true;
      this.Inches.Location = new System.Drawing.Point(190, 123);
      this.Inches.Name = "Inches";
      this.Inches.Size = new System.Drawing.Size(55, 21);
      this.Inches.TabIndex = 9;
      this.Inches.Text = "inch";
      this.Inches.UseVisualStyleBackColor = true;
      this.Inches.CheckedChanged += new System.EventHandler(this.Inches_CheckedChanged);
      // 
      // Millimeters
      // 
      this.Millimeters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Millimeters.AutoSize = true;
      this.Millimeters.Checked = true;
      this.Millimeters.Location = new System.Drawing.Point(274, 123);
      this.Millimeters.Name = "Millimeters";
      this.Millimeters.Size = new System.Drawing.Size(51, 21);
      this.Millimeters.TabIndex = 10;
      this.Millimeters.TabStop = true;
      this.Millimeters.Text = "mm";
      this.Millimeters.UseVisualStyleBackColor = true;
      // 
      // ResetXButton
      // 
      this.ResetXButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ResetXButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ResetXButton.BackgroundImage")));
      this.ResetXButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.ResetXButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ResetXButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ResetXButton.ForeColor = System.Drawing.Color.Yellow;
      this.ResetXButton.Location = new System.Drawing.Point(12, 19);
      this.ResetXButton.Name = "ResetXButton";
      this.ResetXButton.Size = new System.Drawing.Size(61, 36);
      this.ResetXButton.TabIndex = 11;
      this.ResetXButton.Text = "X=0";
      this.TheToolTip.SetToolTip(this.ResetXButton, "Reset X-Axis WCS origin to zero");
      this.ResetXButton.UseVisualStyleBackColor = false;
      this.ResetXButton.Click += new System.EventHandler(this.ResetXButton_Click);
      // 
      // ResetYButton
      // 
      this.ResetYButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ResetYButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ResetYButton.BackgroundImage")));
      this.ResetYButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.ResetYButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ResetYButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ResetYButton.ForeColor = System.Drawing.Color.Yellow;
      this.ResetYButton.Location = new System.Drawing.Point(12, 61);
      this.ResetYButton.Name = "ResetYButton";
      this.ResetYButton.Size = new System.Drawing.Size(61, 36);
      this.ResetYButton.TabIndex = 12;
      this.ResetYButton.Text = "Y=0";
      this.TheToolTip.SetToolTip(this.ResetYButton, "Reset Y-Axis WCS origin to zero");
      this.ResetYButton.UseVisualStyleBackColor = false;
      this.ResetYButton.Click += new System.EventHandler(this.ResetYButton_Click);
      // 
      // ResetZButton
      // 
      this.ResetZButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ResetZButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ResetZButton.BackgroundImage")));
      this.ResetZButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.ResetZButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ResetZButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ResetZButton.ForeColor = System.Drawing.Color.Yellow;
      this.ResetZButton.Location = new System.Drawing.Point(12, 103);
      this.ResetZButton.Name = "ResetZButton";
      this.ResetZButton.Size = new System.Drawing.Size(61, 36);
      this.ResetZButton.TabIndex = 13;
      this.ResetZButton.Text = "Z=0";
      this.TheToolTip.SetToolTip(this.ResetZButton, "Reset Z-Axis WCS origin to zero");
      this.ResetZButton.UseVisualStyleBackColor = false;
      this.ResetZButton.Click += new System.EventHandler(this.ResetZButton_Click);
      // 
      // HomeButton
      // 
      this.HomeButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.HomeButton.BackgroundImage = global::GRBLMachine.Properties.Resources.home;
      this.HomeButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.home_gray;
      this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.HomeButton.Enabled = false;
      this.HomeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.HomeButton.ForeColor = System.Drawing.Color.Yellow;
      this.HomeButton.Location = new System.Drawing.Point(79, 19);
      this.HomeButton.Name = "HomeButton";
      this.HomeButton.Size = new System.Drawing.Size(61, 36);
      this.HomeButton.TabIndex = 14;
      this.TheToolTip.SetToolTip(this.HomeButton, "Perform Homing Cycle");
      this.HomeButton.UseVisualStyleBackColor = false;
      this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
      // 
      // OriginButton
      // 
      this.OriginButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.OriginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OriginButton.BackgroundImage")));
      this.OriginButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.OriginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.OriginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.OriginButton.ForeColor = System.Drawing.Color.Yellow;
      this.OriginButton.Location = new System.Drawing.Point(79, 61);
      this.OriginButton.Name = "OriginButton";
      this.OriginButton.Size = new System.Drawing.Size(61, 36);
      this.OriginButton.TabIndex = 15;
      this.OriginButton.Text = "0,0,0";
      this.TheToolTip.SetToolTip(this.OriginButton, "Move to Origin");
      this.OriginButton.UseVisualStyleBackColor = false;
      this.OriginButton.Click += new System.EventHandler(this.OriginButton_Click);
      // 
      // WCSButton
      // 
      this.WCSButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.WCSButton.BackgroundImage = global::GRBLMachine.Properties.Resources.wcs;
      this.WCSButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.wcs_gray;
      this.WCSButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.WCSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.WCSButton.ForeColor = System.Drawing.Color.Yellow;
      this.WCSButton.Location = new System.Drawing.Point(79, 103);
      this.WCSButton.Name = "WCSButton";
      this.WCSButton.Size = new System.Drawing.Size(61, 36);
      this.WCSButton.TabIndex = 16;
      this.TheToolTip.SetToolTip(this.WCSButton, "Set WCS Origin to 0,0,0");
      this.WCSButton.UseVisualStyleBackColor = false;
      this.WCSButton.Click += new System.EventHandler(this.WCSButton_Click);
      // 
      // JoggingExpander
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScroll = true;
      this.Name = "JoggingExpander";
      this.Size = new System.Drawing.Size(380, 200);
      this.ContentPanel.ResumeLayout(false);
      this.ContentPanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private GRBLButton X_Plus;
    private GRBLButton Z_Min;
    private GRBLButton Z_Plus;
    private GRBLButton Y_Min;
    private GRBLButton Y_Plus;
    private GRBLButton X_Min;
    private System.Windows.Forms.RadioButton Millimeters;
    private System.Windows.Forms.RadioButton Inches;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox StepZ;
    private System.Windows.Forms.TextBox StepXY;
    private GRBLButton ResetZButton;
    private GRBLButton ResetYButton;
    private GRBLButton ResetXButton;
    private GRBLButton OriginButton;
    private GRBLButton HomeButton;
    private GRBLButton WCSButton;
  }
}
