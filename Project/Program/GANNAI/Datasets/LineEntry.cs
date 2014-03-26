using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datasets {
  public class LineEntry {
    public double ID { get; private set; }
    public string Value { get; private set; }
    public int Column { get; private set;  }

    public LineEntry(string val, double id, int col) {
      ID = id;
      Value = val;
      Column = col;
    }
  }
}
