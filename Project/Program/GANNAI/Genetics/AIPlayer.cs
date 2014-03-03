using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialNeuralNetwork;
using GANNAI;

namespace Genetics {

  public class AIPlayer : IComparable {
    private NeuralNetwork neuralNetwork;
    private DNA dna;
    private double fitness;
    private Population population;

    /// <summary>
    /// Makes a new individual with a random DNA
    /// </summary>
    /// <param name="random">true if DNA string should be random, false if no DNA string should be made</param>
    public AIPlayer(Population population, int dnaLength) {
      dna = new DNA(dnaLength);
      this.population = population;
      fitness = -1;
    }

    /// <summary>
    /// Sets a predefined DNA for the AIPlayer
    /// </summary>
    /// <param name="dna"></param>
    public AIPlayer(Population population, DNA dna) {
      this.population = population;
      this.dna = dna;
      fitness = -1;
    }

    /// <summary>
    /// Calculates the fitness of the AIPlayer. 
    /// If the fitness has been calculated before, the value is cached and will
    /// not need to be calculated again ever.
    /// </summary>
    /// <returns></returns>
    public double GetFitness() {
      if (fitness == -1) {
        neuralNetwork = population.Simulation.NeuralNetworkMaker.MakeNeuralNetwork(dna);
        fitness = population.Simulation.Game.CalcFitness(this);
        return fitness;
      }
      else {
        return fitness;
      }
    }

    /// <summary>
    /// Returns a mutated deep copy of itself
    /// </summary>
    /// <returns></returns>
    public AIPlayer GetMutated() {
      return new AIPlayer(population, dna.GetMutated());
    }

    /// <summary>
    /// Crosses the AIPlayer with another, using a random crossover method allowed Configuration
    /// </summary>
    /// <param name="other">AIPlayer to be crossed with</param>
    /// <returns></returns>
    public static AIPlayer GetCrossover(AIPlayer aiplayer1, AIPlayer aiplayer2) {
      int randomFuncIndex = Utility.RandomInt(0, aiplayer1.population.Simulation.AllowedCrossoverMethods.Count);
       return aiplayer1.population.Simulation.AllowedCrossoverMethods[randomFuncIndex](aiplayer1, aiplayer2);
    }

    /// <summary>
    /// Returns a new AIPlayer which DNA is the result of a single point crossover between two AIPlayer's DNA
    /// </summary>
    /// <returns></returns>
    public static AIPlayer GetSinglePointCrossover(AIPlayer aiplayer1, AIPlayer aiplayer2) {
      return new AIPlayer(aiplayer1.population, aiplayer1.dna.GetSinglePointCrossover(aiplayer2.dna));
    }

    /// <summary>
    /// Returns a new AIPlayer which DNA is the result of a two point crossover between two AIPlayer's DNA
    /// </summary>
    /// <returns></returns>
    public static AIPlayer GetTwoPointCrossover(AIPlayer aiplayer1, AIPlayer aiplayer2) {
      return new AIPlayer(aiplayer1.population, aiplayer1.dna.GetTwoPointCrossover(aiplayer2.dna));
    }

    /// <summary>
    /// Returns a new AIPlayer which DNA is the result of a uniform crossover between two AIPlayer's DNA
    /// </summary>
    /// <returns></returns>
    public static AIPlayer GetUniformCrossover(AIPlayer aiplayer1, AIPlayer aiplayer2) {
      return new AIPlayer(aiplayer1.population, aiplayer1.dna.GetUniformCrossover(aiplayer2.dna));
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
