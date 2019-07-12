namespace GRBLMachine.UI
{
  public partial class AboutExpander : Expander
  {
    public AboutExpander()
    {
      InitializeComponent();

      VersionLabel.Text = "v" + GRBLMachinePlugin.Version;
      TheToolTip  .SetToolTip(DonateLabel,"In case you are using GRBLMachine for commercial purposes,\r\n" + 
                                          "you might want to show your appreciation by transfering\r\n" + 
                                          "a couple of bucks into my PayPal account (karst.drenth@hetnet.nl).\r\n\r\nAny amount is welcome ;)");
    }
  }
}
