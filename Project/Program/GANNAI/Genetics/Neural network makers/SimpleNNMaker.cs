using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialNeuralNetwork;

namespace Genetics {
  public class SimpleNNMaker : NNMaker {

    private int dnalength;
    private int bitsPerWeight;
    private int hidden;
    private int inputs;
    private int outputs;
    private int bitsPerThreshold;

    public SimpleNNMaker(AITrainableGame game){
        bitsPerWeight = game.BitsPerWeight();
        inputs = game.NumInputs();
        hidden = game.NumHidden();
        outputs = game.NumOutputs();
        bitsPerThreshold = game.BitsPerBias();
        dnalength = (inputs * hidden + hidden * outputs) * bitsPerWeight + (hidden + outputs) * bitsPerThreshold;
    }

    public NeuralNetwork MakeNeuralNetwork(DNA dna) {

        double[] weights = new double[inputs * hidden + hidden * outputs];
        double[] thresholds = new double[hidden + outputs];

        if (dna.Length != weights.Length * bitsPerWeight + (hidden + outputs) * bitsPerThreshold)
            throw new Exception("Dna length was " + dna.Length + " and does not match expected length "
              + weights.Length * bitsPerWeight + ", using " + inputs + " input neurons, " + hidden + " hidden neurons, and " + outputs + " output neurons, "
              + bitsPerWeight + " bits/weight");

        for (int i = 0; i < weights.Length; i++) {
            int left = i * bitsPerWeight;
            int right = left + bitsPerWeight - 1;
            weights[i] = dna.CalcDouble(left, right);
        }

        int thresholdsStart = weights.Length * bitsPerWeight;
        for (int t = 0; t < thresholds.Length; t++) {
            if (bitsPerThreshold > 0) {
                int left = thresholdsStart + t * bitsPerThreshold;
                int right = left + bitsPerThreshold - 1;
                thresholds[t] = dna.CalcDouble(left, right);
            }
            else
                thresholds[t] = 0;
        }
        return new NeuralNetwork(inputs, hidden, outputs, weights, thresholds);
    }

    public int DNALength() {
      return dnalength;
    }
  }
}
