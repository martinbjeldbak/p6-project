using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialNeuralNetwork;

namespace Genetics {
  public class SimpleNNMaker : NNMaker {

    private int dnalength;
    private int bitsPerWeight;
    private int hiddenNeurons;
    private int inputs;
    private int outputs;

    public SimpleNNMaker(AITrainableGame game){
        bitsPerWeight = game.BitsPerWeight();
        inputs = game.NumInputs();
        hiddenNeurons = game.NumHidden();
        outputs = game.NumOutputs();
        dnalength = (inputs * hiddenNeurons + hiddenNeurons * outputs) * bitsPerWeight;
    }

    public NeuralNetwork MakeNeuralNetwork(DNA dna) {

      double[] weights = new double[inputs * hiddenNeurons + hiddenNeurons * outputs];

      if (dna.Length != weights.Length * bitsPerWeight)
        throw new Exception("Dna length was " + dna.Length + " and does not match expected length "
          + weights.Length * bitsPerWeight + ", using " + inputs + " input neurons, " + hiddenNeurons + " hidden neurons, and " + outputs + " output neurons, "
          + bitsPerWeight + " bits/weight");

      for (int i = 0; i < weights.Length; i++) {
        weights[i] = dna.CalcDouble(i*bitsPerWeight, (i+1)*bitsPerWeight-1);
      }

      return new NeuralNetwork(inputs, hiddenNeurons, outputs, weights);
    }

    public int DNALength() {
      return dnalength;
    }
  }
}
