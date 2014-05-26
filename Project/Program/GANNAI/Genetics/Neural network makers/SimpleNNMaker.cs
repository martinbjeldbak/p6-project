using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialNeuralNetwork;

namespace Genetics {
  public class SimpleNNMaker : NNMaker {

    private int chromosomeLength;
    private int bitsPerWeight;
    private int hidden;
    private int inputs;
    private int outputs;
    private int bitsPerBias;

    public SimpleNNMaker(AITrainableGame game){
        bitsPerWeight = game.BitsPerWeight();
        inputs = game.NumInputs();
        hidden = game.NumHidden();
        outputs = game.NumOutputs();
        bitsPerBias = game.BitsPerBias();
        chromosomeLength = (inputs * hidden + hidden * outputs) * bitsPerWeight + (hidden + outputs) * bitsPerBias;
    }

    public NeuralNetwork MakeNeuralNetwork(Chromosome chromosome) {

        double[] weights = new double[inputs * hidden + hidden * outputs];
        double[] biases = new double[hidden + outputs];

        if (chromosome.Length != weights.Length * bitsPerWeight + (hidden + outputs) * bitsPerBias)
            throw new Exception("chromosome length was " + chromosome.Length + " and does not match expected length "
              + weights.Length * bitsPerWeight + ", using " + inputs + " input neurons, " + hidden + " hidden neurons, and " + outputs + " output neurons, "
              + bitsPerWeight + " bits/weight");

        for (int i = 0; i < weights.Length; i++) {
            int left = i * bitsPerWeight;
            int right = left + bitsPerWeight - 1;
            weights[i] = chromosome.CalcDouble(left, right);
        }

        int biasStart = weights.Length * bitsPerWeight;
        for (int t = 0; t < biases.Length; t++) {
            if (bitsPerBias > 0) {
                int left = biasStart + t * bitsPerBias;
                int right = left + bitsPerBias - 1;
                biases[t] = chromosome.CalcDouble(left, right);
            }
            else
                biases[t] = 0;
        }
        return new NeuralNetwork(inputs, hidden, outputs, weights, biases);
    }

    public int ChromosomeLength() {
      return chromosomeLength;
    }
  }
}
