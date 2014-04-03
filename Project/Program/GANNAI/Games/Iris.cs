using System;
using Genetics;
using Datasets;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Games {
  public class Iris : AITrainableGame  {
    IrisDataset iris;

    public Iris() {
      this.iris = new IrisDataset();
    }

    #region AITrainableGame implementation
    public double CalcFitness(AIPlayer aiplayer) {
      int fitness = 0;

      int numInputs = NumInputs();
      int outputIndex = iris.OutputIndicies()[0];
      List<double> inputs = new List<double>(numInputs);
      // For each row in the data set, get its converted values
      foreach (Line l in iris.MappedTestSet) {
        inputs = new List<double>(numInputs);
        inputs.AddRange(l.entries.Where(e => !iris.OutputIndicies().ToList().Contains(e.Column)).Select(e => e.Value));

        int outputNeuron = aiplayer.GetStrongestOutputIndex(inputs.ToArray());

        if (outputNeuron == l.entries[outputIndex].Value)
          fitness++;
      }

      return fitness;
    }

    public int NumInputs() {
      return iris.InputIndicies().Count();
    }

    public int NumOutputs() {
      return 3;
    }

    public AITrainableGame GetNewGameInstance() {
      return new Iris();
    }

    public void Visualize(AIPlayer aiplayer, System.Windows.Forms.Form form) {
      throw new NotImplementedException();
    }

    public string Name() {
      return "Iris classification";
    }
    #endregion
  }
}

