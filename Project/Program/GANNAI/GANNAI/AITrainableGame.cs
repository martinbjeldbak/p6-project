using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GANNAI {
  public interface AITrainableGame {
    double CalcFitness(AIPlayer aiplayer);
    double NumInputs();
    double NumOutputs();
  }
}
