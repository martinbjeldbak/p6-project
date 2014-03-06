using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  public class AncestorLink {

    public readonly DNA Parent1, Parent2;
    public readonly double Parent1Amount, Parent2Amount;

    /// <summary>
    /// Creates a new ancestor link
    /// </summary>
    /// <param name="parent1">The first parent</param>
    /// <param name="parent2">The second parent</param>
    /// <param name="parent1Amount">How much there is taken from the first parent</param>
    /// <param name="parent2Amount">How much there is taken from the second parent</param>
    public AncestorLink(DNA parent1, DNA parent2, double parent1Amount, double parent2Amount) {
      this.Parent1 = parent1;
      this.Parent2 = parent2;
      this.Parent1Amount = parent1Amount;
      this.Parent2Amount = parent2Amount;
    }
  }
}
