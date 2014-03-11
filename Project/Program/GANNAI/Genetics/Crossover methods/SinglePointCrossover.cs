using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  public class SinglePointCrossover : CrossoverMethod {

    public override DNA Cross(DNA dna1, DNA dna2) {
      if (dna1.Bitstring.Length != dna2.Bitstring.Length)
        throw new Exception("The two bitstrings to be crossed must have the same length.");

      bool[] result = new bool[dna1.Bitstring.Length];
      int crossPoint = RandomNum.RandomInt(1, dna1.Bitstring.Length - 1);
      bool[] left, right;
      if (RandomNum.RandomBool()) {
        left = dna1.Bitstring;
        right = dna2.Bitstring;
      }
      else {
        left = dna2.Bitstring;
        right = dna1.Bitstring;
      }
      for (int i = 0; i < crossPoint; i++)
        result[i] = left[i];
      for (int i = crossPoint; i < dna1.Bitstring.Length; i++)
        result[i] = right[i];

      //calc how much is derived from each ancestor
      double ancestor1amount = (double)crossPoint / dna1.Bitstring.Length;
      if (left == dna2.Bitstring)
        ancestor1amount = 1.0 - ancestor1amount;

      //return new DNA
      return new DNA(result, dna1, dna2, ancestor1amount, 1.0 - ancestor1amount);
    }
  }
}

