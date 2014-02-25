using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  public class AITrainer {

    Population population;

    public AIPlayer TrainAIPlayer(AITrainableGame game, int iterations) {
      population = new Population(game, 100, 33, 33, 3);
      for (int i = 0; i < iterations; i++) {
        population.Iterate();
      }
      return population.GetBest();
    }
  }
}
