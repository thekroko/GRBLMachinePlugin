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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoggingExpander));
      this.X_Plus = new GRBLMachine.UI.GRBLButton();
      this.X_Min = new GRBLMachine.UI.GRBLButton();
      this.Y_Plus = new GRBLMachine.UI.GRBLButton();
      this.Y_Min = new GRBLMachine.UI.GRBLButton();
      this.Z_Plus = new GRBLMachine.UI.GRBLButton();
      this.Z_Min = new GRBLMachine.UI.GRBLButton();
      this.StepXY = new System.Windows.Forms.TextBox();
      this.StepZ = new System.Windows.Forms.TextBox();
      this.Inches = new System.Windows.Forms.RadioButton();
      this.Millimeters = new System.Windows.Forms.RadioButton();
      this.ResetXButton = new GRBLMachine.UI.GRBLButton();
      this.ResetYButton = new GRBLMachine.UI.GRBLButton();
      this.ResetZButton = new GRBLMachine.UI.GRBLButton();
      this.HomeButton = new GRBLMachine.UI.GRBLButton();
      this.OriginButton = new GRBLMachine.UI.GRBLButton();
      this.WCSButton = new GRBLMachine.UI.GRBLButton();
      this.MouseJog = new GRBLMachine.UI.GRBLButton();
      this.ZProbeButton = new GRBLMachine.UI.GRBLButton();
      this.PosA = new GRBLMachine.UI.GRBLButton();
      this.storedPosCtxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.storeCurrentPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.PosB = new GRBLMachine.UI.GRBLButton();
      this.Goto = new GRBLMachine.UI.GRBLButton();
      this.GotoText = new System.Windows.Forms.TextBox();
      this.GotoMouse = new GRBLMachine.UI.GRBLButton();
      this.OriginXYButton = new GRBLMachine.UI.GRBLButton();
      this.SwitchTo1 = new System.Windows.Forms.Button();
      this.SwitchTo5 = new System.Windows.Forms.Button();
      this.SwitchTo10 = new System.Windows.Forms.Button();
      this.ContentPanel.SuspendLayout();
      this.storedPosCtxMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // ContentPanel
      // 
      this.ContentPanel.Controls.Add(this.SwitchTo10);
      this.ContentPanel.Controls.Add(this.SwitchTo5);
      this.ContentPanel.Controls.Add(this.SwitchTo1);
      this.ContentPanel.Controls.Add(this.OriginXYButton);
      this.ContentPanel.Controls.Add(this.GotoMouse);
      this.ContentPanel.Controls.Add(this.GotoText);
      this.ContentPanel.Controls.Add(this.Goto);
      this.ContentPanel.Controls.Add(this.PosB);
      this.ContentPanel.Controls.Add(this.PosA);
      this.ContentPanel.Controls.Add(this.ZProbeButton);
      this.ContentPanel.Controls.Add(this.MouseJog);
      this.ContentPanel.Controls.Add(this.WCSButton);
      this.ContentPanel.Controls.Add(this.OriginButton);
      this.ContentPanel.Controls.Add(this.HomeButton);
      this.ContentPanel.Controls.Add(this.ResetZButton);
      this.ContentPanel.Controls.Add(this.ResetYButton);
      this.ContentPanel.Controls.Add(this.ResetXButton);
      this.ContentPanel.Controls.Add(this.Millimeters);
      this.ContentPanel.Controls.Add(this.Inches);
      this.ContentPanel.Controls.Add(this.StepZ);
      this.ContentPanel.Controls.Add(this.StepXY);
      this.ContentPanel.Controls.Add(this.Z_Min);
      this.ContentPanel.Controls.Add(this.Z_Plus);
      this.ContentPanel.Controls.Add(this.Y_Min);
      this.ContentPanel.Controls.Add(this.Y_Plus);
      this.ContentPanel.Controls.Add(this.X_Min);
      this.ContentPanel.Controls.Add(this.X_Plus);
      this.ContentPanel.Enabled = false;
      this.ContentPanel.Size = new System.Drawing.Size(366, 131);
      // 
      // HeaderLabel
      // 
      this.HeaderLabel.Margin = new System.Windows.Forms.Padding(3, 0, 2, 0);
      this.HeaderLabel.Size = new System.Drawing.Size(388, 19);
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
      this.X_Plus.Location = new System.Drawing.Point(299, 34);
      this.X_Plus.Margin = new System.Windows.Forms.Padding(2);
      this.X_Plus.Name = "X_Plus";
      this.X_Plus.Size = new System.Drawing.Size(27, 29);
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
      this.X_Min.Location = new System.Drawing.Point(236, 34);
      this.X_Min.Margin = new System.Windows.Forms.Padding(2);
      this.X_Min.Name = "X_Min";
      this.X_Min.Size = new System.Drawing.Size(27, 29);
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
      this.Y_Plus.Location = new System.Drawing.Point(268, 6);
      this.Y_Plus.Margin = new System.Windows.Forms.Padding(2);
      this.Y_Plus.Name = "Y_Plus";
      this.Y_Plus.Size = new System.Drawing.Size(27, 29);
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
      this.Y_Min.Location = new System.Drawing.Point(268, 64);
      this.Y_Min.Margin = new System.Windows.Forms.Padding(2);
      this.Y_Min.Name = "Y_Min";
      this.Y_Min.Size = new System.Drawing.Size(27, 29);
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
      this.Z_Plus.Location = new System.Drawing.Point(332, 33);
      this.Z_Plus.Margin = new System.Windows.Forms.Padding(2);
      this.Z_Plus.Name = "Z_Plus";
      this.Z_Plus.Size = new System.Drawing.Size(27, 29);
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
      this.Z_Min.Location = new System.Drawing.Point(332, 61);
      this.Z_Min.Margin = new System.Windows.Forms.Padding(2);
      this.Z_Min.Name = "Z_Min";
      this.Z_Min.Size = new System.Drawing.Size(27, 29);
      this.Z_Min.TabIndex = 5;
      this.Z_Min.Text = "Z-";
      this.TheToolTip.SetToolTip(this.Z_Min, "Step in Z- direction");
      this.Z_Min.UseVisualStyleBackColor = false;
      this.Z_Min.Click += new System.EventHandler(this.Z_Min_Click);
      // 
      // StepXY
      // 
      this.StepXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.StepXY.Location = new System.Drawing.Point(235, 10);
      this.StepXY.Margin = new System.Windows.Forms.Padding(2);
      this.StepXY.Name = "StepXY";
      this.StepXY.Size = new System.Drawing.Size(28, 20);
      this.StepXY.TabIndex = 6;
      this.StepXY.Text = "10";
      this.StepXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.TheToolTip.SetToolTip(this.StepXY, "Step value for X and Y directions");
      this.StepXY.TextChanged += new System.EventHandler(this.StepXY_TextChanged);
      // 
      // StepZ
      // 
      this.StepZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.StepZ.Location = new System.Drawing.Point(331, 11);
      this.StepZ.Margin = new System.Windows.Forms.Padding(2);
      this.StepZ.Name = "StepZ";
      this.StepZ.Size = new System.Drawing.Size(28, 20);
      this.StepZ.TabIndex = 7;
      this.StepZ.Text = "5";
      this.StepZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.TheToolTip.SetToolTip(this.StepZ, "Step value in Z directions");
      this.StepZ.TextChanged += new System.EventHandler(this.StepZ_TextChanged);
      // 
      // Inches
      // 
      this.Inches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Inches.AutoSize = true;
      this.Inches.Location = new System.Drawing.Point(131, 73);
      this.Inches.Margin = new System.Windows.Forms.Padding(2);
      this.Inches.Name = "Inches";
      this.Inches.Size = new System.Drawing.Size(45, 17);
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
      this.Millimeters.Location = new System.Drawing.Point(180, 73);
      this.Millimeters.Margin = new System.Windows.Forms.Padding(2);
      this.Millimeters.Name = "Millimeters";
      this.Millimeters.Size = new System.Drawing.Size(41, 17);
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
      this.ResetXButton.Location = new System.Drawing.Point(9, 7);
      this.ResetXButton.Margin = new System.Windows.Forms.Padding(2);
      this.ResetXButton.Name = "ResetXButton";
      this.ResetXButton.Size = new System.Drawing.Size(46, 29);
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
      this.ResetYButton.Location = new System.Drawing.Point(59, 7);
      this.ResetYButton.Margin = new System.Windows.Forms.Padding(2);
      this.ResetYButton.Name = "ResetYButton";
      this.ResetYButton.Size = new System.Drawing.Size(46, 29);
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
      this.ResetZButton.Location = new System.Drawing.Point(9, 35);
      this.ResetZButton.Margin = new System.Windows.Forms.Padding(2);
      this.ResetZButton.Name = "ResetZButton";
      this.ResetZButton.Size = new System.Drawing.Size(46, 29);
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
      this.HomeButton.Location = new System.Drawing.Point(109, 35);
      this.HomeButton.Margin = new System.Windows.Forms.Padding(2);
      this.HomeButton.Name = "HomeButton";
      this.HomeButton.Size = new System.Drawing.Size(46, 29);
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
      this.OriginButton.Location = new System.Drawing.Point(9, 64);
      this.OriginButton.Margin = new System.Windows.Forms.Padding(2);
      this.OriginButton.Name = "OriginButton";
      this.OriginButton.Size = new System.Drawing.Size(46, 29);
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
      this.WCSButton.Location = new System.Drawing.Point(109, 7);
      this.WCSButton.Margin = new System.Windows.Forms.Padding(2);
      this.WCSButton.Name = "WCSButton";
      this.WCSButton.Size = new System.Drawing.Size(46, 29);
      this.WCSButton.TabIndex = 16;
      this.TheToolTip.SetToolTip(this.WCSButton, "Set WCS Origin to 0,0,0");
      this.WCSButton.UseVisualStyleBackColor = false;
      this.WCSButton.Click += new System.EventHandler(this.WCSButton_Click);
      // 
      // MouseJog
      // 
      this.MouseJog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.MouseJog.BackgroundImage = global::GRBLMachine.Properties.Resources.nav_plain_blue;
      this.MouseJog.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.nav_plain_gray;
      this.MouseJog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.MouseJog.Location = new System.Drawing.Point(268, 34);
      this.MouseJog.Name = "MouseJog";
      this.MouseJog.Size = new System.Drawing.Size(26, 29);
      this.MouseJog.TabIndex = 17;
      this.TheToolTip.SetToolTip(this.MouseJog, "Mouse Jog (drag)");
      this.MouseJog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseJog_MouseDown);
      this.MouseJog.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseJog_MouseMove);
      this.MouseJog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseJog_MouseUp);
      // 
      // ZProbeButton
      // 
      this.ZProbeButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ZProbeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ZProbeButton.BackgroundImage")));
      this.ZProbeButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.ZProbeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ZProbeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ZProbeButton.ForeColor = System.Drawing.Color.Yellow;
      this.ZProbeButton.Location = new System.Drawing.Point(59, 35);
      this.ZProbeButton.Margin = new System.Windows.Forms.Padding(2);
      this.ZProbeButton.Name = "ZProbeButton";
      this.ZProbeButton.Size = new System.Drawing.Size(46, 29);
      this.ZProbeButton.TabIndex = 18;
      this.ZProbeButton.Text = "Z-PB";
      this.TheToolTip.SetToolTip(this.ZProbeButton, "Execute Z-Probe and apply Tool Offset");
      this.ZProbeButton.UseVisualStyleBackColor = false;
      this.ZProbeButton.Click += new System.EventHandler(this.ZProbeButton_Click);
      // 
      // PosA
      // 
      this.PosA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.PosA.BackColor = System.Drawing.SystemColors.ControlDark;
      this.PosA.BackgroundImage = global::GRBLMachine.Properties.Resources.media_stop_yllw;
      this.PosA.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.PosA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.PosA.ContextMenuStrip = this.storedPosCtxMenu;
      this.PosA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PosA.ForeColor = System.Drawing.Color.White;
      this.PosA.Location = new System.Drawing.Point(9, 101);
      this.PosA.Margin = new System.Windows.Forms.Padding(2);
      this.PosA.Name = "PosA";
      this.PosA.Size = new System.Drawing.Size(46, 29);
      this.PosA.TabIndex = 19;
      this.PosA.Text = "PosA";
      this.TheToolTip.SetToolTip(this.PosA, "Go to stored position A");
      this.PosA.UseVisualStyleBackColor = false;
      this.PosA.Click += new System.EventHandler(this.PosA_Click);
      // 
      // storedPosCtxMenu
      // 
      this.storedPosCtxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.storeCurrentPositionToolStripMenuItem});
      this.storedPosCtxMenu.Name = "storedPosCtxMenu";
      this.storedPosCtxMenu.Size = new System.Drawing.Size(191, 26);
      // 
      // storeCurrentPositionToolStripMenuItem
      // 
      this.storeCurrentPositionToolStripMenuItem.Name = "storeCurrentPositionToolStripMenuItem";
      this.storeCurrentPositionToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.storeCurrentPositionToolStripMenuItem.Text = "Store Current Position";
      this.storeCurrentPositionToolStripMenuItem.Click += new System.EventHandler(this.storeCurrentPositionToolStripMenuItem_Click);
      // 
      // PosB
      // 
      this.PosB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.PosB.BackColor = System.Drawing.SystemColors.ControlDark;
      this.PosB.BackgroundImage = global::GRBLMachine.Properties.Resources.media_stop_yllw;
      this.PosB.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.PosB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.PosB.ContextMenuStrip = this.storedPosCtxMenu;
      this.PosB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PosB.ForeColor = System.Drawing.Color.White;
      this.PosB.Location = new System.Drawing.Point(59, 101);
      this.PosB.Margin = new System.Windows.Forms.Padding(2);
      this.PosB.Name = "PosB";
      this.PosB.Size = new System.Drawing.Size(46, 29);
      this.PosB.TabIndex = 20;
      this.PosB.Text = "PosB";
      this.TheToolTip.SetToolTip(this.PosB, "Go to stored position B");
      this.PosB.UseVisualStyleBackColor = false;
      this.PosB.Click += new System.EventHandler(this.PosB_Click);
      // 
      // Goto
      // 
      this.Goto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.Goto.BackColor = System.Drawing.SystemColors.ControlDark;
      this.Goto.BackgroundImage = global::GRBLMachine.Properties.Resources.media_stop_yllw;
      this.Goto.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.Goto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.Goto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Goto.ForeColor = System.Drawing.Color.White;
      this.Goto.Location = new System.Drawing.Point(118, 101);
      this.Goto.Margin = new System.Windows.Forms.Padding(2);
      this.Goto.Name = "Goto";
      this.Goto.Size = new System.Drawing.Size(58, 29);
      this.Goto.TabIndex = 21;
      this.Goto.Text = "Goto >";
      this.TheToolTip.SetToolTip(this.Goto, "Go to specified position in text box");
      this.Goto.UseVisualStyleBackColor = false;
      this.Goto.Click += new System.EventHandler(this.Goto_Click);
      // 
      // GotoText
      // 
      this.GotoText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GotoText.Location = new System.Drawing.Point(180, 106);
      this.GotoText.Margin = new System.Windows.Forms.Padding(2);
      this.GotoText.Name = "GotoText";
      this.GotoText.Size = new System.Drawing.Size(107, 20);
      this.GotoText.TabIndex = 22;
      this.GotoText.Text = "X0 Y0";
      this.TheToolTip.SetToolTip(this.GotoText, "Step value for X and Y directions");
      // 
      // GotoMouse
      // 
      this.GotoMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.GotoMouse.BackColor = System.Drawing.SystemColors.ControlDark;
      this.GotoMouse.BackgroundImage = global::GRBLMachine.Properties.Resources.media_stop_yllw;
      this.GotoMouse.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.GotoMouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.GotoMouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.GotoMouse.ForeColor = System.Drawing.Color.White;
      this.GotoMouse.Location = new System.Drawing.Point(291, 100);
      this.GotoMouse.Margin = new System.Windows.Forms.Padding(2);
      this.GotoMouse.Name = "GotoMouse";
      this.GotoMouse.Size = new System.Drawing.Size(75, 29);
      this.GotoMouse.TabIndex = 23;
      this.GotoMouse.Text = "Goto Cursor";
      this.TheToolTip.SetToolTip(this.GotoMouse, "Go to specified position in text box");
      this.GotoMouse.UseVisualStyleBackColor = false;
      this.GotoMouse.Click += new System.EventHandler(this.GotoMouse_Click);
      // 
      // OriginXYButton
      // 
      this.OriginXYButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.OriginXYButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OriginXYButton.BackgroundImage")));
      this.OriginXYButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.OriginXYButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.OriginXYButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.OriginXYButton.ForeColor = System.Drawing.Color.Yellow;
      this.OriginXYButton.Location = new System.Drawing.Point(58, 64);
      this.OriginXYButton.Margin = new System.Windows.Forms.Padding(2);
      this.OriginXYButton.Name = "OriginXYButton";
      this.OriginXYButton.Size = new System.Drawing.Size(46, 29);
      this.OriginXYButton.TabIndex = 24;
      this.OriginXYButton.Text = "0,0";
      this.TheToolTip.SetToolTip(this.OriginXYButton, "Move to Origin");
      this.OriginXYButton.UseVisualStyleBackColor = false;
      this.OriginXYButton.Click += new System.EventHandler(this.OriginXYButton_Click);
      // 
      // SwitchTo1
      // 
      this.SwitchTo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.SwitchTo1.Location = new System.Drawing.Point(195, 7);
      this.SwitchTo1.Name = "SwitchTo1";
      this.SwitchTo1.Size = new System.Drawing.Size(27, 20);
      this.SwitchTo1.TabIndex = 25;
      this.SwitchTo1.Text = "1";
      this.SwitchTo1.UseVisualStyleBackColor = true;
      this.SwitchTo1.Click += new System.EventHandler(this.SwitchTo1_Click);
      // 
      // SwitchTo5
      // 
      this.SwitchTo5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.SwitchTo5.Location = new System.Drawing.Point(195, 27);
      this.SwitchTo5.Name = "SwitchTo5";
      this.SwitchTo5.Size = new System.Drawing.Size(27, 20);
      this.SwitchTo5.TabIndex = 26;
      this.SwitchTo5.Text = "3";
      this.SwitchTo5.UseVisualStyleBackColor = true;
      this.SwitchTo5.Click += new System.EventHandler(this.SwitchTo5_Click);
      // 
      // SwitchTo10
      // 
      this.SwitchTo10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.SwitchTo10.Location = new System.Drawing.Point(195, 47);
      this.SwitchTo10.Name = "SwitchTo10";
      this.SwitchTo10.Size = new System.Drawing.Size(27, 20);
      this.SwitchTo10.TabIndex = 27;
      this.SwitchTo10.Text = "5";
      this.SwitchTo10.UseVisualStyleBackColor = true;
      this.SwitchTo10.Click += new System.EventHandler(this.SwitchTo10_Click);
      // 
      // JoggingExpander
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScroll = true;
      this.MinimumSize = new System.Drawing.Size(214, 0);
      this.Name = "JoggingExpander";
      this.Size = new System.Drawing.Size(393, 160);
      this.Controls.SetChildIndex(this.ContentPanel, 0);
      this.Controls.SetChildIndex(this.HeaderLabel, 0);
      this.ContentPanel.ResumeLayout(false);
      this.ContentPanel.PerformLayout();
      this.storedPosCtxMenu.ResumeLayout(false);
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
    private System.Windows.Forms.TextBox StepZ;
    private System.Windows.Forms.TextBox StepXY;
    private GRBLButton ResetZButton;
    private GRBLButton ResetYButton;
    private GRBLButton ResetXButton;
    private GRBLButton OriginButton;
    private GRBLButton HomeButton;
    private GRBLButton WCSButton;
    private GRBLButton MouseJog;
    private GRBLButton ZProbeButton;
    private GRBLButton PosA;
    private System.Windows.Forms.ContextMenuStrip storedPosCtxMenu;
    private System.Windows.Forms.ToolStripMenuItem storeCurrentPositionToolStripMenuItem;
    private GRBLButton PosB;
    private System.Windows.Forms.TextBox GotoText;
    private GRBLButton Goto;
    private GRBLButton GotoMouse;
    private GRBLButton OriginXYButton;
    private System.Windows.Forms.Button SwitchTo10;
    private System.Windows.Forms.Button SwitchTo5;
    private System.Windows.Forms.Button SwitchTo1;
  }
}
