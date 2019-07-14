namespace GRBLMachine.UI
{
  partial class ConnectionExpander : Expander
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
      this.COMPort = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.Baudrate = new System.Windows.Forms.ComboBox();
      this.RefreshButton = new GRBLMachine.UI.GRBLButton();
      this.AutoConnect = new System.Windows.Forms.CheckBox();
      this.ConnectButton = new GRBLMachine.UI.GRBLButton();
      this.ThePort = new System.IO.Ports.SerialPort(this.components);
      this.StatusTimer = new System.Windows.Forms.Timer(this.components);
      this.label3 = new System.Windows.Forms.Label();
      this.VersionLabel = new System.Windows.Forms.Label();
      this.ContentPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // ContentPanel
      // 
      this.ContentPanel.Controls.Add(this.VersionLabel);
      this.ContentPanel.Controls.Add(this.label3);
      this.ContentPanel.Controls.Add(this.ConnectButton);
      this.ContentPanel.Controls.Add(this.AutoConnect);
      this.ContentPanel.Controls.Add(this.RefreshButton);
      this.ContentPanel.Controls.Add(this.Baudrate);
      this.ContentPanel.Controls.Add(this.label2);
      this.ContentPanel.Controls.Add(this.label1);
      this.ContentPanel.Controls.Add(this.COMPort);
      this.ContentPanel.Size = new System.Drawing.Size(272, 129);
      // 
      // HeaderLabel
      // 
      this.HeaderLabel.Text = "Connection";
      // 
      // COMPort
      // 
      this.COMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.COMPort.FormattingEnabled = true;
      this.COMPort.Location = new System.Drawing.Point(78, 11);
      this.COMPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.COMPort.Name = "COMPort";
      this.COMPort.Size = new System.Drawing.Size(92, 21);
      this.COMPort.TabIndex = 1;
      this.TheToolTip.SetToolTip(this.COMPort, "Select the COM port to which your GRBL machine is connected");
      this.COMPort.SelectionChangeCommitted += new System.EventHandler(this.COMPort_SelectionChangeCommitted);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 13);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(29, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Port:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 39);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Baudrate:";
      // 
      // Baudrate
      // 
      this.Baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Baudrate.FormattingEnabled = true;
      this.Baudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
      this.Baudrate.Location = new System.Drawing.Point(78, 37);
      this.Baudrate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.Baudrate.Name = "Baudrate";
      this.Baudrate.Size = new System.Drawing.Size(92, 21);
      this.Baudrate.TabIndex = 2;
      this.TheToolTip.SetToolTip(this.Baudrate, "Select the baudrate at which your GRBL machine is communicating");
      this.Baudrate.SelectionChangeCommitted += new System.EventHandler(this.Baudrate_SelectionChangeCommitted);
      // 
      // RefreshButton
      // 
      this.RefreshButton.BackgroundImage = global::GRBLMachine.Properties.Resources.refresh;
      this.RefreshButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.refresh_gray;
      this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.RefreshButton.Location = new System.Drawing.Point(173, 10);
      this.RefreshButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.RefreshButton.Name = "RefreshButton";
      this.RefreshButton.Size = new System.Drawing.Size(18, 20);
      this.RefreshButton.TabIndex = 0;
      this.RefreshButton.TabStop = false;
      this.TheToolTip.SetToolTip(this.RefreshButton, "Refresh the COM port list");
      this.RefreshButton.UseVisualStyleBackColor = true;
      this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
      // 
      // AutoConnect
      // 
      this.AutoConnect.AutoSize = true;
      this.AutoConnect.Location = new System.Drawing.Point(78, 61);
      this.AutoConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.AutoConnect.Name = "AutoConnect";
      this.AutoConnect.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.AutoConnect.Size = new System.Drawing.Size(90, 17);
      this.AutoConnect.TabIndex = 3;
      this.AutoConnect.Text = "Auto connect";
      this.TheToolTip.SetToolTip(this.AutoConnect, "Connect to your GRBL machine when CamBam is started");
      this.AutoConnect.UseVisualStyleBackColor = true;
      // 
      // ConnectButton
      // 
      this.ConnectButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ConnectButton.BackgroundImage = global::GRBLMachine.Properties.Resources.media_stop;
      this.ConnectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ConnectButton.ForeColor = System.Drawing.Color.Yellow;
      this.ConnectButton.Location = new System.Drawing.Point(78, 83);
      this.ConnectButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ConnectButton.Name = "ConnectButton";
      this.ConnectButton.Size = new System.Drawing.Size(91, 29);
      this.ConnectButton.TabIndex = 4;
      this.ConnectButton.Text = "Connect";
      this.ConnectButton.UseVisualStyleBackColor = false;
      this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
      // 
      // ThePort
      // 
      this.ThePort.BaudRate = 115200;
      this.ThePort.DtrEnable = true;
      // 
      // StatusTimer
      // 
      this.StatusTimer.Interval = 200;
      this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(173, 91);
      this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(66, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Grbl version:";
      // 
      // VersionLabel
      // 
      this.VersionLabel.AutoSize = true;
      this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.VersionLabel.Location = new System.Drawing.Point(237, 91);
      this.VersionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.VersionLabel.Name = "VersionLabel";
      this.VersionLabel.Size = new System.Drawing.Size(19, 13);
      this.VersionLabel.TabIndex = 6;
      this.VersionLabel.Text = "-.-";
      // 
      // ConnectionExpander
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScroll = true;
      this.MinimumSize = new System.Drawing.Size(214, 0);
      this.Name = "ConnectionExpander";
      this.Size = new System.Drawing.Size(285, 158);
      this.ContentPanel.ResumeLayout(false);
      this.ContentPanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private GRBLButton RefreshButton;
    private System.Windows.Forms.ComboBox Baudrate;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox COMPort;
    private GRBLButton ConnectButton;
    private System.Windows.Forms.CheckBox AutoConnect;
    private System.IO.Ports.SerialPort ThePort;
    private System.Windows.Forms.Timer StatusTimer;
    private System.Windows.Forms.Label VersionLabel;
    private System.Windows.Forms.Label label3;
  }
}
