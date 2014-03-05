using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialNeuralNetwork;


namespace Genetics {

  public class AIPlayer : IComparable {
    private NeuralNetwork neuralNetwork;
    public DNA DNA { get; private set; }
    private double fitness;

    /// <summary>
    /// Makes a new individual with a random DNA
    /// </summary>
    /// <param name="random">true if DNA string should be random, false if no DNA string should be made</param>
    public AIPlayer(NNMaker neuralNetworkMaker) {
      DNA = new DNA(neuralNetworkMaker.DNALength());
      neuralNetwork = neuralNetworkMaker.MakeNeuralNetwork(DNA);
      fitness = -1;
    }

    /// <summary>
    /// Sets a predefined DNA for the AIPlayer
    /// </summary>
    /// <param name="dna"></param>
    public AIPlayer(DNA dna, NNMaker neuralNetorkMaker) {
      this.DNA = dna;
      neuralNetwork = neuralNetorkMaker.MakeNeuralNetwork(dna);
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
      return fitness.CompareTo(((AIPlayer)obj).fitness);
    }
  }
}
