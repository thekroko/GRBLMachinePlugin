using System;
using System.Windows.Forms;

namespace GRBLMachine.UI
{
  public partial class ConsoleExpander : Expander
  {
    public ConsoleExpander()
    {
      InitializeComponent();

      GRBLMachinePlugin .Logging      += GRBLMachinePlugin_Logging;
      ConnectionExpander.Connected    += ConnectionExpander_Connected;
      ConnectionExpander.Disconnected += ConnectionExpander_Disconnected;
      Clear             .Click        += Clear_Click;
    }

    private void ConnectionExpander_Disconnected()
    {
      Command.Enabled = false;
    }

    private void ConnectionExpander_Connected()
    {
      Command.Enabled = true;
    }

    private void Clear_Click(object sender, EventArgs e)
    {
      Console.Items.Clear();
    }

    private void GRBLMachinePlugin_Logging(string log, bool verbose)
    {
      if (verbose && !Verbose.Checked)
        return;

      InvokeOnUI(() => 
      {
        if (!Freeze.Checked) {
          while (Console.Items != null && Console.Items.Count > 500)
            Console.Items.RemoveAt(0);

          string[] rgLog = log.Split('\n');

          foreach (string s in rgLog)
            Console.Items.Add(s);

          Console.SelectedIndex = Console.Items.Count - 1;
        }
      });
    }

    private void Command_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        ConnectionExpander.WriteCOMPort(Command.Text);

        e.Handled = true;
      }
    }

    private void Command_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        e.Handled = true;
      }
    }
  }
}
