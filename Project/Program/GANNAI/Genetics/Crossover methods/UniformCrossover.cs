using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  public class UniformCrossover : CrossoverMethod{
    public override DNA Cross(DNA dna1, DNA dna2) {
      if (dna1.Bitstring.Length != dna2.Bitstring.Length)
        throw new Exception("The two bitstrings must have same length to be crossed");
      bool[] result = new bool[dna1.Bitstring.Length];
      int ancestor1bits = 0;
      for (int i = 0; i < dna1.Bitstring.Length; i++){
        if (RandomNum.RandomBool()) {
          result[i] = dna1.Bitstring[i];
          ancestor1bits++;
        }
        else {
          result[i] = dna2.Bitstring[i];
        }
      }

      //calc how much is inherited from each ancestor and save that result
      double ancestor1Amount = (double)ancestor1bits / dna1.Bitstring.Length;

      //return the new DNA string
      return new DNA(result, dna1, dna2, ancestor1Amount, 1.0 - ancestor1Amount);
    }
  }
}
