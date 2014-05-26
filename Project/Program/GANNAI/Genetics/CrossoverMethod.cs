using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  public abstract class CrossoverMethod {
    public abstract Chromosome Cross(Chromosome chromosome1, Chromosome chromosome2);
  }
}
