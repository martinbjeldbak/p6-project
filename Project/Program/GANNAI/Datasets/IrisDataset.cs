using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Datasets {
  public class IrisDataset : Dataset {
    public IrisDataset(double validationPercent)
      : base(validationPercent) {
        string csvString = Properties.Resources.iris;
        CreateValidationAndTestSet(ParseDataFromString(csvString));
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

