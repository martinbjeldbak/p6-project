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
      this.income = new IncomeDataset();
    }

    private double gainMedian, lossMedian = Double.NegativeInfinity;

    public double GainMedian {
      get {
        return gainMedian = (Double.IsNegativeInfinity(gainMedian) ? CapitalGainMedian() : gainMedian);
      }
    }

    public double LossMedian {
      get {
        return lossMedian = (Double.IsNegativeInfinity(lossMedian) ? CapitalLossMedian() : lossMedian);
      }
    }

    private double CapitalGainMedian() {
      List<double> gains = new List<double>();

      foreach(List<string> line in income.DataSet) {
        gains.Add(Double.Parse(line[10]));
      }

      return Util.ComputeMedian(gains.OrderBy(n => n).ToList());
    }

    private double CapitalLossMedian() {
      List<double> losses = new List<double>();

      foreach(List<string> line in income.DataSet) {
        losses.Add(Double.Parse(line[11]));
      }

      return Util.ComputeMedian(losses.OrderBy(n => n).ToList());
    }

    #region AITrainableGame implementation

    public double CalcFitness(AIPlayer aiplayer) {
      int fitness = 0;

      List<List<string>> sample = income.TestSet.Take(100).ToList();

      int lineNr = 0;

      foreach(List<string> line in sample) {
        List<double> inputs = new List<double>();
        int cols = line.Count;

        if(lineNr % 10 == 0)
          System.Console.WriteLine("On line number: " + lineNr);
        
        lineNr++;

        for(int i = 0; i < cols; i++) {
          string value = line[i];

          //if(line.IndexOf("?") != -1)
          //  continue;

          switch(i) {
            case 0:
              inputs.Add(IncomeDataset.AgeMap(value));
              break;
            case 1:
              inputs.Add(IncomeDataset.WorkClassMap(value));
              break;
            case 2:
              // Fitting weight, not needed
              break;
            case 3:
              // Education in words, case 4 is the same in years
              break;
            case 4:
              inputs.Add(IncomeDataset.EducationNumMap(value));
              break;
            case 5:
              inputs.Add(IncomeDataset.MaritalStatusMap(value));
              break;
            case 6:
              inputs.Add(IncomeDataset.OccupationMap(value));
              break;
            case 7:
              inputs.Add(IncomeDataset.RelationshipMap(value));
              break;
            case 8:
              inputs.Add(IncomeDataset.RaceMap(value));
              break;
            case 9:
              inputs.Add(IncomeDataset.SexMap(value));
              break;
            case 10:
              inputs.Add(IncomeDataset.CapitalGainMap(value, GainMedian));
              break;
            case 11:
              inputs.Add(IncomeDataset.CapitalLossMap(value, CapitalLossMedian()));
              break;
            case 12:
              inputs.Add(IncomeDataset.HoursPerWeekMap(value));
              break;
            case 13:
              inputs.Add(IncomeDataset.NativeCountryMap(value));
              break;
            case 14:
              // This is the output value we wish to guess, not part of input
              break;
            default:
              throw new Exception("No mapping of inputs");
          }
        }

        int outputIndex = aiplayer.GetStrongestOutputIndex(inputs.ToArray());

        // If the output is correct, better fitness
        if(String.Equals(IncomeDataset.IncomeMap(outputIndex), line[income.OutputIndicies().First()], StringComparison.CurrentCultureIgnoreCase)) {
          System.Console.WriteLine("Upping fitness");
          fitness++;
        }
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

