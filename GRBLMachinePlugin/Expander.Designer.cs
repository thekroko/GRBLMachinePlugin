namespace GRBLMachine.UI
{
  partial class Expander : System.Windows.Forms.UserControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Expander));
      this.ContentPanel = new System.Windows.Forms.Panel();
      this.ChevronImageList = new System.Windows.Forms.ImageList(this.components);
      this.HeaderLabel = new System.Windows.Forms.Label();
      this.TheToolTip = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // ContentPanel
      // 
      this.ContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
      this.ContentPanel.Location = new System.Drawing.Point(14, 33);
      this.ContentPanel.Name = "ContentPanel";
      this.ContentPanel.Size = new System.Drawing.Size(363, 112);
      this.ContentPanel.TabIndex = 0;
      // 
      // ChevronImageList
      // 
      this.ChevronImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ChevronImageList.ImageStream")));
      this.ChevronImageList.TransparentColor = System.Drawing.Color.Transparent;
      this.ChevronImageList.Images.SetKeyName(0, "navigate_minus.png");
      this.ChevronImageList.Images.SetKeyName(1, "navigate_plus.png");
      // 
      // HeaderLabel
      // 
      this.HeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.HeaderLabel.BackColor = System.Drawing.SystemColors.ControlDark;
      this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.HeaderLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.HeaderLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.HeaderLabel.ImageIndex = 0;
      this.HeaderLabel.ImageList = this.ChevronImageList;
      this.HeaderLabel.Location = new System.Drawing.Point(0, 0);
      this.HeaderLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.HeaderLabel.Name = "HeaderLabel";
      this.HeaderLabel.Size = new System.Drawing.Size(380, 23);
      this.HeaderLabel.TabIndex = 1;
      this.HeaderLabel.Text = "Header";
      this.HeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.HeaderLabel.Click += new System.EventHandler(this.HeaderLabel_Click);
      // 
      // Expander
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlDark;
      this.Controls.Add(this.HeaderLabel);
      this.Controls.Add(this.ContentPanel);
      this.DoubleBuffered = true;
      this.MinimumSize = new System.Drawing.Size(380, 0);
      this.Name = "Expander";
      this.Size = new System.Drawing.Size(380, 150);
      this.ResumeLayout(false);

    }

    #endregion
    protected System.Windows.Forms.Panel ContentPanel;
    protected System.Windows.Forms.Label HeaderLabel;
    private System.Windows.Forms.ImageList ChevronImageList;
    protected System.Windows.Forms.ToolTip TheToolTip;
  }
}
