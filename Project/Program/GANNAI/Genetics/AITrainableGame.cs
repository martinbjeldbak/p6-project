using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Genetics {
  public interface AITrainableGame {
    double CalcFitness(AIPlayer aiplayer);
    /// <summary>
    /// The number of inputs the game will give an AIPlayer
    /// </summary>
    /// <returns></returns>
      int NumInputs();

      /// <summary>
      /// The number of actions an AIPlayer can perform
      /// </summary>
      /// <returns></returns>
    int NumOutputs();

      /// <summary>
      /// The number of hidden neurons that should be used by an AIPlayer (neural network)
      /// </summary>
      /// <returns></returns>
    int NumHidden();

      /// <summary>
      /// The number of bits to use to encode each weight in the neural network used by the AIPlayer
      /// </summary>
      /// <returns></returns>
    int BitsPerWeight();

      /// <summary>
      /// The number of bits used to encode the threshold of hidden and output neurons
      /// </summary>
      /// <returns></returns>
    int BitsPerThreshold();

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
