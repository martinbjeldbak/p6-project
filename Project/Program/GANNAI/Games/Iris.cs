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

      foreach(List<string> line in iris.TestSet) {
        int numInputs = NumInputs();
        double[] tmp = new double[numInputs]; //= line.Take(4).Select(Double.Parse).ToArray();
        
        for (int i = 0; i < numInputs; i++) {
          tmp[i] = Double.Parse(line[i], CultureInfo.InvariantCulture);
        }

        int outputIndex = aiplayer.GetStrongestOutputIndex(tmp);

        // If the output is correct, better fitness
        if(String.Equals(IrisDataset.IrisMap(outputIndex), line[iris.OutputIndicies().First()], StringComparison.CurrentCultureIgnoreCase)) {
          fitness++;
        }
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

