using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GRBLMachine.UI
{
  public partial class GRBLButton : Button
  {
    public  Image _orgBackgroundImage;
    private bool  _checked;

    public GRBLButton()
    {
      InitializeComponent();
    }

    [Category("Appearance")]
    [DefaultValue(null)]
    [Description("The image to use when the button is disabled")]
    public Image BackgroundImageDisabled { get; set; }


    [Category("Appearance")]
    [DefaultValue(null)]
    [Description("The image to use when the button is a toggle button and it is checked")]
    public Image BackgroundImageChecked { get; set; }

    [Category("Appearance")]
    [DefaultValue(false)]
    [Description("Set the toggle state of the button")]
    public bool Checked
    {
      get
      {
        return _checked;
      }
      set
      {
        if (!ToggleButton)
          return;

        _checked = value;
        OnCheckedChanged(EventArgs.Empty);
      }
    }

    [Category("Appearance")]
    [DefaultValue(false)]
    [Description("Then button is a toggle button")]
    public bool ToggleButton { get; set; }


    [Category("Property Changed")]
    [DefaultValue(null)]
    [Description("The checked state has changed")]
    public event EventHandler CheckedChanged;


    public override Image BackgroundImage
    {
      get
      {
        return !Enabled ? BackgroundImageDisabled
                        : (Checked ? BackgroundImageChecked 
                                   : _orgBackgroundImage);
      }

      set
      {
        _orgBackgroundImage  = value;
        base.BackgroundImage = value;
      }
    }

    protected void OnCheckedChanged(EventArgs e)
    {
      base.BackgroundImage = BackgroundImage;

      if (CheckedChanged != null)
        CheckedChanged(this,e);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
      base.BackgroundImage = BackgroundImage;

      base.OnEnabledChanged(e);
    }

    protected override void OnClick(EventArgs e)
    {
      Checked = !Checked;

      base.OnClick(e);
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
      Image bg = BackgroundImage;

      base.OnMouseDown(mevent);

      base.BackgroundImage = bg;
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
      Image bg = BackgroundImage;

      base.OnMouseUp(mevent);

      base.BackgroundImage = bg;
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      Image bg = BackgroundImage;

      base.OnMouseLeave(e);

      base.BackgroundImage = bg;
    }
  }
}
