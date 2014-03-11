﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  public class DNA {
    public bool[] Bitstring { get; private set; }
    public readonly DNA Parent1, Parent2;
    public readonly double Parent1Amount, Parent2Amount;
    private int hashcode;

    /// <summary>
    /// Returns the length of the DNA string
    /// </summary>
    public int Length { get { return Bitstring.Length; } }

    /// <summary>
    /// Constructs a random DNA string of a given length
    /// </summary>
    public DNA(int length) {
      if (length == 0)
        return;
      Bitstring = new bool[length];
      for(int i = 0; i < length; i++)
        Bitstring[i] = RandomNum.RandomBool();
      hashcode = GetHashCode();
    }

    /// <summary>
    /// Construct a DNA string with the given bitstring
    /// </summary>
    public DNA(bool[] bitstring) {
      this.Bitstring = bitstring;
    }

    /// <summary>
    /// Construct a DNA string with a given bitstring and a reference to its parents
    /// as well as the amount of bits inherited from each
    /// </summary>
    public DNA(bool[] bitstring, DNA parent1, DNA parent2, double parent1Amount, double parent2Amount) {
      this.Bitstring = bitstring;
      Parent1 = parent1;
      Parent2 = parent2;
      Parent1Amount = parent1Amount;
      Parent2Amount = parent2Amount;
    }

    /// <summary>
    /// Returns the value of a particular position on the DNA string
    /// </summary>
    /// <param name="index">the position on the DNA string</param>
    public bool GetValue(int index) { 
      return Bitstring[index]; 
    }

    public override bool Equals(object other) {
      if (other == this)
        return true;
      if (other.GetType() != typeof(DNA))
        return false;
      if ((other as DNA).Bitstring == Bitstring)
        return true;
      if ((other as DNA).hashcode != hashcode)
        return false;
      
      //real equality check here
      if (Bitstring.Length != (other as DNA).Bitstring.Length)
        return false;
      for (int i = 0; i < Bitstring.Length; i++) {
        if (Bitstring[i] != (other as DNA).Bitstring[i])
          return false;
      }
      return true;
    }

    /// <summary>
    /// Returns a clone of itself
    /// </summary>
    public DNA Clone() {
      bool[] clonedBitstring = new bool[Bitstring.Length];
      for (int i = 0; i < Bitstring.Length; i++)
        clonedBitstring[i] = Bitstring[i];
      return new DNA(clonedBitstring);
    }

    /// <summary>
    /// Gets a mutated deep clone of itself
    /// </summary>
    public DNA GetMutated(double mutationRate) {
      bool[] bitstring = new bool[Bitstring.Length];
      for (int i = 0; i < Bitstring.Length; i++)
        if (RandomNum.RandomDouble() < mutationRate)
          bitstring[i] = !Bitstring[i];
      return new DNA(bitstring, this, null, 1.0, 0.0);
    }

    public override int GetHashCode() {
      int hash = 0;
      for (int i = 0; i < Bitstring.Length; i++)
        hash += 314189 * i * (Bitstring[i] ? 1 : 0);
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
      int factor = Bitstring[from] ? -1 : 1;
      int result = 0;
      for (int i = 0; i < to - from; i++) {
        if (Bitstring[to - i])
          result += 1 << i;
      }
      return factor * result;
    }
  }
}
