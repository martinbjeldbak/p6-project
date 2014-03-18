using System;
using Genetics;

namespace Games {
  public class Rosenbrock : AITrainableGame {
    AIPlayer aiplayer;
    int x, y;

    public Rosenbrock() {
      x = 10;
      y = 10;
    }

    private int RosenbrockFunction(int x, int y) {
      return (1 - x) ^ 2 + 100 * (y - x ^ 2) ^ 2;
    }

    private int getApproximation() {
      return aiplayer.GetOutput(new double[] { x, y });
    }


    #region AITrainableGame implementation
    public double CalcFitness(AIPlayer aiplayer) {
      this.aiplayer = aiplayer;

      // How do you reward it for getting close to the function? Ie the result of
      // the subtraction is 0
      return Math.Abs(RosenbrockFunction(x, y) - getApproximation());
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

