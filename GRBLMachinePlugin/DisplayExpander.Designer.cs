namespace GRBLMachine.UI
{
  partial class DisplayExpander : Expander
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
      System.Windows.Forms.Label label9;
      this.X_Axis = new System.Windows.Forms.Label();
      this.X_AxisContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.X_OriginZero = new System.Windows.Forms.ToolStripMenuItem();
      this.Y_Axis = new System.Windows.Forms.Label();
      this.Y_AxisContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.Y_OriginZero = new System.Windows.Forms.ToolStripMenuItem();
      this.Z_Axis = new System.Windows.Forms.Label();
      this.Z_AxisContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.Z_OriginZero = new System.Windows.Forms.ToolStripMenuItem();
      this.X_Pos = new System.Windows.Forms.Label();
      this.Y_Pos = new System.Windows.Forms.Label();
      this.Z_Pos = new System.Windows.Forms.Label();
      this.StatusLabel = new System.Windows.Forms.Label();
      this.StateContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.Hold = new System.Windows.Forms.ToolStripMenuItem();
      this.Resume = new System.Windows.Forms.ToolStripMenuItem();
      this.Alarm = new System.Windows.Forms.ToolStripMenuItem();
      this.Coordinates = new System.Windows.Forms.Label();
      this.CoordinateContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.WPos = new System.Windows.Forms.ToolStripMenuItem();
      this.MPos = new System.Windows.Forms.ToolStripMenuItem();
      this.FeedUnits = new System.Windows.Forms.Label();
      this.FeedUnitsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.FeedUnitInches = new System.Windows.Forms.ToolStripMenuItem();
      this.FeedUnitMillimeters = new System.Windows.Forms.ToolStripMenuItem();
      this.FeedLabel = new System.Windows.Forms.Label();
      this.RPMLabel = new System.Windows.Forms.Label();
      this.TrackTimer = new System.Windows.Forms.Timer(this.components);
      this.AlarmTip = new System.Windows.Forms.ToolTip(this.components);
      this.ErrorTip = new System.Windows.Forms.ToolTip(this.components);
      this.BlinkTimer = new System.Windows.Forms.Timer(this.components);
      label9 = new System.Windows.Forms.Label();
      this.ContentPanel.SuspendLayout();
      this.X_AxisContextMenu.SuspendLayout();
      this.Y_AxisContextMenu.SuspendLayout();
      this.Z_AxisContextMenu.SuspendLayout();
      this.StateContextMenu.SuspendLayout();
      this.CoordinateContextMenu.SuspendLayout();
      this.FeedUnitsContextMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // ContentPanel
      // 
      this.ContentPanel.BackgroundImage = global::GRBLMachine.Properties.Resources.LCD_Blank;
      this.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.ContentPanel.Controls.Add(this.RPMLabel);
      this.ContentPanel.Controls.Add(this.FeedLabel);
      this.ContentPanel.Controls.Add(label9);
      this.ContentPanel.Controls.Add(this.FeedUnits);
      this.ContentPanel.Controls.Add(this.Coordinates);
      this.ContentPanel.Controls.Add(this.StatusLabel);
      this.ContentPanel.Controls.Add(this.Z_Pos);
      this.ContentPanel.Controls.Add(this.Y_Pos);
      this.ContentPanel.Controls.Add(this.X_Pos);
      this.ContentPanel.Controls.Add(this.Z_Axis);
      this.ContentPanel.Controls.Add(this.Y_Axis);
      this.ContentPanel.Controls.Add(this.X_Axis);
      this.ContentPanel.Font = new System.Drawing.Font("Monospac821 BT", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ContentPanel.ForeColor = System.Drawing.Color.Olive;
      this.ContentPanel.Size = new System.Drawing.Size(363, 174);
      // 
      // HeaderLabel
      // 
      this.HeaderLabel.Text = "Display";
      // 
      // TheToolTip
      // 
      this.TheToolTip.IsBalloon = true;
      // 
      // label9
      // 
      label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      label9.BackColor = System.Drawing.Color.Transparent;
      label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      label9.Location = new System.Drawing.Point(233, 146);
      label9.Name = "label9";
      label9.Size = new System.Drawing.Size(44, 18);
      label9.TabIndex = 9;
      label9.Text = "rpm";
      // 
      // X_Axis
      // 
      this.X_Axis.AutoSize = true;
      this.X_Axis.BackColor = System.Drawing.Color.Transparent;
      this.X_Axis.ContextMenuStrip = this.X_AxisContextMenu;
      this.X_Axis.Cursor = System.Windows.Forms.Cursors.Hand;
      this.X_Axis.Font = new System.Drawing.Font("Arial Rounded MT Bold", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.X_Axis.Location = new System.Drawing.Point(7, 5);
      this.X_Axis.Name = "X_Axis";
      this.X_Axis.Size = new System.Drawing.Size(44, 45);
      this.X_Axis.TabIndex = 0;
      this.X_Axis.Text = "X";
      this.TheToolTip.SetToolTip(this.X_Axis, "Left or Right Click to reset WCS X-origin");
      this.X_Axis.Click += new System.EventHandler(this.X_Axis_Click);
      // 
      // X_AxisContextMenu
      // 
      this.X_AxisContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.X_AxisContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.X_OriginZero});
      this.X_AxisContextMenu.Name = "AxisContextMenu";
      this.X_AxisContextMenu.Size = new System.Drawing.Size(219, 30);
      // 
      // X_OriginZero
      // 
      this.X_OriginZero.Name = "X_OriginZero";
      this.X_OriginZero.Size = new System.Drawing.Size(218, 26);
      this.X_OriginZero.Text = "Set WCS origin Zero";
      this.X_OriginZero.Click += new System.EventHandler(this.ResetXMenu_Click);
      // 
      // Y_Axis
      // 
      this.Y_Axis.AutoSize = true;
      this.Y_Axis.BackColor = System.Drawing.Color.Transparent;
      this.Y_Axis.ContextMenuStrip = this.Y_AxisContextMenu;
      this.Y_Axis.Cursor = System.Windows.Forms.Cursors.Hand;
      this.Y_Axis.Font = new System.Drawing.Font("Arial Rounded MT Bold", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Y_Axis.Location = new System.Drawing.Point(7, 43);
      this.Y_Axis.Name = "Y_Axis";
      this.Y_Axis.Size = new System.Drawing.Size(44, 45);
      this.Y_Axis.TabIndex = 1;
      this.Y_Axis.Text = "Y";
      this.TheToolTip.SetToolTip(this.Y_Axis, "Left or Right Click to reset WCS Y-origin");
      this.Y_Axis.Click += new System.EventHandler(this.Y_Axis_Click);
      // 
      // Y_AxisContextMenu
      // 
      this.Y_AxisContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.Y_AxisContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Y_OriginZero});
      this.Y_AxisContextMenu.Name = "AxisContextMenu";
      this.Y_AxisContextMenu.Size = new System.Drawing.Size(219, 30);
      // 
      // Y_OriginZero
      // 
      this.Y_OriginZero.Name = "Y_OriginZero";
      this.Y_OriginZero.Size = new System.Drawing.Size(218, 26);
      this.Y_OriginZero.Text = "Set WCS origin Zero";
      this.Y_OriginZero.Click += new System.EventHandler(this.ResetYMenu_Click);
      // 
      // Z_Axis
      // 
      this.Z_Axis.AutoSize = true;
      this.Z_Axis.BackColor = System.Drawing.Color.Transparent;
      this.Z_Axis.ContextMenuStrip = this.Z_AxisContextMenu;
      this.Z_Axis.Cursor = System.Windows.Forms.Cursors.Hand;
      this.Z_Axis.Font = new System.Drawing.Font("Arial Rounded MT Bold", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Z_Axis.Location = new System.Drawing.Point(7, 81);
      this.Z_Axis.Name = "Z_Axis";
      this.Z_Axis.Size = new System.Drawing.Size(45, 45);
      this.Z_Axis.TabIndex = 2;
      this.Z_Axis.Text = "Z";
      this.TheToolTip.SetToolTip(this.Z_Axis, "Left or Right Click to reset WCS Z-origin");
      this.Z_Axis.Click += new System.EventHandler(this.Z_Axis_Click);
      // 
      // Z_AxisContextMenu
      // 
      this.Z_AxisContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.Z_AxisContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Z_OriginZero});
      this.Z_AxisContextMenu.Name = "AxisContextMenu";
      this.Z_AxisContextMenu.Size = new System.Drawing.Size(219, 30);
      // 
      // Z_OriginZero
      // 
      this.Z_OriginZero.Name = "Z_OriginZero";
      this.Z_OriginZero.Size = new System.Drawing.Size(218, 26);
      this.Z_OriginZero.Text = "Set WCS origin Zero";
      this.Z_OriginZero.Click += new System.EventHandler(this.ResetZMenu_Click);
      // 
      // X_Pos
      // 
      this.X_Pos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.X_Pos.BackColor = System.Drawing.Color.Transparent;
      this.X_Pos.ContextMenuStrip = this.X_AxisContextMenu;
      this.X_Pos.Cursor = System.Windows.Forms.Cursors.Hand;
      this.X_Pos.Location = new System.Drawing.Point(80, 10);
      this.X_Pos.Name = "X_Pos";
      this.X_Pos.Size = new System.Drawing.Size(278, 40);
      this.X_Pos.TabIndex = 3;
      this.X_Pos.Text = "-----. ---";
      this.X_Pos.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.TheToolTip.SetToolTip(this.X_Pos, "Left or Right Click to reset WCS X-origin");
      this.X_Pos.Click += new System.EventHandler(this.X_Axis_Click);
      // 
      // Y_Pos
      // 
      this.Y_Pos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Y_Pos.BackColor = System.Drawing.Color.Transparent;
      this.Y_Pos.ContextMenuStrip = this.Y_AxisContextMenu;
      this.Y_Pos.Cursor = System.Windows.Forms.Cursors.Hand;
      this.Y_Pos.Location = new System.Drawing.Point(80, 48);
      this.Y_Pos.Name = "Y_Pos";
      this.Y_Pos.Size = new System.Drawing.Size(278, 40);
      this.Y_Pos.TabIndex = 4;
      this.Y_Pos.Text = "-----. ---";
      this.Y_Pos.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.TheToolTip.SetToolTip(this.Y_Pos, "Left or Right Click to reset WCS Y-origin");
      this.Y_Pos.Click += new System.EventHandler(this.Y_Axis_Click);
      // 
      // Z_Pos
      // 
      this.Z_Pos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Z_Pos.BackColor = System.Drawing.Color.Transparent;
      this.Z_Pos.ContextMenuStrip = this.Z_AxisContextMenu;
      this.Z_Pos.Cursor = System.Windows.Forms.Cursors.Hand;
      this.Z_Pos.Location = new System.Drawing.Point(80, 86);
      this.Z_Pos.Name = "Z_Pos";
      this.Z_Pos.Size = new System.Drawing.Size(278, 40);
      this.Z_Pos.TabIndex = 5;
      this.Z_Pos.Text = "-----. ---";
      this.Z_Pos.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.TheToolTip.SetToolTip(this.Z_Pos, "Left or Right Click to reset WCS Z-origin");
      this.Z_Pos.Click += new System.EventHandler(this.Z_Axis_Click);
      // 
      // StatusLabel
      // 
      this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
      this.StatusLabel.ContextMenuStrip = this.StateContextMenu;
      this.StatusLabel.Cursor = System.Windows.Forms.Cursors.Hand;
      this.StatusLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.StatusLabel.Location = new System.Drawing.Point(1, 126);
      this.StatusLabel.Margin = new System.Windows.Forms.Padding(0);
      this.StatusLabel.Name = "StatusLabel";
      this.StatusLabel.Size = new System.Drawing.Size(169, 43);
      this.StatusLabel.TabIndex = 6;
      this.StatusLabel.Text = "Idle";
      this.TheToolTip.SetToolTip(this.StatusLabel, "Left or Right Click to Hold, Resume or Reset Alarms");
      this.StatusLabel.Click += new System.EventHandler(this.StatusLabel_Click);
      // 
      // StateContextMenu
      // 
      this.StateContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.StateContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Hold,
            this.Resume,
            this.Alarm});
      this.StateContextMenu.Name = "contextMenuStrip1";
      this.StateContextMenu.Size = new System.Drawing.Size(165, 82);
      // 
      // Hold
      // 
      this.Hold.Name = "Hold";
      this.Hold.Size = new System.Drawing.Size(164, 26);
      this.Hold.Text = "Hold";
      this.Hold.Click += new System.EventHandler(this.Hold_Click);
      // 
      // Resume
      // 
      this.Resume.Name = "Resume";
      this.Resume.Size = new System.Drawing.Size(164, 26);
      this.Resume.Text = "Resume";
      this.Resume.Click += new System.EventHandler(this.Resume_Click);
      // 
      // Alarm
      // 
      this.Alarm.Name = "Alarm";
      this.Alarm.Size = new System.Drawing.Size(164, 26);
      this.Alarm.Text = "Reset Alarm";
      this.Alarm.Click += new System.EventHandler(this.Alarm_Click);
      // 
      // Coordinates
      // 
      this.Coordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Coordinates.BackColor = System.Drawing.Color.Transparent;
      this.Coordinates.ContextMenuStrip = this.CoordinateContextMenu;
      this.Coordinates.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Coordinates.Location = new System.Drawing.Point(289, 146);
      this.Coordinates.Name = "Coordinates";
      this.Coordinates.Size = new System.Drawing.Size(61, 18);
      this.Coordinates.TabIndex = 7;
      this.Coordinates.Text = "?Pos";
      this.Coordinates.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.TheToolTip.SetToolTip(this.Coordinates, "Left or Right Click to select between Work- or Machine Position display");
      this.Coordinates.Click += new System.EventHandler(this.Coordinates_Click);
      // 
      // CoordinateContextMenu
      // 
      this.CoordinateContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.CoordinateContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WPos,
            this.MPos});
      this.CoordinateContextMenu.Name = "contextMenuStrip1";
      this.CoordinateContextMenu.Size = new System.Drawing.Size(225, 56);
      // 
      // WPos
      // 
      this.WPos.CheckOnClick = true;
      this.WPos.Name = "WPos";
      this.WPos.Size = new System.Drawing.Size(224, 26);
      this.WPos.Text = "Work Coordinates";
      this.WPos.Click += new System.EventHandler(this.WPos_Click);
      // 
      // MPos
      // 
      this.MPos.CheckOnClick = true;
      this.MPos.Name = "MPos";
      this.MPos.Size = new System.Drawing.Size(224, 26);
      this.MPos.Text = "Machine Coordinates";
      this.MPos.Click += new System.EventHandler(this.MPos_Click);
      // 
      // FeedUnits
      // 
      this.FeedUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.FeedUnits.BackColor = System.Drawing.Color.Transparent;
      this.FeedUnits.ContextMenuStrip = this.FeedUnitsContextMenu;
      this.FeedUnits.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FeedUnits.Location = new System.Drawing.Point(233, 125);
      this.FeedUnits.Name = "FeedUnits";
      this.FeedUnits.Size = new System.Drawing.Size(113, 20);
      this.FeedUnits.TabIndex = 8;
      this.FeedUnits.Text = "mm/min";
      this.TheToolTip.SetToolTip(this.FeedUnits, "Left or Right Click to change between Inch and Metric display");
      this.FeedUnits.Click += new System.EventHandler(this.FeedUnits_Click);
      // 
      // FeedUnitsContextMenu
      // 
      this.FeedUnitsContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.FeedUnitsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FeedUnitInches,
            this.FeedUnitMillimeters});
      this.FeedUnitsContextMenu.Name = "contextMenuStrip1";
      this.FeedUnitsContextMenu.Size = new System.Drawing.Size(190, 56);
      // 
      // FeedUnitInches
      // 
      this.FeedUnitInches.CheckOnClick = true;
      this.FeedUnitInches.Name = "FeedUnitInches";
      this.FeedUnitInches.Size = new System.Drawing.Size(189, 26);
      this.FeedUnitInches.Text = "Inches/min";
      this.FeedUnitInches.Click += new System.EventHandler(this.FeedUnitInches_Click);
      // 
      // FeedUnitMillimeters
      // 
      this.FeedUnitMillimeters.CheckOnClick = true;
      this.FeedUnitMillimeters.Name = "FeedUnitMillimeters";
      this.FeedUnitMillimeters.Size = new System.Drawing.Size(189, 26);
      this.FeedUnitMillimeters.Text = "Millimeters/min";
      this.FeedUnitMillimeters.Click += new System.EventHandler(this.FeedUnitMillimeters_Click);
      // 
      // FeedLabel
      // 
      this.FeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.FeedLabel.BackColor = System.Drawing.Color.Transparent;
      this.FeedLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FeedLabel.Location = new System.Drawing.Point(159, 126);
      this.FeedLabel.Name = "FeedLabel";
      this.FeedLabel.Size = new System.Drawing.Size(77, 18);
      this.FeedLabel.TabIndex = 10;
      this.FeedLabel.Text = "----";
      this.FeedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // RPMLabel
      // 
      this.RPMLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.RPMLabel.BackColor = System.Drawing.Color.Transparent;
      this.RPMLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RPMLabel.Location = new System.Drawing.Point(158, 146);
      this.RPMLabel.Name = "RPMLabel";
      this.RPMLabel.Size = new System.Drawing.Size(78, 18);
      this.RPMLabel.TabIndex = 11;
      this.RPMLabel.Text = "-----";
      this.RPMLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // TrackTimer
      // 
      this.TrackTimer.Enabled = true;
      this.TrackTimer.Interval = 25;
      this.TrackTimer.Tick += new System.EventHandler(this.TrackTimer_Tick);
      // 
      // AlarmTip
      // 
      this.AlarmTip.AutoPopDelay = 5000;
      this.AlarmTip.InitialDelay = 0;
      this.AlarmTip.IsBalloon = true;
      this.AlarmTip.ReshowDelay = 100;
      // 
      // ErrorTip
      // 
      this.ErrorTip.AutoPopDelay = 5000;
      this.ErrorTip.InitialDelay = 0;
      this.ErrorTip.IsBalloon = true;
      this.ErrorTip.ReshowDelay = 100;
      // 
      // BlinkTimer
      // 
      this.BlinkTimer.Enabled = true;
      this.BlinkTimer.Interval = 500;
      this.BlinkTimer.Tick += new System.EventHandler(this.BlinkTimer_Tick);
      // 
      // DisplayExpander
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScroll = true;
      this.Name = "DisplayExpander";
      this.Size = new System.Drawing.Size(380, 210);
      this.Controls.SetChildIndex(this.ContentPanel, 0);
      this.Controls.SetChildIndex(this.HeaderLabel, 0);
      this.ContentPanel.ResumeLayout(false);
      this.ContentPanel.PerformLayout();
      this.X_AxisContextMenu.ResumeLayout(false);
      this.Y_AxisContextMenu.ResumeLayout(false);
      this.Z_AxisContextMenu.ResumeLayout(false);
      this.StateContextMenu.ResumeLayout(false);
      this.CoordinateContextMenu.ResumeLayout(false);
      this.FeedUnitsContextMenu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Label X_Pos;
    private System.Windows.Forms.Label Z_Axis;
    private System.Windows.Forms.Label Y_Axis;
    private System.Windows.Forms.Label X_Axis;
    private System.Windows.Forms.Label Y_Pos;
    private System.Windows.Forms.Label Z_Pos;
    private System.Windows.Forms.Label StatusLabel;
    private System.Windows.Forms.Label Coordinates;
    private System.Windows.Forms.Label RPMLabel;
    private System.Windows.Forms.Label FeedLabel;
    private System.Windows.Forms.Label FeedUnits;
    private System.Windows.Forms.ContextMenuStrip StateContextMenu;
    private System.Windows.Forms.ToolStripMenuItem Hold;
    private System.Windows.Forms.ToolStripMenuItem Resume;
    private System.Windows.Forms.ContextMenuStrip X_AxisContextMenu;
    private System.Windows.Forms.ToolStripMenuItem X_OriginZero;
    private System.Windows.Forms.ContextMenuStrip Z_AxisContextMenu;
    private System.Windows.Forms.ToolStripMenuItem Z_OriginZero;
    private System.Windows.Forms.ContextMenuStrip Y_AxisContextMenu;
    private System.Windows.Forms.ToolStripMenuItem Y_OriginZero;
    private System.Windows.Forms.ToolStripMenuItem Alarm;
    private System.Windows.Forms.ContextMenuStrip FeedUnitsContextMenu;
    private System.Windows.Forms.ToolStripMenuItem FeedUnitInches;
    private System.Windows.Forms.ToolStripMenuItem FeedUnitMillimeters;
    private System.Windows.Forms.ContextMenuStrip CoordinateContextMenu;
    private System.Windows.Forms.ToolStripMenuItem WPos;
    private System.Windows.Forms.ToolStripMenuItem MPos;
    private System.Windows.Forms.Timer TrackTimer;
    private System.Windows.Forms.ToolTip AlarmTip;
    private System.Windows.Forms.ToolTip ErrorTip;
    private System.Windows.Forms.Timer BlinkTimer;
  }
}
