using System;
using Genetics;
using Datasets;
using System.Collections.Generic;
using System.Linq;

namespace Games {
  public class Iris : AITrainableGame  {
    IrisDataset iris;

    public Iris() {
      this.iris = new IrisDataset(0.5);
    }

    private string IrisMap(int index) {
      switch(index) {
      case 0:
        return "Iris-setosa";
      case 1:
        return "Iris-versicolor";
      case 2:
        return "Isis-virginica";
      default:
        throw new Exception("No such mapping to Iris plant");
      }
    }

    #region AITrainableGame implementation
    public double CalcFitness(AIPlayer aiplayer) {
      int fitness = 0;

      foreach(List<string> line in iris.ValidationSet) {
        int outputIndex = aiplayer.GetStrongestOutputIndex(line.Take(4).Select(double.Parse).ToArray());

        // If the output is correct, better fitness
        if(String.Equals(IrisMap(outputIndex), line.Last().ToLower(), StringComparison.CurrentCultureIgnoreCase)) {
          fitness++;
        }
      }
      return fitness;
    }

    public int NumInputs() {
      return 4;
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

