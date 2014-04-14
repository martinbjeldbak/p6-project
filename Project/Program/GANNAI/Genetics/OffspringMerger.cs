using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {

  public interface ReplacementRule {
    /// <summary>
    /// Merges the offspring into the population using a particular technique for choosing which
    /// individuals to replace. The population list will be altered by calling this method. 
    /// </summary>
    /// <param name="population">the original population</param>
    /// <param name="offspring">the offspring</param>
    /// <param name="simulation">A Simulation instance giving access not configuration settings</param>
    void Merge(SortList<AIPlayer> population, List<AIPlayer> offspring, Simulation simulation);
  }
}
