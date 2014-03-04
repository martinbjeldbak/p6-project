using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GANNAI;

namespace Genetics {
  public class UniformCrossover : CrossoverMethod{
    public DNA Cross(DNA dna1, DNA dna2) {
      if (dna1.Bitstring.Length != dna2.Bitstring.Length)
        throw new Exception("The two bitstrings must have same length to be crossed");
      bool[] result = new bool[dna1.Bitstring.Length];
      for (int i = 0; i < dna1.Bitstring.Length; i++)
        result[i] = Utility.RandomBool() ? dna1.Bitstring[i] : dna2.Bitstring[i];
      return new DNA(result);
    }
  }
}
