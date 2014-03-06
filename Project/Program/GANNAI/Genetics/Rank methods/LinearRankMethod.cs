using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  /// <summary>
  /// Out of 5 indexes (0, 1, 2, 4, 5) the chance for each index to be selected
  /// is (5/15, 4/15, 3/15, 2/15, 1/15)
  /// </summary>
  public class LinearRankMethod : RankMethod {
    public int GetRandomIndex(int num) {
      int sum = num * (num + 1) / 2;
      int ran = RandomNum.RandomInt(0, sum);
      int subtract = num;
      for (int i = 0; i < num; i++) {
        ran -= subtract;
        if (ran < 0)
          return i;
        subtract--;
      }
      throw new Exception("Some index should have been selected before reaching this point");
    }
  }
}
