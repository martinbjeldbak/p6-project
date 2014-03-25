using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility {
  public static class Util {
    public static double ComputeMedian(List<double> l) {
      int midIndex = l.Count() / 2;
      double median;

      if ((l.Count() % 2) == 0) { 
        median = ((l.ElementAt(midIndex) + 
          l.ElementAt(midIndex - 1))/ 2); 
      }
      else { 
        median = l.ElementAt(midIndex); 
      }
      return (double)median;
    }
  }
}

