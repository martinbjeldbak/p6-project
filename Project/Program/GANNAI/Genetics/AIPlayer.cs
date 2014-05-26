using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialNeuralNetwork;
using Utility;


namespace Genetics {

  public class AIPlayer : IComparable {
    
    public NeuralNetwork neuralNetwork { get; private set; }
    public readonly AIPlayer Parent1, Parent2;
    public Chromosome Chromosome { get; private set; }
    private double fitness;

    /// <summary>
    /// Makes a new individual with a random chromosome
    /// </summary>
    /// <param name="random">true if chromosome string should be random, false if no chromosome string should be made</param>
    public AIPlayer(NNMaker neuralNetworkMaker) {
      Chromosome = new Chromosome(neuralNetworkMaker.ChromosomeLength());
      neuralNetwork = neuralNetworkMaker.MakeNeuralNetwork(Chromosome);
      fitness = -1;
    }

    /// <summary>
    /// Sets a predefined chromosome for the AIPlayer
    /// </summary>
    /// <param name="chromosome"></param>
    public AIPlayer(Chromosome chromosome, NNMaker neuralNetworkMaker) {
      neuralNetwork = neuralNetworkMaker.MakeNeuralNetwork(chromosome);
      Chromosome = chromosome;
      fitness = -1;
    }

    /// <summary>
    /// Sets a predefined chromosome for the AIPlayer
    /// </summary>
    /// <param name="chromosome"></param>
    public AIPlayer(Chromosome chromosome, AIPlayer parent1, AIPlayer parent2, NNMaker neuralNetworkMaker) {
      Parent1 = parent1;
      Parent2 = parent2;
      neuralNetwork = neuralNetworkMaker.MakeNeuralNetwork(chromosome);
      Chromosome = chromosome;
      fitness = -1;
    }

    /// <summary>
    /// Returns the fitness of the AIPlayer. 
    /// CalcFitness() must be called prior to calling this method
    /// </summary>
    /// <returns></returns>
    public double GetFitness() {
      return fitness;
    }

    /// <summary>
    /// Calculates the fitness of the AIPlayer based on the given game.
    /// Call GetFitness() retrieve the fitness value afterwards.
    /// </summary>
    /// <param name="game"></param>
    public void CalcFitness(AITrainableGame game) {
      fitness = game.CalcFitness(this);
    }

    /// <summary>
    /// Gets the index of the strongest output value
    /// </summary>
    /// <param name="inputs">The inputs for the AIPlayer</param>
    /// <returns></returns>
    public int GetStrongestOutputIndex(double[] inputs) {
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
    /// Gets the
    /// </summary>
    /// <param name="inputs">The inputs for the AIPlayer</param>
    /// <returns></returns>
    public double[] GetOutputs(double[] inputs) {
      neuralNetwork.SetInput(inputs);
      return neuralNetwork.GetOutput();
    }

    /// <summary>
    /// Compares the fitness of itself to the fitness of another AIPlayer, based on the current game
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int CompareTo(object obj) {
      return fitness.CompareTo(((AIPlayer)obj).fitness);
    }

    public bool[] GetOutputsBinary(bool[] inputs) {
        neuralNetwork.SetInputBinary(inputs);
        return neuralNetwork.GetOutputBinary();
    }
  }
}
