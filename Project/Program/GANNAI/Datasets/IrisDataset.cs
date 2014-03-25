using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Datasets {
  public class IrisDataset : Dataset {
    public IrisDataset(double validationPercent = 0.4)
      : base(validationPercent) {
        string csvString = Properties.Resources.iris;

        DataSet.AddRange(ParseDataFromString(csvString));

        CreateValidationAndTestSet();
    }

    public override int[] OutputIndicies() {
      return new int[] { 4 };
    }

    public override int[] InputIndicies() {
      return new int[] { 0, 1, 2, 3 };
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

