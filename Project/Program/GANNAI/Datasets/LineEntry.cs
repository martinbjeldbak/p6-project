using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datasets {
  public class LineEntry {
    public string ID { get; private set; }
    public double Value { get; private set; }
    public int Column { get; private set;  }

    public LineEntry(string id, double val, int col) {
      ID = id;
      Value = val;
      Column = col;
    }
  }
}
