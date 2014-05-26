using System;
using Genetics;
using Datasets;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Games {
  public class XOR : AITrainableGame  {

      int bits;
      

      /// <summary>
      /// Initialiases a problem instance of finding the XOR between 2 strings of x bits
      /// </summary>
      /// <param name="bits"></param>
    public XOR(int bits = 1) {
        this.bits = bits;
    }

    #region AITrainableGame implementation
    public double CalcFitness(AIPlayer aiplayer) {
        Random rnd = new Random(235774);
        double fitness = 0;
        //try all combinations of bit strings
        bool[] inputs = new bool[bits*2];
        int runs = 1000;
        for (int i = 0; i < runs; i++) {

            //make two random bitstrings
            for (int s = 0; s < bits * 2; s++)
                inputs[s] = rnd.Next(2) == 1;

            //count how many bits of the XOR between the two bit strings it calculates correct
            int correct = 0;
            bool[] outputs = aiplayer.GetOutputsBinary(inputs);
            for (int p = 0; p < bits; p++)
                correct += inputs[p] ^ inputs[p+bits] == outputs[p] ? 1 : 0;
            fitness += correct; 
        }

        //return average number of bits calculated correct
      return fitness / runs;
    }

    public int NumInputs() {
      return bits*2;
    }

    public int NumOutputs() {
      return bits;
    }
    public int NumHidden() {
        return bits*2;
    }
    public int BitsPerWeight() {
        return 3;
    }
    public int BitsPerBias() {
        return 1;
    }
    public AITrainableGame GetNewGameInstance() {
      return this;
    }

    public void Visualize(AIPlayer aiplayer, System.Windows.Forms.Form form) {
      throw new NotImplementedException();
    }

    public string Name() {
      return "XOR";
    }
    #endregion
  }
}

