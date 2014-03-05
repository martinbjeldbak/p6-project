using System;

namespace Utility {
  public static class RandomNum {
    private static Random random = new Random();

    /// <summary>
    /// Generates random integers
    /// </summary>
    /// <returns>A random integer betweeen the given range.</returns>
    /// <param name="s">The inclusive lower bound.</param>
    /// <param name="t">The exclusive upper bound</param>
    public static int RandomInt(int s, int t) {
      return random.Next(s, t);
    }

    /// <summary>
    /// Generates a random double i, where 0.0 <= i < 1.0
    /// </summary>
    /// <returns>A random double between 0 and 1</returns>
    public static double RandomDouble() {
      return random.NextDouble(); 
    }

    /// <summary>
    /// Generates a random boolean value.
    /// </summary>
    /// <returns>A random boolean.</returns>
    public static bool RandomBool() {
      return (random.NextDouble() >= 0.5) ? true : false;
    }
  }
}