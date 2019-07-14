namespace GRBLMachine.UI
{
  partial class GRBLMachinePage : System.Windows.Forms.UserControl
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
      this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
      this.DisplayExpander = new GRBLMachine.UI.DisplayExpander();
      this.ProductionExpander = new GRBLMachine.UI.ProductionExpander();
      this.JoggingExpander = new GRBLMachine.UI.JoggingExpander();
      this.ConnectionExpander = new GRBLMachine.UI.ConnectionExpander();
      this.ConsoleExpander = new GRBLMachine.UI.ConsoleExpander();
      this.AboutExpander = new GRBLMachine.UI.AboutExpander();
      this.TableLayout.SuspendLayout();
      this.SuspendLayout();
      // 
      // TableLayout
      // 
      this.TableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TableLayout.AutoSize = true;
      this.TableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.TableLayout.ColumnCount = 1;
      this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TableLayout.Controls.Add(this.DisplayExpander, 0, 3);
      this.TableLayout.Controls.Add(this.ProductionExpander, 0, 4);
      this.TableLayout.Controls.Add(this.JoggingExpander, 0, 5);
      this.TableLayout.Controls.Add(this.ConnectionExpander, 0, 7);
      this.TableLayout.Controls.Add(this.ConsoleExpander, 0, 6);
      this.TableLayout.Controls.Add(this.AboutExpander, 0, 8);
      this.TableLayout.Location = new System.Drawing.Point(0, 0);
      this.TableLayout.Margin = new System.Windows.Forms.Padding(0);
      this.TableLayout.Name = "TableLayout";
      this.TableLayout.RowCount = 9;
      this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.TableLayout.Size = new System.Drawing.Size(397, 1010);
      this.TableLayout.TabIndex = 2;
      // 
      // DisplayExpander
      // 
      this.DisplayExpander.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.DisplayExpander.AutoScroll = true;
      this.DisplayExpander.BackColor = System.Drawing.SystemColors.ControlDark;
      this.DisplayExpander.Location = new System.Drawing.Point(2, 2);
      this.DisplayExpander.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.DisplayExpander.MinimumSize = new System.Drawing.Size(380, 0);
      this.DisplayExpander.Name = "DisplayExpander";
      this.DisplayExpander.Size = new System.Drawing.Size(393, 176);
      this.DisplayExpander.TabIndex = 3;
      // 
      // ProductionExpander
      // 
      this.ProductionExpander.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ProductionExpander.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ProductionExpander.Expanded = false;
      this.ProductionExpander.Location = new System.Drawing.Point(2, 182);
      this.ProductionExpander.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ProductionExpander.MinimumSize = new System.Drawing.Size(380, 0);
      this.ProductionExpander.Name = "ProductionExpander";
      this.ProductionExpander.Size = new System.Drawing.Size(393, 98);
      this.ProductionExpander.TabIndex = 6;
      // 
      // JoggingExpander
      // 
      this.JoggingExpander.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.JoggingExpander.AutoScroll = true;
      this.JoggingExpander.BackColor = System.Drawing.SystemColors.ControlDark;
      this.JoggingExpander.Location = new System.Drawing.Point(2, 284);
      this.JoggingExpander.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.JoggingExpander.MinimumSize = new System.Drawing.Size(380, 0);
      this.JoggingExpander.Name = "JoggingExpander";
      this.JoggingExpander.Size = new System.Drawing.Size(393, 160);
      this.JoggingExpander.TabIndex = 2;
      // 
      // ConnectionExpander
      // 
      this.ConnectionExpander.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ConnectionExpander.AutoScroll = true;
      this.ConnectionExpander.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ConnectionExpander.Location = new System.Drawing.Point(2, 670);
      this.ConnectionExpander.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ConnectionExpander.MinimumSize = new System.Drawing.Size(380, 0);
      this.ConnectionExpander.Name = "ConnectionExpander";
      this.ConnectionExpander.Size = new System.Drawing.Size(393, 151);
      this.ConnectionExpander.TabIndex = 4;
      // 
      // ConsoleExpander
      // 
      this.ConsoleExpander.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ConsoleExpander.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ConsoleExpander.Expanded = false;
      this.ConsoleExpander.Location = new System.Drawing.Point(2, 448);
      this.ConsoleExpander.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ConsoleExpander.MinimumSize = new System.Drawing.Size(380, 0);
      this.ConsoleExpander.Name = "ConsoleExpander";
      this.ConsoleExpander.Size = new System.Drawing.Size(393, 218);
      this.ConsoleExpander.TabIndex = 5;
      // 
      // AboutExpander
      // 
      this.AboutExpander.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.AboutExpander.BackColor = System.Drawing.SystemColors.ControlDark;
      this.AboutExpander.Expanded = false;
      this.AboutExpander.Location = new System.Drawing.Point(2, 825);
      this.AboutExpander.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.AboutExpander.MinimumSize = new System.Drawing.Size(380, 0);
      this.AboutExpander.Name = "AboutExpander";
      this.AboutExpander.Size = new System.Drawing.Size(393, 183);
      this.AboutExpander.TabIndex = 7;
      // 
      // GRBLMachinePage
      // 
      this.AutoScroll = true;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Controls.Add(this.TableLayout);
      this.DoubleBuffered = true;
      this.Margin = new System.Windows.Forms.Padding(0);
      this.MinimumSize = new System.Drawing.Size(400, 0);
      this.Name = "GRBLMachinePage";
      this.Size = new System.Drawing.Size(400, 1010);
      this.TableLayout.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TableLayoutPanel TableLayout;
    public DisplayExpander DisplayExpander;
    public ProductionExpander ProductionExpander;
    public JoggingExpander JoggingExpander;
    public ConnectionExpander ConnectionExpander;
    public ConsoleExpander ConsoleExpander;
    public AboutExpander AboutExpander;
  }
}
