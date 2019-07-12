namespace CamBam.CAD.Solids.UI
{
  partial class DrawSolidForm
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
      this.Cancel_Button = new System.Windows.Forms.Button();
      this.Apply_Button = new System.Windows.Forms.Button();
      this.OK_Button = new System.Windows.Forms.Button();
      this.ContentGroup = new System.Windows.Forms.GroupBox();
      this.ContentPanel = new System.Windows.Forms.Panel();
      this.TheToolTip = new System.Windows.Forms.ToolTip(this.components);
      this.AsSurface = new System.Windows.Forms.CheckBox();
      this.LayerCombo = new System.Windows.Forms.ComboBox();
      this.LayerLabel = new System.Windows.Forms.Label();
      this.ContentGroup.SuspendLayout();
      this.SuspendLayout();
      // 
      // Cancel_Button
      // 
      this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Cancel_Button.Location = new System.Drawing.Point(241, 256);
      this.Cancel_Button.Name = "Cancel_Button";
      this.Cancel_Button.Size = new System.Drawing.Size(98, 37);
      this.Cancel_Button.TabIndex = 9;
      this.Cancel_Button.Text = "Cancel";
      this.TheToolTip.SetToolTip(this.Cancel_Button, "Cancel drawing and close this dialog.");
      this.Cancel_Button.UseVisualStyleBackColor = true;
      this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
      // 
      // Apply_Button
      // 
      this.Apply_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Apply_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Apply_Button.Location = new System.Drawing.Point(345, 256);
      this.Apply_Button.Name = "Apply_Button";
      this.Apply_Button.Size = new System.Drawing.Size(98, 37);
      this.Apply_Button.TabIndex = 8;
      this.Apply_Button.Text = "Apply";
      this.TheToolTip.SetToolTip(this.Apply_Button, "Draw the Solid in the View and leave this dialog open.");
      this.Apply_Button.Click += new System.EventHandler(this.Apply_Button_Click);
      // 
      // OK_Button
      // 
      this.OK_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.OK_Button.Location = new System.Drawing.Point(137, 256);
      this.OK_Button.Name = "OK_Button";
      this.OK_Button.Size = new System.Drawing.Size(98, 37);
      this.OK_Button.TabIndex = 7;
      this.OK_Button.Text = "OK";
      this.TheToolTip.SetToolTip(this.OK_Button, "Draw the Solid in the View and close this dialog.");
      this.OK_Button.UseVisualStyleBackColor = true;
      this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
      // 
      // ContentGroup
      // 
      this.ContentGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ContentGroup.AutoSize = true;
      this.ContentGroup.Controls.Add(this.ContentPanel);
      this.ContentGroup.ForeColor = System.Drawing.Color.RoyalBlue;
      this.ContentGroup.Location = new System.Drawing.Point(12, 12);
      this.ContentGroup.MinimumSize = new System.Drawing.Size(308, 55);
      this.ContentGroup.Name = "ContentGroup";
      this.ContentGroup.Padding = new System.Windows.Forms.Padding(10);
      this.ContentGroup.Size = new System.Drawing.Size(431, 170);
      this.ContentGroup.TabIndex = 10;
      this.ContentGroup.TabStop = false;
      this.ContentGroup.Text = "{0} Properties";
      // 
      // ContentPanel
      // 
      this.ContentPanel.AutoSize = true;
      this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ContentPanel.Location = new System.Drawing.Point(10, 25);
      this.ContentPanel.Name = "ContentPanel";
      this.ContentPanel.Size = new System.Drawing.Size(411, 135);
      this.ContentPanel.TabIndex = 0;
      // 
      // AsSurface
      // 
      this.AsSurface.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.AsSurface.AutoSize = true;
      this.AsSurface.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.AsSurface.Location = new System.Drawing.Point(274, 187);
      this.AsSurface.Name = "AsSurface";
      this.AsSurface.Size = new System.Drawing.Size(169, 21);
      this.AsSurface.TabIndex = 11;
      this.AsSurface.Text = "Draw Solid as Surface";
      this.TheToolTip.SetToolTip(this.AsSurface, "When Checked, the Solid will be drawn as a plain Surface.");
      this.AsSurface.UseVisualStyleBackColor = true;
      // 
      // LayerCombo
      // 
      this.LayerCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.LayerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.LayerCombo.FormattingEnabled = true;
      this.LayerCombo.Location = new System.Drawing.Point(274, 214);
      this.LayerCombo.Name = "LayerCombo";
      this.LayerCombo.Size = new System.Drawing.Size(169, 24);
      this.LayerCombo.TabIndex = 12;
      // 
      // LayerLabel
      // 
      this.LayerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.LayerLabel.AutoSize = true;
      this.LayerLabel.Location = new System.Drawing.Point(222, 217);
      this.LayerLabel.Name = "LayerLabel";
      this.LayerLabel.Size = new System.Drawing.Size(48, 17);
      this.LayerLabel.TabIndex = 13;
      this.LayerLabel.Text = "Layer:";
      // 
      // DrawSolidForm
      // 
      this.AcceptButton = this.OK_Button;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.CancelButton = this.OK_Button;
      this.ClientSize = new System.Drawing.Size(455, 305);
      this.Controls.Add(this.LayerLabel);
      this.Controls.Add(this.LayerCombo);
      this.Controls.Add(this.AsSurface);
      this.Controls.Add(this.ContentGroup);
      this.Controls.Add(this.Cancel_Button);
      this.Controls.Add(this.Apply_Button);
      this.Controls.Add(this.OK_Button);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(350, 220);
      this.Name = "DrawSolidForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Draw a \'{0}\' Solid";
      this.ContentGroup.ResumeLayout(false);
      this.ContentGroup.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button Cancel_Button;
    private System.Windows.Forms.Button Apply_Button;
    private System.Windows.Forms.Button OK_Button;
    private System.Windows.Forms.GroupBox ContentGroup;
    private System.Windows.Forms.ToolTip TheToolTip;
    private System.Windows.Forms.CheckBox AsSurface;
    private System.Windows.Forms.ComboBox LayerCombo;
    private System.Windows.Forms.Label LayerLabel;
    private System.Windows.Forms.Panel ContentPanel;
  }
}