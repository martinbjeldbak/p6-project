using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  /// <summary>
  /// With decreaseFactor d, out of 5 indexes (0, 1, 2, 4, 5) the chance for each index to be selected
  /// is (1, d, d^2, d^3, d^4)
  /// </summary>
  public class HalvingRankMethod : RankMethod {

    private double decreaseFactor;

    /// <summary>
    /// Creates a new rank method where the chance any next index to be selected always decreases
    /// by a factor
    /// </summary>
    /// <param name="decreaseFactor">The decreasing factor</param>
    public HalvingRankMethod() {
      this.decreaseFactor = 0.5;
    }

    public int GetRandomIndex(int num) {
      double sum = 0;
      double add = 0.5;
      for (int i = 0; i < num; i++) {
        sum += add;
        add *= decreaseFactor;
      }
      double ran = RandomNum.RandomDouble()*sum;
      double subtract = decreaseFactor;
      for (int i = 0; i < num; i++) {
        ran -= subtract;
        if (ran < 0)
          return i;
        subtract *= decreaseFactor;
      }
      return num - 1;
    }
  }
}
