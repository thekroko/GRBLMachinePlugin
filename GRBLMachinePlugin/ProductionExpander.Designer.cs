namespace GRBLMachine.UI
{
  partial class ProductionExpander : Expander
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
      this.label1 = new System.Windows.Forms.Label();
      this.FileName = new System.Windows.Forms.TextBox();
      this.BrowseButton = new GRBLMachine.UI.GRBLButton();
      this.PlayButton = new GRBLMachine.UI.GRBLButton();
      this.PauseButton = new GRBLMachine.UI.GRBLButton();
      this.StopButton = new GRBLMachine.UI.GRBLButton();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.LinesTotal = new System.Windows.Forms.Label();
      this.LinesSent = new System.Windows.Forms.Label();
      this.ToolChangeButton = new GRBLMachine.UI.GRBLButton();
      this.ContentPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // ContentPanel
      // 
      this.ContentPanel.Controls.Add(this.ToolChangeButton);
      this.ContentPanel.Controls.Add(this.LinesSent);
      this.ContentPanel.Controls.Add(this.LinesTotal);
      this.ContentPanel.Controls.Add(this.label3);
      this.ContentPanel.Controls.Add(this.label2);
      this.ContentPanel.Controls.Add(this.StopButton);
      this.ContentPanel.Controls.Add(this.PauseButton);
      this.ContentPanel.Controls.Add(this.PlayButton);
      this.ContentPanel.Controls.Add(this.BrowseButton);
      this.ContentPanel.Controls.Add(this.FileName);
      this.ContentPanel.Controls.Add(this.label1);
      this.ContentPanel.Size = new System.Drawing.Size(272, 78);
      // 
      // HeaderLabel
      // 
      this.HeaderLabel.Text = "Production";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 13);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(26, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "File:";
      // 
      // FileName
      // 
      this.FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.FileName.Location = new System.Drawing.Point(39, 11);
      this.FileName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.FileName.Name = "FileName";
      this.FileName.Size = new System.Drawing.Size(204, 20);
      this.FileName.TabIndex = 1;
      this.TheToolTip.SetToolTip(this.FileName, "Enter the filename containing GCODE to send to your GRBL Machine");
      this.FileName.TextChanged += new System.EventHandler(this.FileName_TextChanged);
      // 
      // BrowseButton
      // 
      this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BrowseButton.BackgroundImage = global::GRBLMachine.Properties.Resources.folder;
      this.BrowseButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.folder_gray;
      this.BrowseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.BrowseButton.Location = new System.Drawing.Point(247, 11);
      this.BrowseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.BrowseButton.Name = "BrowseButton";
      this.BrowseButton.Size = new System.Drawing.Size(16, 18);
      this.BrowseButton.TabIndex = 2;
      this.TheToolTip.SetToolTip(this.BrowseButton, "Browse your computer for GCODE files");
      this.BrowseButton.UseVisualStyleBackColor = true;
      this.BrowseButton.Click += new System.EventHandler(this.Browse_Click);
      // 
      // PlayButton
      // 
      this.PlayButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.PlayButton.BackgroundImage = global::GRBLMachine.Properties.Resources.media_play;
      this.PlayButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_play_gray;
      this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.PlayButton.Enabled = false;
      this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PlayButton.ForeColor = System.Drawing.Color.Yellow;
      this.PlayButton.Location = new System.Drawing.Point(39, 34);
      this.PlayButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.PlayButton.Name = "PlayButton";
      this.PlayButton.Size = new System.Drawing.Size(27, 29);
      this.PlayButton.TabIndex = 3;
      this.TheToolTip.SetToolTip(this.PlayButton, "Send the GCODE job to your GRBL machine");
      this.PlayButton.UseVisualStyleBackColor = false;
      this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
      // 
      // PauseButton
      // 
      this.PauseButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.PauseButton.BackgroundImage = global::GRBLMachine.Properties.Resources.media_pause;
      this.PauseButton.BackgroundImageChecked = global::GRBLMachine.Properties.Resources.media_play_green;
      this.PauseButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_pause_gray;
      this.PauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.PauseButton.Enabled = false;
      this.PauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PauseButton.ForeColor = System.Drawing.Color.Yellow;
      this.PauseButton.Location = new System.Drawing.Point(70, 34);
      this.PauseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.PauseButton.Name = "PauseButton";
      this.PauseButton.Size = new System.Drawing.Size(27, 29);
      this.PauseButton.TabIndex = 4;
      this.PauseButton.ToggleButton = true;
      this.TheToolTip.SetToolTip(this.PauseButton, "Pause/Resume the current CGODE job");
      this.PauseButton.UseVisualStyleBackColor = false;
      this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
      // 
      // StopButton
      // 
      this.StopButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.StopButton.BackgroundImage = global::GRBLMachine.Properties.Resources.media_stop;
      this.StopButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.StopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.StopButton.Enabled = false;
      this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.StopButton.ForeColor = System.Drawing.Color.Yellow;
      this.StopButton.Location = new System.Drawing.Point(102, 34);
      this.StopButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.StopButton.Name = "StopButton";
      this.StopButton.Size = new System.Drawing.Size(27, 29);
      this.StopButton.TabIndex = 5;
      this.TheToolTip.SetToolTip(this.StopButton, "Stop and Cancel the current CGODE job");
      this.StopButton.UseVisualStyleBackColor = false;
      this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(162, 34);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(58, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Lines total:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(162, 50);
      this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(58, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Lines sent:";
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // LinesTotal
      // 
      this.LinesTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.LinesTotal.Location = new System.Drawing.Point(216, 34);
      this.LinesTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.LinesTotal.Name = "LinesTotal";
      this.LinesTotal.Size = new System.Drawing.Size(51, 19);
      this.LinesTotal.TabIndex = 8;
      this.LinesTotal.Text = "0";
      this.LinesTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // LinesSent
      // 
      this.LinesSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.LinesSent.Location = new System.Drawing.Point(220, 50);
      this.LinesSent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.LinesSent.Name = "LinesSent";
      this.LinesSent.Size = new System.Drawing.Size(47, 19);
      this.LinesSent.TabIndex = 9;
      this.LinesSent.Text = "0";
      this.LinesSent.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // ToolChangeButton
      // 
      this.ToolChangeButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ToolChangeButton.BackgroundImage = global::GRBLMachine.Properties.Resources.toolbox;
      this.ToolChangeButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.toolbox_gray;
      this.ToolChangeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.ToolChangeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ToolChangeButton.ForeColor = System.Drawing.Color.Yellow;
      this.ToolChangeButton.Location = new System.Drawing.Point(134, 34);
      this.ToolChangeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ToolChangeButton.Name = "ToolChangeButton";
      this.ToolChangeButton.Size = new System.Drawing.Size(27, 29);
      this.ToolChangeButton.TabIndex = 10;
      this.TheToolTip.SetToolTip(this.ToolChangeButton, "Start a Tool Change");
      this.ToolChangeButton.UseVisualStyleBackColor = false;
      this.ToolChangeButton.Click += new System.EventHandler(this.ToolChangeButton_Click);
      // 
      // ProductionExpander
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.MinimumSize = new System.Drawing.Size(214, 0);
      this.Name = "ProductionExpander";
      this.Size = new System.Drawing.Size(285, 107);
      this.ContentPanel.ResumeLayout(false);
      this.ContentPanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private GRBLButton BrowseButton;
    private System.Windows.Forms.TextBox FileName;
    private System.Windows.Forms.Label label1;
    private GRBLButton StopButton;
    private GRBLButton PauseButton;
    private GRBLButton PlayButton;
    private System.Windows.Forms.Label LinesSent;
    private System.Windows.Forms.Label LinesTotal;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private GRBLButton ToolChangeButton;
  }
}
