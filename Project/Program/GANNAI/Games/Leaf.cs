using System;
using Genetics;
using System.Collections.Generic;
using Datasets;
using System.Linq;

namespace Games {
  public class Leaf : AITrainableGame {
    LeafDataset leaf;
    
		public Leaf() {
      this.leaf = new LeafDataset(); 
		}

    #region AITrainableGame implementation

    public double CalcFitness(AIPlayer aiplayer) {
      int fitness = 0;
      int numInputs = NumInputs();
      int outputIndex = 0;
      List<double> inputs;
      
      foreach(Line row in leaf.MappedDataSet) {
        inputs = new List<double>(numInputs);
        inputs.AddRange(row.entries.Where(e => e.Column >= 2).Select(e => e.Value));
        
        int outputNeuron = aiplayer.GetStrongestOutputIndex(inputs.ToArray());
        if(outputNeuron == row.entries[outputIndex].Value)
          fitness++;
      }
      return fitness;
    }

    public int NumInputs() {
      return leaf.InputIndicies().Count();
    }

    public int NumOutputs() {
      return 40;
    }
    public int NumHidden() {
        return 10;
    }
    public int BitsPerWeight() {
        return 9;
    }
    public int BitsPerBias() {
        return 0;
    }
    public AITrainableGame GetNewGameInstance() {
      return this;
    }

    public void Visualize(AIPlayer aiplayer, System.Windows.Forms.Form form) {
      throw new NotImplementedException();
    }

    public string Name() {
      return "Leaf Classification";
    }

    #endregion
	}
}

