using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Genetics {
  public interface AITrainableGame {
    double CalcFitness(AIPlayer aiplayer);
    double NumInputs();
    double NumOutputs();

    /// <summary>
    /// Visualized the game played using the given AIPlayer
    /// </summary>
    /// <param name="aiplayer"></param>
    void Visualize(AIPlayer aiplayer, Form form);
  }
}
