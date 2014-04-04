using System;
using Genetics;
using System.Collections.Generic;
using Datasets;
using System.Linq;

namespace Games {
  public class Bankruptcy : AITrainableGame {
    BankruptcyDataset bankruptcy;
    
    public Bankruptcy(){
      this.bankruptcy = new BankruptcyDataset();
    }

    #region AITrainableGame implementation

    public double CalcFitness(AIPlayer aiplayer) {
      int fitness = 0;
      int numInputs = NumInputs();
      int outputIndex = 0;
      List<double> inputs;
      
      foreach(Line row in bankruptcy.MappedDataSet) {
        inputs = new List<double>(numInputs);
        inputs.AddRange(row.entries.Where(e => e.Column < 6).Select(e => e.Value));
        
        int outputNeuron = aiplayer.GetStrongestOutputIndex(inputs.ToArray());
        if(outputNeuron == row.entries[outputIndex].Value)
          fitness++;
      }
      return fitness;
    }

    public int NumInputs() {
      return bankruptcy.InputIndicies().Count();
    }

    public int NumOutputs() {
      return 2;
    }

    public AITrainableGame GetNewGameInstance() {
      return new Bankruptcy();
    }

    public void Visualize(AIPlayer aiplayer, System.Windows.Forms.Form form) {
      throw new NotImplementedException();
    }

    public string Name() {
      return "Bankruptcy Classification";
    }

    #endregion
  }
}

