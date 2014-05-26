using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  public class UniformCrossover : CrossoverMethod{
    public override Chromosome Cross(Chromosome chromosome1, Chromosome chromosome2) {
      if (chromosome1.Bitstring.Length != chromosome2.Bitstring.Length)
        throw new Exception("The two bitstrings must have same length to be crossed");
      bool[] result = new bool[chromosome1.Bitstring.Length];
      int ancestor1bits = 0;
      for (int i = 0; i < chromosome1.Bitstring.Length; i++){
        if (RandomNum.RandomBool()) {
          result[i] = chromosome1.Bitstring[i];
          ancestor1bits++;
        }
        else {
          result[i] = chromosome2.Bitstring[i];
        }
      }


      //return the new chromosome string
      return new Chromosome(result);
    }
  }
}
