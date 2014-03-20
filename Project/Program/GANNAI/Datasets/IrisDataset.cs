using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Datasets {
  public class IrisDataset : IDataset {
    private static string[] dataSetLines;

    public double ValidationPercentage { get; private set; }
    public List<List<string>> ValidationSet { get; private set; }
    public List<List<string>> TestSet { get; private set; }

    public IrisDataset() {
      ValidationSet = new List<List<string>>();
      TestSet = new List<List<string>>();

      CreateValidationTestSet();
    }

    /// <summary>
    /// Creates a new dataset with the given percentage of
    /// the dataset denoted as the valdiation set
    /// </summary>
    /// <param name="validation">Percentage of dataset to be used as validation. Range 0-1.</param>
    public IrisDataset(double validationPercent) {
      this.ValidationPercentage = validationPercent;
    }

    public double TestPercentage() {
      return 1 - ValidationPercentage;
    }

    private void CreateValidationTestSet() {
      List<List<string>> shuffledData = GetDataset().OrderBy(i => Guid.NewGuid()).ToList();

      // Get the amount of items we need from the dataset
      int validationCount = (int)Math.Floor(shuffledData.Count * ValidationPercentage);

      this.ValidationSet = shuffledData.Take(validationCount).ToList();
      this.TestSet = shuffledData.Skip(validationCount).ToList();
    }


    private List<List<string>> GetDataset() {
      string[] lines = loadCSVLines(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar.ToString() + "Resources/data-sets/Iris/Iris.csv");

      List<List<string>> lineData = new List<List<string>>();

      foreach(var line in lines) {
        string[] data = line.Split(',').ToArray();

        lineData.Add(data.ToList());
      }

      return lineData;
    }

    private string[] loadCSVLines(string loc) {
      if(dataSetLines == null) {
        dataSetLines = File.ReadAllText(loc).Split('\n');
        return dataSetLines;
      }
      else
        return dataSetLines;
    }
  }
}

