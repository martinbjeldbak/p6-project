using System;
using Genetics;
using Utility;
//using System.Linq;

namespace Games {
  public class Rosenbrock : AITrainableGame {

    public Rosenbrock() {
    }

    #region AITrainableGame implementation

    public double CalcFitness(AIPlayer aiplayer) {
      double fitness;

      for(int i = 0; i < 1000; i++) {
        int x = RandomNum.RandomInt(0, i);
        int y = RandomNum.RandomInt(0, i);

        int diff = 1 - Math.Abs(RosenbrockFunction(x, y) - aiplayer.GetStrongestOutputIndex(x, y));
        fitness += diff;
      }

      return fitness;
    }

    public int NumInputs() {
      return 2;
    }

    public int NumOutputs() {
      return 1;
    }

    public AITrainableGame GetNewGameInstance() {
      return new Rosenbrock();
    }

    public void Visualize(AIPlayer aiplayer, System.Windows.Forms.Form form) {
      throw new NotImplementedException();
    }

    public string Name() {
      return "Rosenbrock";
    }

    #endregion

    private int RosenbrockFunction(int x, int y) {
      return ((1 - x) * (1 - x)) + 100 * ((y - x * x) * (y - x * x));
    }
  }
}

