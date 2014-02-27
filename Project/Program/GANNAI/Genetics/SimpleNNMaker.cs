using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialNeuralNetwork;

namespace Genetics {
  public class SimpleNNMaker : NNMaker {
    
  private int bitsPerWeight;
  private int hiddenNeurons;

    public SimpleNNMaker(int hiddenNeurons, int bitsPerWeight){
      this.hiddenNeurons = hiddenNeurons;
      this.bitsPerWeight = bitsPerWeight;
    }

    public NeuralNetwork MakeNeuralNetwork(DNA dna) {

      int inputs = Configuration.Game.NumInputs();
      int outputs = Configuration.Game.NumOutputs();

      double[] weights = new double[inputs * hiddenNeurons + hiddenNeurons * outputs];

      if (dna.Length != weights.Length * bitsPerWeight)
        throw new Exception("Dna length was " + dna.Length + " and does not match expected length "
          + weights.Length * bitsPerWeight + ", using " + inputs + " input neurons, " + hiddenNeurons + " hidden neurons, and " + outputs + " output neurons, "
          + bitsPerWeight + " bits/weight");

      for (int i = 0; i < weights.Length; i++) {
        weights[i] = dna.CalcInt(i*bitsPerWeight, (i+1)*bitsPerWeight-1);
      }

      return new NeuralNetwork(inputs, hiddenNeurons, outputs, weights);
    }

    public int DNALength() {
      return (Configuration.Game.NumInputs() * hiddenNeurons + hiddenNeurons * Configuration.Game.NumOutputs()) * bitsPerWeight;
    }
  }
}
