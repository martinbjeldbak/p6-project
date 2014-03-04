using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GANNAI;

namespace Genetics {
  public class TwoPointCrossover : CrossoverMethod {
    public DNA Cross(DNA dna1, DNA dna2) {
      if (dna1.Bitstring.Length != dna2.Bitstring.Length)
        throw new Exception("The two bitstrings must have same length to be crossed");
      bool[] result = new bool[dna1.Bitstring.Length];
      int crossPoint1 = Utility.RandomInt(1, dna1.Bitstring.Length - 2);
      int crossPoint2 = Utility.RandomInt(crossPoint1 + 1, dna1.Bitstring.Length - 1);
      bool[] left, right;
      if (Utility.RandomBool()) {
        left = dna1.Bitstring;
        right = dna2.Bitstring;
      }
      else {
        left = dna2.Bitstring;
        right = dna1.Bitstring;
      }
      for (int i = 0; i < crossPoint1; i++)
        result[i] = left[i];
      for (int i = crossPoint1 + 1; i < crossPoint2; i++)
        result[i] = right[i];
      for (int i = crossPoint2; i < dna1.Length; i++)
        result[i] = left[i];
        return new DNA(result);
    }
  }
}

