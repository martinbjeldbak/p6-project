using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datasets {
  public abstract class Dataset {
    public double ValidationPercentage { get; private set; }
    public List<List<string>> ValidationSet { get; private set; }
    public List<List<string>> TestSet { get; private set; }
    public double TestPercentage {
      get {
        return 1 - this.ValidationPercentage;
      }
    }

    /// <summary>
    /// Creates a new dataset with the given percentage of
    /// the dataset denoted as the valdiation set
    /// </summary>
    /// <param name="validation">Percentage of dataset to be used as validation. Range 0-1.</param>
    protected Dataset(double validationPercent = 0.4) {
      ValidationSet = new List<List<string>>();
      TestSet = new List<List<string>>();
      this.ValidationPercentage = validationPercent;
    }

    protected void CreateValidationAndTestSet(List<List<string>> dataSet) {
      List<List<string>> shuffledData = dataSet.OrderBy(i => Guid.NewGuid()).ToList();

      // Get the amount of items we need from the dataset to put in our validation set
      int validationCount = (int)Math.Floor(shuffledData.Count * ValidationPercentage);

      this.ValidationSet = shuffledData.Take(validationCount).ToList();
      this.TestSet = shuffledData.Skip(validationCount).ToList();
    }

    protected List<List<string>> ParseDataFromString(string csvString) {
      List<string> lines = loadCSVLines(csvString);

      List<List<string>> lineData = new List<List<string>>();

      foreach (var line in lines) {
        string[] data = line.Split(',').ToArray();

        lineData.Add(data.ToList());
      }

      return lineData;
    }

    protected List<string> loadCSVLines(string csv) {
      return csv.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
    }
  }
}
