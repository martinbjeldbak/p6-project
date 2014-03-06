using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  public abstract class CrossoverMethod {
    public abstract DNA Cross(DNA dna1, DNA dna2);
    public AncestorLink LastCrossAncestorLink;
  }
}
