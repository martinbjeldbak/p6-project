using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utility;

namespace GANNAIUI {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Logger.Log("Starting GANNAI-UI");
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
  }
}
