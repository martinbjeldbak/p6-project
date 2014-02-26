using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialNeuralNetwork;

namespace Genetics {
  public static class NNMaker {

  //bits per weight
  private static int bitsPerWeight = 8;

    public static NeuralNetwork MakeNeuralNetwork(DNA dna, int inputs, int hidden, int outputs) {
     
      double[] weights = new double[inputs * hidden + hidden * outputs];

      if (dna.Length != weights.Length * bitsPerWeight)
        throw new Exception("Dna length does was " + dna.Length + " and does not match expected length " 
          + weights.Length + ", using " + inputs + " input neurons, " + hidden + " hidden neurons, and " + outputs + " output neurons");

      for (int i = 0; i < weights.Length; i++) {
        weights[i] = dna.CalcInt(i*bitsPerWeight, (i+1)*bitsPerWeight-1);
      }

        return new NeuralNetwork(inputs, hidden, outputs, weights);
    }
  }
}
