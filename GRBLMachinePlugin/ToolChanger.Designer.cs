namespace GRBLMachine.UI
{
  partial class ToolChanger
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
      System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
      System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node2");
      System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node3");
      System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Tool Libraries", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolChanger));
      this.propertyInspector = new CamBam.UI.XPropertyGrid();
      this.OK_Button = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.ToolLibraryTree = new System.Windows.Forms.TreeView();
      this.Apply_Button = new System.Windows.Forms.Button();
      this.Cancel_Button = new System.Windows.Forms.Button();
      this.ZProbeButton = new GRBLMachine.UI.GRBLButton();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // propertyInspector
      // 
      this.propertyInspector.BackColor = System.Drawing.SystemColors.Control;
      this.propertyInspector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.propertyInspector.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyInspector.Location = new System.Drawing.Point(0, 0);
      this.propertyInspector.Name = "propertyInspector";
      this.propertyInspector.SelectedObject = null;
      this.propertyInspector.SelectedObjects = null;
      this.propertyInspector.Size = new System.Drawing.Size(343, 251);
      this.propertyInspector.TabIndex = 0;
      // 
      // OK_Button
      // 
      this.OK_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.OK_Button.Enabled = false;
      this.OK_Button.Location = new System.Drawing.Point(349, 271);
      this.OK_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.OK_Button.Name = "OK_Button";
      this.OK_Button.Size = new System.Drawing.Size(57, 30);
      this.OK_Button.TabIndex = 1;
      this.OK_Button.Text = "OK";
      this.OK_Button.UseVisualStyleBackColor = true;
      this.OK_Button.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 280);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(245, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Please select Tool Properties and change the tool.";
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(13, 10);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.ToolLibraryTree);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.propertyInspector);
      this.splitContainer1.Size = new System.Drawing.Size(518, 251);
      this.splitContainer1.SplitterDistance = 172;
      this.splitContainer1.SplitterWidth = 3;
      this.splitContainer1.TabIndex = 4;
      // 
      // ToolLibraryTree
      // 
      this.ToolLibraryTree.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ToolLibraryTree.Location = new System.Drawing.Point(0, 0);
      this.ToolLibraryTree.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ToolLibraryTree.Name = "ToolLibraryTree";
      treeNode1.Name = "Node1";
      treeNode1.Text = "Node1";
      treeNode2.Name = "Node2";
      treeNode2.Text = "Node2";
      treeNode3.Name = "Node3";
      treeNode3.Text = "Node3";
      treeNode4.Name = "ToolLibraries";
      treeNode4.Text = "Tool Libraries";
      this.ToolLibraryTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
      this.ToolLibraryTree.Size = new System.Drawing.Size(172, 251);
      this.ToolLibraryTree.TabIndex = 0;
      this.ToolLibraryTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ToolLibraryTree_NodeMouseClick);
      // 
      // Apply_Button
      // 
      this.Apply_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Apply_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Apply_Button.Enabled = false;
      this.Apply_Button.Location = new System.Drawing.Point(472, 271);
      this.Apply_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.Apply_Button.Name = "Apply_Button";
      this.Apply_Button.Size = new System.Drawing.Size(59, 30);
      this.Apply_Button.TabIndex = 5;
      this.Apply_Button.Text = "Apply";
      this.Apply_Button.Click += new System.EventHandler(this.ApplyButton_Click);
      // 
      // Cancel_Button
      // 
      this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Cancel_Button.Location = new System.Drawing.Point(410, 271);
      this.Cancel_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.Cancel_Button.Name = "Cancel_Button";
      this.Cancel_Button.Size = new System.Drawing.Size(58, 30);
      this.Cancel_Button.TabIndex = 6;
      this.Cancel_Button.Text = "Cancel";
      this.Cancel_Button.UseVisualStyleBackColor = true;
      this.Cancel_Button.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // ZProbeButton
      // 
      this.ZProbeButton.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ZProbeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ZProbeButton.BackgroundImage")));
      this.ZProbeButton.BackgroundImageDisabled = global::GRBLMachine.Properties.Resources.media_stop_gray;
      this.ZProbeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ZProbeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ZProbeButton.ForeColor = System.Drawing.Color.Yellow;
      this.ZProbeButton.Location = new System.Drawing.Point(294, 272);
      this.ZProbeButton.Margin = new System.Windows.Forms.Padding(2);
      this.ZProbeButton.Name = "ZProbeButton";
      this.ZProbeButton.Size = new System.Drawing.Size(51, 29);
      this.ZProbeButton.TabIndex = 19;
      this.ZProbeButton.Text = "Z-PB";
      this.ZProbeButton.UseVisualStyleBackColor = false;
      this.ZProbeButton.Click += new System.EventHandler(this.ZProbeButton_Click);
      // 
      // ToolChanger
      // 
      this.AcceptButton = this.OK_Button;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(539, 311);
      this.Controls.Add(this.ZProbeButton);
      this.Controls.Add(this.Cancel_Button);
      this.Controls.Add(this.Apply_Button);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.OK_Button);
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.Name = "ToolChanger";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ToolChanger";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private CamBam.UI.XPropertyGrid propertyInspector;
    private System.Windows.Forms.Button OK_Button;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TreeView ToolLibraryTree;
    private System.Windows.Forms.Button Apply_Button;
    private System.Windows.Forms.Button Cancel_Button;
    private GRBLButton ZProbeButton;
  }
}