using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GANNAI {
  //TAn individual represent an AI player
  public class AIPlayer {
    private DNA dna;
    private double fitness;
    private DNA lastEvaluatedDNA;

    public AIPlayer() {
      dna = new DNA();
    }

    public double GetFitness(AITrainableGame game) {
      if (lastEvaluatedDNA != null && dna.Equals(lastEvaluatedDNA)) {
        return fitness;
      }
      else {
        fitness = game.CalcFitness(this);
        lastEvaluatedDNA = dna.Clone();
        return fitness;
      }
    }
  }
}
