using System;
using System.Windows.Forms;
using CamBam.CAM;
using CamBam.Library;
using CamBam.UI;
using CamBam.Extensions;
using CamBam.CAD;

namespace GRBLMachine.UI
{
  public partial class ToolChanger : Form
  {
    public ToolChanger()
    {
      InitializeComponent();

      if (!DesignMode && CamBamUI.MainUI != null && CamBamUI.MainUI.SystemTree != null)
      {
        ToolLibraryTree.ImageList = CamBamUI.MainUI.SystemTree.ImageList;
        ToolLibraryTree.Nodes.Clear();

        foreach (TreeNode root in CamBamUI.MainUI.SystemTree.Nodes)
        { 
          foreach (TreeNode node in root.Nodes)
          { 
            if (node.Tag is ToolLibraryCollection)
            {
              TreeNode newNode = node.Clone() as TreeNode;
              ToolLibraryTree.Nodes.Add(newNode);
            }
          }
          root.Expand();
        }
        ProductionExpander.JobStopped += ProductionExpander_JobStopped;
      }
    }

    public void SetToolFromGCODE(string toolGCODE)
    {
      if (toolGCODE != null)
      {
        string[] codesAndComment = toolGCODE.Split('(',')');

        if (codesAndComment.Length != 0)
        {
          string[]       codes = codesAndComment[0].Split(' ');
          int            index = -1;
          ToolDefinition def   = null;

          if (codesAndComment.Length > 2)
          {
            string[] partAndMop = codesAndComment[1].Split('\\');

            if (partAndMop.Length > 1)
            {
              foreach(CAMPart part in  CamBamUI.MainUI.CADFileTree.CADFile.Parts)
              {
                if (part.Name == partAndMop[0])
                {
                  foreach(MachineOp mop in part.MachineOps)
                  {
                    if (mop.Name == partAndMop[1])
                    {
                      def = mop.CurrentTool();

                      break;
                    }
                  }
                  break;
                }
              }
            }
          }

          if (def == null)
          {
            foreach (string s in codes)
              if (s.ToUpper().StartsWith("T"))
                if (int.TryParse(s.Substring(1),out index))
                  break;

            if (index != -1)
            {

            }
          }

          if (def == null)
          {
            def = CamBamUI.MainUI.ActiveTool();

            //ICADView view = CamBamUI.MainUI.ActiveView;

            //if (view != null && view.CADFile != null)
            //{
            //  CADFile file = view.CADFile;

            //  if (file.Parts != null && file.Parts.Count != 0)
            //    if (file.Parts[0].MachineOps != null && file.Parts[0].MachineOps.Count != 0)
            //      def = file.Parts[0].MachineOps[0].CurrentTool();
            //}

            if (def == null)
            {
              def =  new ToolDefinition();
              def.Diameter    = GRBLMachinePlugin.Props.DefaultToolDiameter;
              def.FluteLength = GRBLMachinePlugin.Props.DefaultToolFluteLength;
              def.ToolProfile = ToolProfiles.EndMill;
              def.Name        = "GRBLMachine Default";

              foreach (TreeNode root in this.ToolLibraryTree.Nodes)
                root.ExpandAll();
            }
          }

          TreeNode node  = new TreeNode("Current Tool",2,2) { Tag = def.Clone() };

          ToolLibraryTree  .Nodes.Insert(0,  node);
          ToolLibraryTree  .SelectedNode   = node;
          propertyInspector.SelectedObject = node.Tag;

          OK_Button.Enabled = Apply_Button.Enabled = true;
        }
      }

      /// do default

    }

    public ToolDefinition SelectedToolDefinition
    {
      get
      {
        return propertyInspector.SelectedObject as ToolDefinition;
      }
    }

    public delegate void ApplyHandler(ToolChanger changer, ToolDefinition tooldef);
    public event         ApplyHandler Applied;
    bool didZProbe = false;


    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      XPropertyGridMetrics m = propertyInspector.GetMetrics();
      m.ShowAdvanced         = false;
      didZProbe = false;

      propertyInspector.ApplyMetrics(m);

      OK_Button.Enabled = Apply_Button.Enabled = (didZProbe && propertyInspector.SelectedObject != null);
    }
    protected override void OnClosed(EventArgs e)
    {
      ProductionExpander.JobStopped -= ProductionExpander_JobStopped;

      base.OnClosed(e);
    }

    private void ProductionExpander_JobStopped()
    {
      Close();
    }

    private void ToolLibraryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      propertyInspector.SelectedObject = e.Node.Tag is ToolDefinition ? (e.Node.Tag as ToolDefinition).Clone() : null;

      OK_Button.Enabled = Apply_Button.Enabled = (didZProbe && propertyInspector.SelectedObject != null);
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void ApplyButton_Click(object sender, EventArgs e)
    {
      if (Applied != null)
        Applied(this, SelectedToolDefinition);
    }

    private void ZProbeButton_Click(object sender, EventArgs e) {
      ZProbe.ExecuteZProbe();
      didZProbe = true;
      OK_Button.Enabled = Apply_Button.Enabled = (didZProbe && propertyInspector.SelectedObject != null);
    }
  }
}
