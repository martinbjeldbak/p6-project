using System;
using Genetics;

namespace Games {
  public class Leaf :AITrainableGame {
		public Leaf() {
		}

    #region AITrainableGame implementation

    public double CalcFitness(AIPlayer aiplayer) {
      throw new NotImplementedException();
    }

    public int NumInputs() {
      throw new NotImplementedException();
    }

    public int NumOutputs() {
      throw new NotImplementedException();
    }

    public AITrainableGame GetNewGameInstance() {
      throw new NotImplementedException();
    }

    public void Visualize(AIPlayer aiplayer, System.Windows.Forms.Form form) {
      throw new NotImplementedException();
    }

    public string Name() {
      throw new NotImplementedException();
    }

    #endregion
	}
}

