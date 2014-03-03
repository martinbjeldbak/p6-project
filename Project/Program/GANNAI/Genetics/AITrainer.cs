using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  public class AITrainer {

    Population population;
    int generation;

    public AITrainer() {
      generation = 0;
      population = new Population();
    }

    public void Train(int iterations) {
      for (int i = 0; i < iterations; i++) {
        population.Iterate();
      }
      generation += iterations;
    }

    public double[] GetFitnessValues() {
      return population.GetFitnessValues();
    }

    public AIPlayer GetBest() {
      return population.GetBest();
    }

    /// <summary>
    /// Gets the number of generations created
    /// </summary>
    /// <returns></returns>
    public int GenerationNum() {
      return generation;
    }
  }
}
