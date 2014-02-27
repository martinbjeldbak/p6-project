using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialNeuralNetwork;

namespace Genetics {

  public class AIPlayer : IComparable {
    private NeuralNetwork neuralNetwork;
    private DNA dna;
    private double fitness;
    private int hash;


    /// <summary>
    /// Makes a new individual with a random DNA
    /// </summary>
    /// <param name="random">true if DNA string should be random, false if no DNA string should be made</param>
    public AIPlayer() {
      dna = new DNA(Configuration.NeuralNetworkMaker.DNALength());
      fitness = -1;
    }

    /// <summary>
    /// Sets a predefined DNA for the AIPlayer
    /// </summary>
    /// <param name="dna"></param>
    public AIPlayer(DNA dna) {
      this.dna = dna;
      fitness = -1;
    }

    public void CalcFitness(){
      if(fitness == -1) {
        neuralNetwork = Configuration.NeuralNetworkMaker.MakeNeuralNetwork(dna);
        fitness = Configuration.Game.CalcFitness(this);
      }
    }

    public double GetFitness() {
      if (fitness == -1) {
        neuralNetwork = Configuration.NeuralNetworkMaker.MakeNeuralNetwork(dna);
        fitness = Configuration.Game.CalcFitness(this);
        return fitness;
      }
      else {
        CalcFitness();
        return fitness;
      }
    }

    /// <summary>
    /// Returns a mutated deep copy of itself
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetMutated() {
      return new AIPlayer(dna.GetMutated());
    }

    /// <summary>
    /// Returns a new AIPlayer which DNA is the result of a single point crossover with another AIPlayer's DNA
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetSinglePointCrossover(AIPlayer other) {
      return new AIPlayer(dna.GetSinglePointCrossover(other.dna));
    }

    /// <summary>
    /// Returns a new AIPlayer which DNA is the result of a two point crossover with another AIPlayer's DNA
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetTwoPointCrossover(AIPlayer other) {
      return new AIPlayer(dna.GetTwoPointCrossover(other.dna));
    }

    /// <summary>
    /// Returns a new AIPlayer which DNA is the result of a uniform crossover with another AIPlayer's DNA
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetUniformCrossover(AIPlayer other) {
      return new AIPlayer(dna.GetUniformCrossover(other.dna));
    }

    //Gets the output of the AIPlayer given a number of inputs
    public int GetOutput(double[] inputs) {
      neuralNetwork.SetInput(inputs);
      
      double[] outputs = neuralNetwork.GetOutput();
      bool[] result = new bool[outputs.Length];
      double maxVal = Double.NegativeInfinity;
      int bestIndex = 0;
      for (int i = 0; i < result.Length; i++) {
        if (outputs[i] > maxVal) {
          maxVal = outputs[i];
          bestIndex = i;
        }
      }
      return bestIndex;
    }

    /// <summary>
    /// Compares the fitness of itself to the fitness of another AIPlayer, based on the current game
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int CompareTo(object obj) {
      return GetFitness().CompareTo(((AIPlayer)obj).GetFitness());
    }
  }
}
