using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  public class AITrainer {

    Population population;

    public AITrainer() {
      population = new Population(100, 33, 33, 3);
    }

    public void Train(int iterations) {
      for (int i = 0; i < iterations; i++) {
        population.Iterate();
      }
    }

    public double[] GetFitnessValues() {
      return population.GetFitnessValues();
    }

    public AIPlayer GetBest() {
      return population.GetBest();
    }
  }
}
