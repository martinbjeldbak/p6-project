using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GANNAI {
  public class DNA {
    private bool[] bitstring;
    public DNA(int length) {
      bitstring = new bool[length];
      Random random = new Random();
      for (int i = 0; i < length; i++)
        bitstring[i] = random.Next(0, 2) == 1 ? true : false;
    }

    public DNA SinglePointCrossover(DNA other) {
      return null;
    }
    public DNA TwoPointCrossover(DNA other) {
      return null;
    }
    public DNA UniformCrossover(DNA other) {
      return null;
    }
  }
}
