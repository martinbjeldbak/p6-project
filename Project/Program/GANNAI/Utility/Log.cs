using System;
using System.IO;

namespace Utility {
  public static class Logger {
    public static void Log(string msg) {
      LogMessage(msg, "info");
    }

    public static void Debug(string msg) {
      LogMessage(msg, "debug");
    }

    public static void Error(string msg) {
      LogMessage(msg, "error");
    }

    private static void LogMessage(string msg, string type) {
      StreamWriter w = File.AppendText("log.txt");

      // Write header
      w.WriteLine("{0} {1}: {2}", DateTime.Now.ToString("g"), type.ToUpper(), msg);
        
      w.Close();
    }
  }
}

