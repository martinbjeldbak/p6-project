using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  public class SinglePointCrossover : CrossoverMethod {

    public override Chromosome Cross(Chromosome chromosome1, Chromosome chromosome2) {
      if (chromosome1.Bitstring.Length != chromosome2.Bitstring.Length)
        throw new Exception("The two bitstrings to be crossed must have the same length.");

      bool[] result = new bool[chromosome1.Bitstring.Length];
      int crossPoint = RandomNum.RandomInt(1, chromosome1.Bitstring.Length - 1);
      bool[] left, right;
      if (RandomNum.RandomBool()) {
        left = chromosome1.Bitstring;
        right = chromosome2.Bitstring;
      }
      else {
        left = chromosome2.Bitstring;
        right = chromosome1.Bitstring;
      }
      for (int i = 0; i < crossPoint; i++)
        result[i] = left[i];
      for (int i = crossPoint; i < chromosome1.Bitstring.Length; i++)
        result[i] = right[i];

      //return new chromosome
      return new Chromosome(result);
    }
  }
}

