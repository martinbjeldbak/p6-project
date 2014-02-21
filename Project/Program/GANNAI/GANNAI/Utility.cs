using System;
using System.Text;
using System.Collections.Generic;

namespace GANNAI {
  public static class Utility {
    //random operator
    private static Random random = new Random();

    //return random integer
    public static int RandomInt(int s, int t) {
      return random.Next(s, t);
    }

    //return random double
    public static double RandomDouble() {
      return random.NextDouble(); 
    }

    //return random bool
    public static bool RandomBool() {
      return (random.NextDouble() >= 0.5) ? true : false;
    }
  }
}

