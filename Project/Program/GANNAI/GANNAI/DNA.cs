using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GANNAI;

namespace GANNAI {
  public class DNA {
    private bool[] bitstring;
    private int hashcode;

    //Constructs a random DNA string matching the length of the neural network architecthure we need
    public DNA() : this(100){
      //TODO: How long is such a string?
    }

    //Constructs a random DNA string of a given length
    public DNA(int length) {
      bitstring = new bool[length];
      for(int i = 0; i < length; i++)
        bitstring[i] = Utility.RandomBool();
      hashcode = GetHashCode();
    }

    //Construct a DNA string with the given bitstring
    public DNA(bool[] bitstring) {
      this.bitstring = bitstring;
    }

    public DNA SinglePointCrossover(DNA other) {
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

    public DNA TwoPointCrossover(DNA other) {
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
    public DNA UniformCrossover(DNA other) {
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

    //Returns a deep copy of itself
    public DNA Clone() {
      bool[] clonedBitstring = new bool[bitstring.Length];
      for (int i = 0; i < bitstring.Length; i++)
        clonedBitstring[i] = bitstring[i];
      DNA clone = new DNA(clonedBitstring);
      return clone;
    }

    public override int GetHashCode() {
      int hash = 0;
      for (int i = 0; i < bitstring.Length; i++)
        hash += 314189 * i * (bitstring[i] ? 1 : 0);
      return hash;
    }
  }
}
