using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
namespace Genetics {
  public class SimpleOffspringMerger : OffspringMerger {
    public void Merge(SortList<AIPlayer> population, List<AIPlayer> offspring, Simulation simulation) {
      offspring.ForEach(p => population.Add(p));
    }
  }
}
