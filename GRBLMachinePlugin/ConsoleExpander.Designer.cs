namespace GRBLMachine.UI
{
  partial class ConsoleExpander : Expander
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
      this.label1 = new System.Windows.Forms.Label();
      this.Command = new System.Windows.Forms.TextBox();
      this.LogMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.Freeze = new System.Windows.Forms.ToolStripMenuItem();
      this.Clear = new System.Windows.Forms.ToolStripMenuItem();
      this.Verbose = new System.Windows.Forms.ToolStripMenuItem();
      this.Console = new System.Windows.Forms.ListBox();
      this.ContentPanel.SuspendLayout();
      this.LogMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // ContentPanel
      // 
      this.ContentPanel.Controls.Add(this.Console);
      this.ContentPanel.Controls.Add(this.Command);
      this.ContentPanel.Controls.Add(this.label1);
      this.ContentPanel.Size = new System.Drawing.Size(363, 240);
      // 
      // HeaderLabel
      // 
      this.HeaderLabel.Text = "Console";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(75, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Command:";
      // 
      // Command
      // 
      this.Command.AcceptsReturn = true;
      this.Command.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.Command.Enabled = false;
      this.Command.Location = new System.Drawing.Point(93, 12);
      this.Command.Name = "Command";
      this.Command.Size = new System.Drawing.Size(267, 22);
      this.Command.TabIndex = 1;
      this.TheToolTip.SetToolTip(this.Command, "Enter a manual GRBL-CGODE command, send it by pressing <Enter>");
      this.Command.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Command_KeyDown);
      this.Command.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Command_KeyUp);
      // 
      // LogMenu
      // 
      this.LogMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.LogMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Freeze,
            this.Clear,
            this.Verbose});
      this.LogMenu.Name = "LogMenu";
      this.LogMenu.Size = new System.Drawing.Size(139, 82);
      // 
      // Freeze
      // 
      this.Freeze.CheckOnClick = true;
      this.Freeze.Name = "Freeze";
      this.Freeze.Size = new System.Drawing.Size(138, 26);
      this.Freeze.Text = "Freeze";
      // 
      // Clear
      // 
      this.Clear.Name = "Clear";
      this.Clear.Size = new System.Drawing.Size(138, 26);
      this.Clear.Text = "Clear";
      // 
      // Verbose
      // 
      this.Verbose.CheckOnClick = true;
      this.Verbose.Name = "Verbose";
      this.Verbose.Size = new System.Drawing.Size(138, 26);
      this.Verbose.Text = "Verbose";
      // 
      // Console
      // 
      this.Console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.Console.BackColor = System.Drawing.Color.Black;
      this.Console.ContextMenuStrip = this.LogMenu;
      this.Console.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.Console.ForeColor = System.Drawing.Color.Lime;
      this.Console.FormattingEnabled = true;
      this.Console.HorizontalScrollbar = true;
      this.Console.ItemHeight = 14;
      this.Console.Location = new System.Drawing.Point(12, 43);
      this.Console.Name = "Console";
      this.Console.Size = new System.Drawing.Size(348, 186);
      this.Console.TabIndex = 3;
      // 
      // ConsoleExpander
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.Name = "ConsoleExpander";
      this.Size = new System.Drawing.Size(380, 276);
      this.Controls.SetChildIndex(this.ContentPanel, 0);
      this.Controls.SetChildIndex(this.HeaderLabel, 0);
      this.ContentPanel.ResumeLayout(false);
      this.ContentPanel.PerformLayout();
      this.LogMenu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox Command;
    private System.Windows.Forms.ListBox Console;
    private System.Windows.Forms.ContextMenuStrip LogMenu;
    private System.Windows.Forms.ToolStripMenuItem Freeze;
    private System.Windows.Forms.ToolStripMenuItem Clear;
    private System.Windows.Forms.ToolStripMenuItem Verbose;
  }
}
