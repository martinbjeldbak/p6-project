using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GANNAI {

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

    //Gets the output of the AIPlayer given a number of inputs
    public object[] GetOutputs(object[] inputs) {
      //
      throw new Exception("Not implemented yet");
    }
  }
}
