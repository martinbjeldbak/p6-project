using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  public class TwoPointCrossover : CrossoverMethod {
    public override DNA Cross(DNA dna1, DNA dna2) {
      if (dna1.Bitstring.Length != dna2.Bitstring.Length)
        throw new Exception("The two bitstrings must have same length to be crossed");
      bool[] result = new bool[dna1.Bitstring.Length];
      int crossPoint1 = RandomNum.RandomInt(1, dna1.Bitstring.Length - 2);
      int crossPoint2 = RandomNum.RandomInt(crossPoint1 + 1, dna1.Bitstring.Length - 1);
      bool[] left, right;
      if (RandomNum.RandomBool()) {
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

      //calc how much is derived from each ancestor
      double ancestor1amount = (double)(crossPoint1 + dna1.Bitstring.Length - crossPoint2) / dna1.Bitstring.Length;
      if (left == dna2.Bitstring)
        ancestor1amount = 1.0 - ancestor1amount;

      LastCrossAncestorLink = new AncestorLink(dna1, dna2, ancestor1amount, 1.0 - ancestor1amount);

      //return new dna
      return new DNA(result);
    }
  }
}

