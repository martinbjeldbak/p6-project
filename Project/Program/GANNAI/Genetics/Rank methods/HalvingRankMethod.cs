using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  /// <summary>
  /// Out of 5 indexes (0, 1, 2, 4, 5) the chance for each index to be selected
  /// is (0.5, 0.25, 0.125, 0.0625, 0.03125)
  /// </summary>
  public class HalvingRankMethod : RankMethod {
    public int GetRandomIndex(int num) {
      double sum = 0;
      double add = 0.5;
      for (int i = 0; i < num; i++) {
        sum += add;
        add /= 2;
      }
      double ran = RandomNum.RandomDouble()*sum;
      int index = 0;
      for (int i = 0; i < num; i++) {
        ran -= (i + 1);
        if (ran <= 0)
          return index;
        index++;
      }
      return index;
    }
  }
}
