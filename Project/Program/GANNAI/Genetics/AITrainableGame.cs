using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  public interface AITrainableGame {
    double CalcFitness(AIPlayer aiplayer);
    double NumInputs();
    double NumOutputs();
  }
}
