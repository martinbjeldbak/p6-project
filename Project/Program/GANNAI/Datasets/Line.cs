using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datasets {
  public class Line {
    public List<LineEntry> entries;

    public Line() {
      entries = new List<LineEntry>();
    }

    public Line(LineEntry entry) : this() {
      entries.Add(entry);
    }

    public void AddEntry(LineEntry entry) {
      entries.Add(entry);
    }
  }
}
