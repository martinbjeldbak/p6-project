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
    public AIPlayer(DNA dna, NNMaker neuralNetworkMaker) {
      neuralNetwork = neuralNetworkMaker.MakeNeuralNetwork(dna);
      DNA = dna;
      fitness = -1;
    }

    /// <summary>
    /// Sets a predefined DNA for the AIPlayer
    /// </summary>
    /// <param name="dna"></param>
    public AIPlayer(DNA dna, AIPlayer parent1, AIPlayer parent2, NNMaker neuralNetworkMaker) {
      Parent1 = parent1;
      Parent2 = parent2;
      neuralNetwork = neuralNetworkMaker.MakeNeuralNetwork(dna);
      DNA = dna;
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
      
    /// <summary>
    /// Returns the most similar AIPlayer from the list given, based on a comparison of the DNA origins 
    /// </summary>
    /// <param name="list">The list to search in</param>
    /// <returns>The most similar AIPlayer</returns>
    public AIPlayer MostSimilar(SortList<AIPlayer> list) {
      double max = Double.NegativeInfinity;
      AIPlayer best = null;
      foreach (AIPlayer a in list){
        double similarity = CalcSimilarity(a);
        if (similarity > max) {
          best = a;
          max = similarity;
        }
      }
      return best;
    }

    public double CalcSimilarity(AIPlayer a) {
      
      /*
      double similarity = 0;

     
        if (a.AncestorLink == null)
          return 0;

        if (AncestorLink.Parent1 == a.AncestorLink.Parent1)
          similarity += Math.Min(AncestorLink.Parent1Amount, a.AncestorLink.Parent1Amount);
        else if (AncestorLink.Parent1 == a.AncestorLink.Parent2)
          similarity += Math.Min(AncestorLink.Parent1Amount, a.AncestorLink.Parent2Amount);
        if (AncestorLink.Parent2 == a.AncestorLink.Parent1)
          similarity += Math.Min(AncestorLink.Parent2Amount, a.AncestorLink.Parent1Amount);
        else if (AncestorLink.Parent2 == a.AncestorLink.Parent2)
          similarity += Math.Min(AncestorLink.Parent2Amount, a.AncestorLink.Parent2Amount);
    
      return similarity;
       * */
      double sameBits = 0;
      for (int i = 0; i < DNA.Bitstring.Length; i++) {
        sameBits += DNA.Bitstring[i] == a.DNA.Bitstring[i] ? 1 : 0;
      }
      return (sameBits / DNA.Bitstring.Length);


    }
  }
}
