﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PluginTest {
  class Program {
    [STAThread]
    static void Main(string[] args) {
      Application.EnableVisualStyles();
      Application.Run(new TestForm());
    }
  }
}
