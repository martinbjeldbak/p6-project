using System;
using Genetics;
using Utility;

namespace Games {
  public class Rosenbrock : AITrainableGame {
    AIPlayer aiplayer;

    public Rosenbrock() {

    }

    private int RosenbrockFunction(int x, int y) {
      return (1 - x) ^ 2 + 100 * (y - x ^ 2) ^ 2;
    }

    private int getApproximation(int x, int y) {
      return (int)aiplayer.GetOutputs(new double[] { x, y })[0];
    }


    #region AITrainableGame implementation
    public double CalcFitness(AIPlayer aiplayer) {
      this.aiplayer = aiplayer;

      double error = 0;
      int numIterations = 0;
      for (int i = -9; i < 10; i++) {
        for (int p = -9; p < 10; p++) {
          numIterations++;
          error += Math.Abs(RosenbrockFunction(i, p) - getApproximation(i, p));
        }
      }
      return -error / numIterations;
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
  }
}

