using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GANNAI {
  public abstract class Individual {
    private DNA dna;
    public abstract double GetFitness();
  }
}
