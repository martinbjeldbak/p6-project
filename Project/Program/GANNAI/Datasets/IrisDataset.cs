using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Globalization;

namespace Datasets {
  public class IrisDataset : Dataset {

    public IrisDataset(double validationPercent = 0.4)
      : base(validationPercent) {
        string csvString = Properties.Resources.iris;

        DataSet.AddRange(ParseDataFromString(csvString));

        CreateValidationAndTestSet();

        CreateMappedDataset();
        CreateMappedValidationAndTestSet();
    }

    public override int[] OutputIndicies() {
      return new int[] { 4 };
    }

    public override int[] InputIndicies() {
      return new int[] { 0, 1, 2, 3 };
    }

    protected override void CreateMappedDataset() {
      foreach(List<string> stringLine in DataSet) {
        int cols = stringLine.Count;

        Line l = new Line();
        MappedDataSet.Add(l);

        for (int i = 0; i < cols; i++) {
          switch(i) {
            case 0:
            case 1:
            case 2:
            case 3:
              l.AddEntry(new LineEntry("Col " + i, Double.Parse(stringLine[i], CultureInfo.InvariantCulture), i));
              break;
            case 4:
              l.AddEntry(new LineEntry(stringLine[i], IrisMap(stringLine[i]), i));
              break;
            default:
              throw new Exception("Row too long");
          }
        }
      }
    }

    public static int IrisMap(string irisType) {
      List<string> options = OptionsCreator("Iris-setosa", "Iris-versicolor",
        "Isis-virginica");

      return options.FindIndex(s => String.Equals(s, irisType));
    }

    private static List<string> OptionsCreator(params string[] options) {
      List<string> l = new List<string>();
      l.AddRange(options);
      return l;
    }

    public static string IrisMap(int index) {
      switch (index) {
        case 0:
          return "Iris-setosa";
        case 1:
          return "Iris-versicolor";
        case 2:
          return "Isis-virginica";
        default:
          throw new Exception("No such mapping to Iris plant");
      }
    }
  }
}

