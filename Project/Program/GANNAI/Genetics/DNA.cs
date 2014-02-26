using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GANNAI;

namespace Genetics {
  public class DNA {
    private static double mutationRate = 0.1;
    private bool[] bitstring;
    private int hashcode;

    /// <summary>
    /// Returns the length of the DNA string
    /// </summary>
    public int Length { get { return bitstring.Length; } }

    /// <summary>
    /// Constructs a random DNA string of a given length
    /// </summary>

    public DNA(int length) {
      if (length == 0)
        return;
      bitstring = new bool[length];
      for(int i = 0; i < length; i++)
        bitstring[i] = Utility.RandomBool();
      hashcode = GetHashCode();
    }

    /// <summary>
    /// Construct a DNA string with the given bitstring
    /// </summary>
    public DNA(bool[] bitstring) {
      this.bitstring = bitstring;
    }


    /// <summary>
    /// Returns the value of a particular position on the DNA string
    /// </summary>
    /// <param name="index">the position on the DNA string</param>
    public bool GetValue(int index) { 
      return bitstring[index]; 
    }


    /// <summary>
    /// Performs single point crossover between itself and another DNA string
    /// </summary>
    /// <param name="other">Other DNA string</param>
    /// <returns>A new DNA string</returns>
    public DNA GetSinglePointCrossover(DNA other) {
      if (bitstring.Length != other.bitstring.Length)
        throw new Exception("The two bitstrings to be crossed must have the same length.");

      bool[] result = new bool[bitstring.Length];
      int crossPoint = Utility.RandomInt(1, bitstring.Length-1);
      bool[] left, right;
      if (Utility.RandomBool()) {
        left = bitstring;
        right = other.bitstring;
      }
      else {
        left = other.bitstring;
        right = bitstring;
      }
      for (int i = 0; i < crossPoint; i++)
        result[i] = left[i];
      for (int i = crossPoint; i < bitstring.Length; i++)
        result[i] = right[i];
      return new DNA(result);
    }


    /// <summary>
    /// Performs two point crossover between itself and another DNA string
    /// </summary>
    /// <param name="other">Other DNA string</param>
    /// <returns>A new DNA string</returns>
    public DNA GetTwoPointCrossover(DNA other) {
      if (bitstring.Length != other.bitstring.Length)
        throw new Exception("The two bitstrings must have same length to be crossed");
      bool[] result = new bool[bitstring.Length];
      int crossPoint1 = Utility.RandomInt(1, bitstring.Length - 2);
      int crossPoint2 = Utility.RandomInt(crossPoint1+1, bitstring.Length - 1);
      bool[] left, right;
      if (Utility.RandomBool()) {
        left = bitstring;
        right = other.bitstring;
      }
      else {
        left = other.bitstring;
        right = bitstring;
      }
      for (int i = 0; i < crossPoint1; i++)
        result[i] = left[i];
      for (int i = crossPoint1 + 1; i < crossPoint2; i++)
        result[i] = right[i];
      for (int i = crossPoint2; i < bitstring.Length; i++)
        result[i] = left[i];
      return new DNA(result);
    }

    /// <summary>
    /// Performs uniform crossover between itself and another DNA string
    /// </summary>
    /// <param name="other">Other DNA string</param>
    /// <returns>A new DNA string</returns>
    public DNA GetUniformCrossover(DNA other) {
      if (bitstring.Length != other.bitstring.Length)
        throw new Exception("The two bitstrings must have same length to be crossed");
      bool[] result = new bool[bitstring.Length];
      for (int i = 0; i < bitstring.Length; i++)
        result[i] = Utility.RandomBool() ? bitstring[i] : other.bitstring[i];
      return new DNA(result);
    }

    public override bool Equals(object other) {
      if (other == this)
        return true;
      if (other.GetType() != typeof(DNA))
        return false;
      if ((other as DNA).bitstring == bitstring)
        return true;
      if ((other as DNA).hashcode != hashcode)
        return false;
      
      //real equality check here
      if (bitstring.Length != (other as DNA).bitstring.Length)
        return false;
      for (int i = 0; i < bitstring.Length; i++) {
        if (bitstring[i] != (other as DNA).bitstring[i])
          return false;
      }
      return true;
    }

    /// <summary>
    /// Returns a clone of itself
    /// </summary>
    public DNA Clone() {
      bool[] clonedBitstring = new bool[bitstring.Length];
      for (int i = 0; i < bitstring.Length; i++)
        clonedBitstring[i] = bitstring[i];
      DNA clone = new DNA(clonedBitstring);
      return clone;
    }

    /// <summary>
    /// Returns a mutated copy of 
    /// </summary>
    public DNA GetMutated() {
      DNA result = Clone();
      for (int i = 0; i < bitstring.Length; i++)
        if (Utility.RandomDouble() < mutationRate)
          bitstring[i] = !bitstring[i];
      return result;
    }

    public override int GetHashCode() {
      int hash = 0;
      for (int i = 0; i < bitstring.Length; i++)
        hash += 314189 * i * (bitstring[i] ? 1 : 0);
      return hash;
    }

    /// <summary>
    /// Calculates a signed integer from a sequence of bits on the DNA string .
    /// The index of the starting point must have a value less than the index of the ending point
    /// </summary>
    /// <param name="from">the index of the starting point</param>
    /// <param name="to">the index of the ending point</param>
    /// <returns></returns>
    public int CalcInt(int from, int to) {
      int factor = bitstring[from] ? -1 : 1;
      int result = 0;
      for (int i = 0; i < to - from; i++) {
        if (bitstring[to - i])
          result += 1 << i;
      }
      return factor * result;
    }
  }
}
