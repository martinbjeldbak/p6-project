using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Genetics;
using Datasets;
using Utility;

namespace Games {
  public class Income : AITrainableGame {
    IncomeDataset income;

    public Income() {
      income = new IncomeDataset();
    }

    #region AITrainableGame implementation

    public double CalcFitness(AIPlayer aiplayer) {
      int fitness = 0;
 
      int numInputs = NumInputs();
      List<double> inputs = new List<double>(numInputs);
      // For each row in the data set, get its converted values
      foreach(Line l in income.MappedDataSet) {

        inputs = new List<double>(numInputs);
        inputs.AddRange(l.entries.Where(e => !income.OutputIndicies().ToList().Contains(e.Column)).Select(e => e.Value));


        int outputNeuronIndex = aiplayer.GetStrongestOutputIndex(inputs.ToArray());


        //System.Console.WriteLine("Is the strongest output neuron: " + outputNeuronIndex + "(" + IncomeDataset.IncomeMap(outputNeuronIndex) + ") equal to: " + l.entries.Last().ID + "(" + l.entries.Last().Value + ")?");
        if(outputNeuronIndex == l.entries.Last().Value)
          fitness++;
      }

      return fitness;
    }

    public int NumInputs() {
      return income.InputIndicies().Count();
    }

    public int NumOutputs() {
      return 2;
    }

    public AITrainableGame GetNewGameInstance() {
        return this;
    }

    public void Visualize(AIPlayer aiplayer, System.Windows.Forms.Form form) {
      throw new NotImplementedException();
    }

    public string Name() {
      return "Adult income";
    }

    #endregion
  }
}

