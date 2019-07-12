using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GRBLMachine.UI
{
  public partial class Expander : UserControl
  {
    private int  _initialHeight;
    private bool _expanded = true;
    private bool _loaded;

    public Expander()
    {
      InitializeComponent();
    }

    [Category("Appearance")]
    [Browsable(true)]
    public override string Text
    {
      get { return HeaderLabel.Text;         }
      set {        HeaderLabel.Text = value; }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    [Browsable(true)]
    public bool Expanded {

      get
      {
        return _expanded;
      }
      set
      {
        if (!DesignMode)
        {
          _expanded = value;

          if (!_loaded)
            return;

          if (value) { 
            Height                 = _initialHeight;
            HeaderLabel.ImageIndex = 0;
          }
          else
          {
            Height                 = HeaderLabel.Height;
            HeaderLabel.ImageIndex = 1;
          }
        }
        else
          _expanded = value;
      }
    }


    public void InvokeOnUI(Action lambdaBody)
    {
      if (InvokeRequired)
        base.Invoke(lambdaBody);
      else
        lambdaBody();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      _initialHeight = Height;

      _loaded        = true;

      Expanded = Expanded;
    }

    private void HeaderLabel_Click(object sender, EventArgs e)
    {
      Expanded = !Expanded;
    }
  }
}
