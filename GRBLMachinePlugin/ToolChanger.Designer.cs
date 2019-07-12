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
      this.propertyInspector = new CamBam.UI.XPropertyGrid();
      this.OK_Button = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.ToolLibraryTree = new System.Windows.Forms.TreeView();
      this.Apply_Button = new System.Windows.Forms.Button();
      this.Cancel_Button = new System.Windows.Forms.Button();
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
      this.propertyInspector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.propertyInspector.Name = "propertyInspector";
      this.propertyInspector.SelectedObject = null;
      this.propertyInspector.SelectedObjects = null;
      this.propertyInspector.Size = new System.Drawing.Size(456, 309);
      this.propertyInspector.TabIndex = 0;
      // 
      // OK_Button
      // 
      this.OK_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.OK_Button.Enabled = false;
      this.OK_Button.Location = new System.Drawing.Point(401, 334);
      this.OK_Button.Name = "OK_Button";
      this.OK_Button.Size = new System.Drawing.Size(98, 37);
      this.OK_Button.TabIndex = 1;
      this.OK_Button.Text = "OK";
      this.OK_Button.UseVisualStyleBackColor = true;
      this.OK_Button.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(14, 344);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(327, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Please select Tool Properties and change the tool.";
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(17, 12);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.ToolLibraryTree);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.propertyInspector);
      this.splitContainer1.Size = new System.Drawing.Size(690, 309);
      this.splitContainer1.SplitterDistance = 230;
      this.splitContainer1.TabIndex = 4;
      // 
      // ToolLibraryTree
      // 
      this.ToolLibraryTree.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ToolLibraryTree.Location = new System.Drawing.Point(0, 0);
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
      this.ToolLibraryTree.Size = new System.Drawing.Size(230, 309);
      this.ToolLibraryTree.TabIndex = 0;
      this.ToolLibraryTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ToolLibraryTree_NodeMouseClick);
      // 
      // Apply_Button
      // 
      this.Apply_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Apply_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Apply_Button.Enabled = false;
      this.Apply_Button.Location = new System.Drawing.Point(609, 334);
      this.Apply_Button.Name = "Apply_Button";
      this.Apply_Button.Size = new System.Drawing.Size(98, 37);
      this.Apply_Button.TabIndex = 5;
      this.Apply_Button.Text = "Apply";
      this.Apply_Button.Click += new System.EventHandler(this.ApplyButton_Click);
      // 
      // Cancel_Button
      // 
      this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Cancel_Button.Location = new System.Drawing.Point(505, 334);
      this.Cancel_Button.Name = "Cancel_Button";
      this.Cancel_Button.Size = new System.Drawing.Size(98, 37);
      this.Cancel_Button.TabIndex = 6;
      this.Cancel_Button.Text = "Cancel";
      this.Cancel_Button.UseVisualStyleBackColor = true;
      this.Cancel_Button.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // ToolChanger
      // 
      this.AcceptButton = this.OK_Button;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(719, 383);
      this.Controls.Add(this.Cancel_Button);
      this.Controls.Add(this.Apply_Button);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.OK_Button);
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
  }
}