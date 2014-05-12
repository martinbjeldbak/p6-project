using System;
using Genetics;

namespace Games {
  public class Rosenbrock : AITrainableGame {

    public Rosenbrock() {
    }

    #region AITrainableGame implementation

    public double CalcFitness(AIPlayer aiplayer) {
      double fitness = 0;
      Random r = new Random(78);
      int iterations = 10000;

      for(int i = 0; i < iterations; i++) {
        double x = r.NextDouble();
        double y = r.NextDouble();

        double output = aiplayer.GetOutputs(new double[] { x, y })[0];

        // The lower the difference of output, the better. Reward this.
          fitness += 1 / (1 + Math.Abs(RosenbrockFunction(x, y) - output * 2500));
      }

      return fitness / iterations;
    }
      
    public int NumHidden() {
      return 8;
    }

    public int BitsPerWeight() {
      return 9;
    }

    public int NumInputs() {
      return 2;
    }

    public int NumOutputs() {
      return 1;
    }

    public int BitsPerThreshold() {
        return 0;
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

    private double RosenbrockFunction(double x, double y) {
      return ((1 - x) * (1 - x)) + 100 * ((y - x * x) * (y - x * x));
    }
  }
}

