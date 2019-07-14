namespace PluginTest {
  partial class TestForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.grblMachinePage1 = new GRBLMachine.UI.GRBLMachinePage();
      this.SuspendLayout();
      // 
      // grblMachinePage1
      // 
      this.grblMachinePage1.AutoScroll = true;
      this.grblMachinePage1.AutoSize = true;
      this.grblMachinePage1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.grblMachinePage1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grblMachinePage1.Location = new System.Drawing.Point(0, 0);
      this.grblMachinePage1.Margin = new System.Windows.Forms.Padding(0);
      this.grblMachinePage1.MinimumSize = new System.Drawing.Size(400, 0);
      this.grblMachinePage1.Name = "grblMachinePage1";
      this.grblMachinePage1.Size = new System.Drawing.Size(467, 711);
      this.grblMachinePage1.TabIndex = 0;
      // 
      // TestForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(467, 711);
      this.Controls.Add(this.grblMachinePage1);
      this.Name = "TestForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "TestForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private GRBLMachine.UI.GRBLMachinePage grblMachinePage1;
  }
}