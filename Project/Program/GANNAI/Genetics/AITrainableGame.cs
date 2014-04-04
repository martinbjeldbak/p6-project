using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Genetics {
  public interface AITrainableGame {
    double CalcFitness(AIPlayer aiplayer);
    int NumInputs();
    int NumOutputs();

    /// <summary>
    /// Returns a new instance of the same game.
    /// This can be used to run more game instances in parallel.
    /// </summary>
    /// <returns></returns>
    AITrainableGame GetNewGameInstance();

    /// <summary>
    /// Visualized the game played using the given AIPlayer
    /// </summary>
    /// <param name="aiplayer"></param>
    void Visualize(AIPlayer aiplayer, Form form);

    string Name();
  }
}
