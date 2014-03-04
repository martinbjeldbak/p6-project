using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  public interface CrossoverMethod {
    DNA Cross(DNA dna1, DNA dna2);
  }
}
