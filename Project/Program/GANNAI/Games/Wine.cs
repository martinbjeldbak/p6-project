using System;
using Genetics;
using System.Collections.Generic;
using Datasets;
using System.Linq;

namespace Games {
  public class Wine : AITrainableGame  {
    WineDataset wine;
    
    public Wine() {
      this.wine = new WineDataset();
    }

    #region AITrainableGame implementation

    public double CalcFitness(AIPlayer aiplayer) {
      int fitness = 0;
      int numInputs = NumInputs();
      int outputIndex = 0;
      List<double> inputs;
      
      foreach(Line row in wine.MappedDataSet) {
        inputs = new List<double>(numInputs);
        inputs.AddRange(row.entries.Where(e => e.Column > 0).Select(e => e.Value));
        
        int outputNeuron = aiplayer.GetStrongestOutputIndex(inputs.ToArray());
        if(outputNeuron == row.entries[outputIndex].Value)
          fitness++;
      }
      return fitness;
    }

    public int NumInputs() {
      return wine.InputIndicies().Count();
    }

    public int NumOutputs() {
      return 3;
    }
    public int NumHidden() {
        return 10;
    }
    public int BitsPerWeight() {
        return 9;
    }

    public AITrainableGame GetNewGameInstance() {
      return this;
    }

    public void Visualize(AIPlayer aiplayer, System.Windows.Forms.Form form) {
      throw new NotImplementedException();
    }

    public string Name() {
      return "Wine Classification";
    }

    #endregion
  }
}

