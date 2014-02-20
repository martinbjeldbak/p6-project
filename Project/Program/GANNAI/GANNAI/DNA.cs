using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
      Random random = new Random();
      for (int i = 0; i < length; i++)
        bitstring[i] = random.Next(0, 2) == 1 ? true : false;
      hashcode = GetHashCode();
    }

    //Construct a DNA string with the given bitstring
    public DNA(bool[] bitstring) {
      this.bitstring = bitstring;
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
