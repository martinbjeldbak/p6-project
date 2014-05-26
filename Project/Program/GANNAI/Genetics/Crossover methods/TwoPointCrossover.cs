using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  public class TwoPointCrossover : CrossoverMethod {
    public override Chromosome Cross(Chromosome chromosome1, Chromosome chromosome2) {
      if (chromosome1.Bitstring.Length != chromosome2.Bitstring.Length)
        throw new Exception("The two bitstrings must have same length to be crossed");
      bool[] result = new bool[chromosome1.Bitstring.Length];
      int crossPoint1 = RandomNum.RandomInt(1, chromosome1.Bitstring.Length - 2);
      int crossPoint2 = RandomNum.RandomInt(crossPoint1 + 1, chromosome1.Bitstring.Length - 1);
      bool[] left, right;
      if (RandomNum.RandomBool()) {
        left = chromosome1.Bitstring;
        right = chromosome2.Bitstring;
      }
      else {
        left = chromosome2.Bitstring;
        right = chromosome1.Bitstring;
      }
      for (int i = 0; i < crossPoint1; i++)
        result[i] = left[i];
      for (int i = crossPoint1 + 1; i < crossPoint2; i++)
        result[i] = right[i];
      for (int i = crossPoint2; i < chromosome1.Length; i++)
        result[i] = left[i];

      //return new chromosome
      return new Chromosome(result);
    }
  }
}

