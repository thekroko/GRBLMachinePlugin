using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CamBam;
using CamBam.CAM;
using CamBam.Geom;
using CamBam.UI;
using CamBam.Library;
using CamBam.Extensions;
using GRBLMachine.Utils;
using System.Media;
using System.Globalization;

namespace GRBLMachine.UI
{
  public partial class ProductionExpander : Expander
  {
    private const  string                   V1JOG             = "$J=";
    private        string                   _jogLeadIn        = null;

    private string                         _lastOutfile       = "";
    private bool                           _connected;
    private LinkedList<string>             _fileData          = new LinkedList<string>();
    private Thread                         _writeThread;
    private ManualResetEvent               _pauseEvent        = new ManualResetEvent(true);
    private ManualResetEvent               _toolChangingEvent = new ManualResetEvent(true);
    private bool                           _toolChanging;
    private ManualResetEvent               _toolChangerEvent  = new ManualResetEvent(false);

    private string                         _sendingFileName;

    private double                         _lastX;
    private double                         _lastY;
    private double                         _lastZ;
    private int                            _lastSpeed;
    private PosType                        _lastType;
    private GRBLMachinePlugin.MachineState _lastState;

    private double                         _WCO_X;
    private double                         _WCO_Y;
    private double                         _WCO_Z;

    private double                         _preChangeX;
    private double                         _preChangeY;
    private double                         _preChangeZ;
    private int                            _preChangeSpeed;
    private PosType                        _preChangeType;


    private static HashSet<string>         _unsupportedGCODEs     = new HashSet<string>();
    private static HashSet<string>         _noRemoveCommentGCODEs = new HashSet<string>();
    private static CultureInfo              EN_US                 = new CultureInfo("en-US");

    static ProductionExpander()
    {
      _unsupportedGCODEs    .Add("G40");
      _unsupportedGCODEs    .Add("G41");
      _unsupportedGCODEs    .Add("G64");
      _unsupportedGCODEs    .Add("G81");
      _unsupportedGCODEs    .Add("G83");
      _unsupportedGCODEs    .Add("G91.1");

      _noRemoveCommentGCODEs.Add("M6");
      _noRemoveCommentGCODEs.Add("T");
    }

    public ProductionExpander()
    {
      InitializeComponent();

      if (!DesignMode)
        Application     .Idle         += Application_Idle;

      ConnectionExpander.Connected    += ConnectionExpander_Connected;
      ConnectionExpander.Disconnected += ConnectionExpander_Disconnected;

      GRBLMachinePlugin .Responding   += GRBLMachinePlugin_Responding;
      GRBLMachinePlugin .Position     += GRBLMachinePlugin_Position;
      GRBLMachinePlugin .Speed        += GRBLMachinePlugin_Speed;
      GRBLMachinePlugin. State        += GRBLMachinePlugin_State;
    }

#region Publics 

    public        delegate void JobHandler();
    public static event         JobHandler JobStarted;
    public static event         JobHandler JobPaused;
    public static event         JobHandler JobResumed;
    public static event         JobHandler JobStopped;

    public        delegate void ToolChangeHandler();
    public static event         ToolChangeHandler ToolChangeStarted;
    public static event         ToolChangeHandler ToolChangeEnded;

    public        delegate void ToolChangedHandler(ToolDefinition tooldef);
    public static event         ToolChangedHandler ToolChanged;

#endregion // Publics

#region Overrides

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (!DesignMode && ThisApplication.TopWindow != null)
        ThisApplication.TopWindow.FormClosing += TopWindow_FormClosing;
    }

#endregion // Overrides

#region Privates

    private bool CheckState()
    {
      if (_lastState == GRBLMachinePlugin.MachineState.Alarm || _lastState == GRBLMachinePlugin.MachineState.Hold)
      {
        MessageBox.Show("Machine is in " + _lastState.ToString().ToUpper() + " state.\r\n\r\n Please reset state and try again.","GRBLMachine - Play", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return false;
      }

      return true;
    }

    private void EnableButtons()
    {
      PlayButton      .Enabled = CanPlay      ();
      PauseButton     .Enabled = CanPause     ();
      StopButton      .Enabled = CanStop      ();
      ToolChangeButton.Enabled = CanToolChange();
    }

    private void ToolChangeStart()
    {
      _toolChangingEvent.Reset();

      InvokeOnUI(() =>
      {
        _toolChanging = true;

        EnableButtons();

        if (ToolChangeStarted!= null)
          ToolChangeStarted();
      });
    }

    private void ToolChangeEnd()
    {
      InvokeOnUI(() =>
      {
        _toolChanging = false;

        if (ToolChangeEnded!= null)
          ToolChangeEnded();

        EnableButtons();
      });

      _toolChangingEvent.Set();
    }

    private void ToolChange(ToolDefinition tooldef)
    {
      if (ToolChanged != null)
        ToolChanged(tooldef);
    }

    private bool CanPlay()
    {
      return  _connected                          && 
             !string.IsNullOrEmpty(FileName.Text) && 
              File.Exists(FileName.Text)          && 
              _writeThread == null                && 
             !_toolChanging;
    }

    private bool CanPause()
    {
      return  _connected           && 
              _writeThread != null && 
             !_toolChanging;
    }

    private bool CanStop()
    {
      return  _connected           && 
              _writeThread != null && 
             ! PauseButton.Checked &&
             !_toolChanging;
    }

    private bool CanToolChange()
    {
      return  _connected    &&
             !_toolChanging;
    }

    private void WaitIdle()
    {
      while (!ConnectionExpander.IsCOMPortIdle)
        Thread.Sleep(100);

      _lastState = GRBLMachinePlugin.MachineState.Jog;

      while (_lastState != GRBLMachinePlugin.MachineState.Idle)
        Thread.Sleep(100);
    }

    private void WaitHold()
    {
      _lastState = GRBLMachinePlugin.MachineState.Jog;

      while (_lastState != GRBLMachinePlugin.MachineState.Hold)
        Thread.Sleep(100);
    }

    private void Message(string message)
    {
      string m = message + Path.GetFileName(_sendingFileName);
      GRBLMachinePlugin.Log          ("\n" + m);
      ThisApplication  .AddLogMessage(       m);
    }

    private void JogToToolChangePosition()
    {
      GRBLProps props = GRBLMachinePlugin.Props;

      WaitIdle();

      _preChangeX     = _lastX.GetWorkOrMachinePosition(_lastType, _WCO_X, PosType.WorkCoordinates, props.ReportInInches, props.ReportInInches);
      _preChangeY     = _lastY.GetWorkOrMachinePosition(_lastType, _WCO_Y, PosType.WorkCoordinates, props.ReportInInches, props.ReportInInches);
      _preChangeZ     = _lastZ.GetWorkOrMachinePosition(_lastType, _WCO_Z, PosType.WorkCoordinates, props.ReportInInches, props.ReportInInches);
      _preChangeSpeed = _lastSpeed;
      _preChangeType  = _lastType;

      ConnectionExpander.WriteCOMPort(_jogLeadIn + "G53 " + (props.ToolChangeUnits == InchMM.Inches ? "G20" : "G21") + " F4000 G90 Z" + props.ToolChangeZ.ToString(EN_US));
      WaitIdle();
      ConnectionExpander.WriteCOMPort("S0");
      ConnectionExpander.WriteCOMPort(_jogLeadIn + "G53 " + (props.ToolChangeUnits == InchMM.Inches ? "G20" : "G21") + " F4000 G90 X" + props.ToolChangeX.ToString(EN_US) + " Y" + props.ToolChangeY.ToString(EN_US));
    }

    private void JogFromToolChangePosition()
    {
      GRBLProps props = GRBLMachinePlugin.Props;

      if (_lastZ != props.ToolChangeZ)
      {
        WaitIdle();
        ConnectionExpander.WriteCOMPort(_jogLeadIn + "G53 " + (props.ToolChangeUnits == InchMM.Inches ? "G20" : "G21") + " F4000 G90 Z" + props.ToolChangeZ.ToString(EN_US));
      }

      WaitIdle();
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (GRBLMachinePlugin.Props.ReportInInches == InchMM.Inches ? "G20" : "G21") + " F4000 G90 X" + _preChangeX.ToString(EN_US) + " Y" + _preChangeY.ToString(EN_US));
      WaitIdle();
      ConnectionExpander.WriteCOMPort("S" + _preChangeSpeed);
      WaitIdle();
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (props.ReportInInches == InchMM.Inches ? "G20" : "G21") + " F" + 4000d                     .GetUnitsFromReportAndDrawing(InchMM.Millimeters,   props.ReportInInches).ToString("0.0000",EN_US) + " G90 Z" + (_preChangeZ + props.ToolChangePlungeDistance.GetUnitsFromReportAndDrawing(props.ToolChangeUnits,props.ReportInInches)).ToString("0.0000",EN_US));
      ConnectionExpander.WriteCOMPort(_jogLeadIn + (props.ReportInInches == InchMM.Inches ? "G20" : "G21") + " F" + props.ToolChangePlungeFeed.GetUnitsFromReportAndDrawing(props.ToolChangeUnits,props.ReportInInches).ToString("0.0000",EN_US) + " G90 Z" + (_preChangeZ.ToString("0.0000",EN_US)));

      WaitIdle();
    }

    private void DoToolChange(object line)
    {
      Message("ToolChange start... ");

      SystemSounds.Asterisk.Play();

      ToolChangeStart();

      JogToToolChangePosition();

      _toolChangerEvent.Reset();

      InvokeOnUI(() => 
      {
        ToolChanger toolChanger = new ToolChanger();

        toolChanger.SetToolFromGCODE(line as string);

        toolChanger.FormClosed += ToolChanger_FormClosed;
        toolChanger.Applied    += ToolChanger_Applied;

        SystemSounds.Asterisk.Play();

        Message("Change tool: " + line + " from ");

        toolChanger.Show(ThisApplication.TopWindow);
      });

      _toolChangerEvent.WaitOne();

      JogFromToolChangePosition();

      ToolChangeEnd();

      Message("ToolChange done... ");
    }

    private void WriteThread()
    {
      FileStream   fs = null;
      StreamReader sr = null; 
            
      try
      {
        if (JobStarted != null)
          InvokeOnUI(() => { JobStarted(); });

        string s;
        int    i;

        fs = new FileStream  (_sendingFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        sr = new StreamReader(fs);

        Message("Parsing: ");

        while ((s = sr.ReadLine()) != null)
        {
          _pauseEvent       .WaitOne();

          GRBLMachinePlugin.Log("---" + s,true);

          bool removeComments = true;

          foreach (string nrc in _noRemoveCommentGCODEs)
          {
            if (s.ToUpper().StartsWith(nrc))
            {
              removeComments = false;
              break;
            }
          }

          if (removeComments)
          {
            StringBuilder line     = new StringBuilder();
            string[]      comments = s.Split('(',')',';','%');

            for (i = 1; i < comments.Length; i++)
              line.Append(comments[i]);

            if (line.Length != 0)
              GRBLMachinePlugin.Log("// " + line.ToString());

            if (comments.Length != 0)
            {
              line = new StringBuilder();

              string[] packed = comments[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

              foreach (string p in packed)
              {
                if (_unsupportedGCODEs.Contains(p))
                  GRBLMachinePlugin.Log("!! Unsuppported GCODE '" + p + "' skipped");
                else
                  line.Append(p);
              }

              if (line.Length != 0)
                _fileData.AddLast(line.ToString());
            }
          }
          else
            _fileData.AddLast(s);

        }

        sr.Close();
        sr = null;

        fs.Close();
        fs = null;

        InvokeOnUI(() => 
        {
          LinesTotal.Text = _fileData.Count.ToString();
          LinesSent .Text = "0";
        });

        Message("Sending: ");

        i = 0;

        _lastState = GRBLMachinePlugin.MachineState.Jog;

        WaitIdle();

        foreach (string line in _fileData)
        {
          _pauseEvent       .WaitOne();
          _toolChangingEvent.WaitOne();

          if (line.ToUpper().Contains("M6"))
            switch (GRBLMachinePlugin.Props.ToolChangeProcess)
            {
              case IgnoreProcessPassOn.Ignore:                                         break;
              case IgnoreProcessPassOn.Process: DoToolChange(line);                    break;
              case IgnoreProcessPassOn.PassOn:  ConnectionExpander.WriteCOMPort(line); break;
            }
          else
            ConnectionExpander.WriteCOMPort(line);

          InvokeOnUI(() => 
          {
            GRBLMachinePlugin.Log("=== " + line, true);

            LinesSent.Text = (++i).ToString();
          });
        }
      }
      catch (ThreadAbortException)       { GRBLMachinePlugin.Log("\naborted"); ConnectionExpander.WriteCOMPort((char)0x18); }
      catch (ThreadInterruptedException) { GRBLMachinePlugin.Log("\nstopped"); ConnectionExpander.WriteCOMPort((char)0x18); }
      catch (Exception ex)
      {
        InvokeOnUI(() => { MessageBox.Show(ex.ToString()); });
      }
      finally
      {
        if (sr != null)
          sr.Close();

        if (fs != null)
          fs.Close();

        ConnectionExpander.WriteCOMPort("M5");

        _writeThread = null;

        InvokeOnUI(() => 
        {
          SystemSounds.Asterisk.Play();

          Message("Done:");

          EnableButtons();

          FileName        .Enabled = true;
          BrowseButton    .Enabled = true;

          _pauseEvent       .Set();
          _toolChangerEvent .Set();
          _toolChangingEvent.Set();

          if (JobStopped != null)
            JobStopped();

          if (!ToolChangeButton.Enabled)
            ToolChangeEnd();
        });
      }
    }

    #endregion // Privates

#region Eventhandlers


    private void ToolChanger_Applied(ToolChanger toolChanger, ToolDefinition tooldef)
    {
      ToolChange(toolChanger.SelectedToolDefinition);
    }

    private void ToolChanger_FormClosed(object sender, FormClosedEventArgs e)
    {
      ToolChanger toolChanger = sender as ToolChanger;

      toolChanger.FormClosed -= ToolChanger_FormClosed;
      toolChanger.Applied    -= ToolChanger_Applied;

      if (toolChanger.DialogResult == DialogResult.OK)
        ToolChange(toolChanger.SelectedToolDefinition);

      _toolChangerEvent.Set();

      toolChanger.Dispose();
    }

    private void TopWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (_writeThread != null)
        _writeThread.Interrupt();
    }

    private void GRBLMachinePlugin_State(GRBLMachinePlugin.MachineState state, int code)
    {
      _lastState = state;

      if (_jogLeadIn == null)
        _jogLeadIn = ConnectionExpander.GrblIsV1 ? V1JOG : string.Empty;
    }

    private void GRBLMachinePlugin_Speed(double feed, int rpm)
    {
      _lastSpeed = rpm;
    }

    private void GRBLMachinePlugin_Position(PosType type, double x, double y, double z)
    {
      if      (type == PosType.MachineCoordinates || 
               type == PosType.WorkCoordinates    )
      {
        _lastType = type;

        if (!double.IsNaN(x))
          _lastX = x;
        if (!double.IsNaN(y))
          _lastY = y;
        if (!double.IsNaN(z))
          _lastZ = z;
      }
      else if (type == PosType.WCO)
      {
        if (!double.IsNaN(x))
          _WCO_X = x;
        if (!double.IsNaN(y))
          _WCO_Y = y;
        if (!double.IsNaN(z))
          _WCO_Z = z;
      }

    }

    private void GRBLMachinePlugin_Responding(GRBLMachinePlugin.Response response, int code)
    {
      if ((response == GRBLMachinePlugin.Response.error || response == GRBLMachinePlugin.Response.alarm ) && _writeThread != null)
        _writeThread.Interrupt();
    }

    private void ConnectionExpander_Disconnected()
    {
      _connected               = false;

      EnableButtons();

      FileName        .Enabled = true;
      BrowseButton    .Enabled = true;
    }

    private void ConnectionExpander_Connected()
    {
      _connected               = true;

      EnableButtons();

      FileName        .Enabled = true;
      BrowseButton    .Enabled = true;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      try
      {
        CamBamUI ui = CamBamUI.MainUI;

        if (_writeThread == null)
        {
          // See if there is any outfile in the MachiningOptions
          if      (!string.IsNullOrEmpty(ui.CADFileTree.CADFile.MachiningOptions.OutFile))
          {
            if (string.IsNullOrEmpty(FileName.Text) || !ui.CADFileTree.CADFile.MachiningOptions.OutFile.Equals(_lastOutfile))
            {
              FileName.Text = FileUtils.GetFullPath(ui.CADFileTree.CADFile,ui.CADFileTree.CADFile.MachiningOptions.OutFile);

              ToolChange(ui.CADFileTree.CADFile.ActiveTool());

              _lastOutfile = ui.CADFileTree.CADFile.MachiningOptions.OutFile;
            }
          }
          else
          {
            // try to find a MOPNCFile, which has it's outfile not in 'Outfile' :(
            foreach (CAMPart part in ui.CADFileTree.CADFile.Parts)
            {
              if (part.MachineOps != null)
              { 
                bool found = false;

                foreach (MachineOp mop in part.MachineOps)
                {
                  if (mop is MOPNCFile)
                  {
                    MOPNCFile mopnc = mop as MOPNCFile;

                    if (!string.IsNullOrEmpty(mopnc.SourceFile))
                    {
                      if (string.IsNullOrEmpty(FileName.Text) || !mopnc.SourceFile.Equals(_lastOutfile))
                        FileName.Text = FileUtils.GetFullPath(ui.CADFileTree.CADFile,mopnc.SourceFile);

                      _lastOutfile = mopnc.SourceFile;
                      found       = true;
                      break;
                    }
                  }

                  if (found)
                    break;
                }
              }
            }
          }
        }
      }
      catch (Exception) { }

      if (!PlayButton.Enabled && CanPlay())
        PlayButton.Enabled = true;
    }

    private void Browse_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd   = new OpenFileDialog();

      ofd.Filter           = "GCODE file|*.nc";
      ofd.FileName         = Path.GetFileName     (FileName.Text);
      try {      
      ofd.InitialDirectory = Path.GetDirectoryName(FileName.Text);
      }
      catch (Exception) { }
      ofd.RestoreDirectory = true;
      ofd.CheckFileExists  = true;
      ofd.DefaultExt       = ".nc";
      
      if (ofd.ShowDialog(this) == DialogResult.OK)
        FileName.Text = ofd.FileName;
    }

    private void FileName_TextChanged(object sender, EventArgs e)
    {
      PlayButton.Enabled = CanPlay();
    }

    private void PlayButton_Click(object sender, EventArgs e)
    {
      if (!CheckState())
        return;

      if (GRBLMachinePlugin.Props.ToolChangeProcess == IgnoreProcessPassOn.Process)
      {
        string post = CamBamUI.MainUI.ActiveView.CADFile.MachiningOptions.PostProcessor;
         
        if (!string.IsNullOrEmpty(post) && post != "GRBLMachine")
          switch (MessageBox.Show("The Post Processor in Machining Options is not 'GRBLMachine'.\r\n\r\nSet Post Processor to 'GRBLMachine' and regenerate GCODE ?","GRBLMachine - Play",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question))
          {
            case DialogResult.Yes:
              CamBamUI.MainUI.ActiveView.CADFile.MachiningOptions.PostProcessor = "GRBLMachine";
              CAMUtils.GenerateGCodeOutput(CamBamUI.MainUI.ActiveView);
              break;
            case DialogResult.Cancel:
              return;
            case DialogResult.No:
              break;
          }
      }

      if (GRBLMachinePlugin.Props.TrackMachine == EnabledDisabled.Enabled)
      {
        CamBamUI ui = CamBamUI.MainUI;

        // turn toolpaths et al on
        ui.ActiveView.CADFile.ShowToolpaths       = true;
        ui.ActiveView.CADFile.ShowRapids          = true;
        ui.ActiveView.CADFile.ShowDirectionVector = true;
        ui.ViewContextMenus.RefreshCheckedMenus();

        // runs in background, so just start it, we'll do something else in the meanwhile
        CAMUtils.GenerateToolpaths(ui.ActiveView);

        // fit current drawing and current perspective to fit view
        ui.ActiveView.ZoomToFitEx();

        // setup ISO-like perspective ( inspired from ViewToolbarAddins (y) )
        ViewProjection vp = ui.ActiveView.ViewProjection;
        Matrix4x4F     mx = Matrix4x4F.Identity;

        mx.Scale    (vp.ViewMatrix4x4F.GetScale());
        mx.RotZ     (-Math.PI /  4f);                // 90 degrees 
        mx.RotX     (-Math.PI / (4f * (60f / 90f))); // 60 degrees
        mx.Translate(vp.ViewMatrix4x4F.m[12], vp.ViewMatrix4x4F.m[13], vp.ViewMatrix4x4F.m[14]);

        vp.ViewMatrix4x4F = mx;

        // re-zoom, since drawing may now be outside the view
        ui.ActiveView.ZoomToFitEx();

        // wait until GenerateToolpaths is ready
        while (ui.ActiveView.IsThinking)
          Application.DoEvents();

        // re-zoom, since toolpaths may be outside the view
        ui.ActiveView.ZoomToFitEx();
      }

      _sendingFileName          = FileName.Text;
      _writeThread              = new Thread(WriteThread);
      _writeThread.Name         = "GCODE-SenderThread";
      _writeThread.IsBackground = true;

      PauseButton .Checked      = false;

      EnableButtons();

      FileName    .Enabled      = false;
      BrowseButton.Enabled      = false;
      LinesSent   .Text         = LinesTotal.Text = "-";

      _pauseEvent .Set();
      _fileData   .Clear();

      _writeThread.Start();
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
      if (_writeThread != null)
        _writeThread.Interrupt();
      else
      {
        EnableButtons();

        PauseButton     .Checked = false;
        FileName        .Enabled = true;
        BrowseButton    .Enabled = true;
      }
      _pauseEvent     .Set();
    }

    private void PauseButton_Click(object sender, EventArgs e)
    {
      if (PauseButton.Checked)
      {
        _pauseEvent.Reset();

        ConnectionExpander.WriteCOMPort('!');

        LinesTotal.Text = _fileData.Count.ToString();

        Message("Pausing... ");

        if (JobPaused != null)
          JobPaused();

        EnableButtons();
      }
      else
      {
        Message("Resuming... ");

        ConnectionExpander.WriteCOMPort('~');

        _pauseEvent.Set();

        if (JobResumed!= null)
          JobResumed();

        EnableButtons();
      }
    }

    private void ToolChangeButton_Click(object sender, EventArgs e)
    {
      if (!CheckState())
        return;

      ToolChangeButton.Enabled = false;
      new Thread(DoToolChange) { Name = "ToolChangeThread", IsBackground = true }.Start("T0 M6 (NoPart\\GRBLMachine Default)");
    }

    #endregion // Eventhandlers

  }
}
