using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {

  public class AIPlayer {
    AITrainableGame game;
    private DNA dna;
    private double fitness;
    private DNA lastEvaluatedDNA;

    //Makes a new individual with a random DNA
    public AIPlayer(AITrainableGame game) {
      this.game = game;
      dna = new DNA();
    }

    //Makes a new individual with a predefined DNA cloned from the given DNA
    public AIPlayer(DNA dna, AITrainableGame game) {
      this.game = game;
      dna = new DNA();
    }

    public double GetFitness() {
      if (lastEvaluatedDNA != null && dna.Equals(lastEvaluatedDNA)) {
        return fitness;
      }
      else {
        fitness = game.CalcFitness(this);
        lastEvaluatedDNA = dna.Clone();
        return fitness;
      }
    }

    /// <summary>
    /// Returns a mutated deep copy of itself
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetMutated() {
      return new AIPlayer(dna.GetMutated(), game);
    }

    /// <summary>
    /// Returns a new AIPlayer which DNA is the result of a single point crossover with another AIPlayer's DNA
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetSinglePointCrossover(AIPlayer other) {
      return new AIPlayer(dna.GetSinglePointCrossover(other.dna), game);
    }

    /// <summary>
    /// Returns a new AIPlayer which DNA is the result of a two point crossover with another AIPlayer's DNA
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetTwoPointCrossover(AIPlayer other) {
      return new AIPlayer(dna.GetTwoPointCrossover(other.dna), game);
    }

    /// <summary>
    /// Returns a new AIPlayer which DNA is the result of a uniform crossover with another AIPlayer's DNA
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetUniformCrossover(AIPlayer other) {
      return new AIPlayer(dna.GetUniformCrossover(other.dna), game);
    }

    //Gets the output of the AIPlayer given a number of inputs
    public object[] GetOutputs(object[] inputs) {
      //
      throw new Exception("Not implemented yet");
    }
  }
}
