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

      int lineNr = 0;
      int numInputs = NumInputs();
      int outputIndex = income.OutputIndicies()[0];
      List<double> inputs = new List<double>(numInputs);
      // For each row in the data set, get its converted values
      foreach (Line l in income.MappedTestSet) {
        System.Console.WriteLine("On line " + (lineNr++) + 1);

        inputs = new List<double>(numInputs);
        inputs.AddRange(l.entries.Where(e => !income.OutputIndicies().ToList().Contains(e.Column)).Select(e => e.ID));

        int outputNeuron = aiplayer.GetStrongestOutputIndex(inputs.ToArray());

        if (outputNeuron == l.entries[outputIndex].ID)
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
      throw new NotImplementedException();
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

