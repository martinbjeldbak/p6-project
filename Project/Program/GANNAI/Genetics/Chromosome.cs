using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Genetics {
  public class Chromosome {
    public bool[] Bitstring { get; private set; }
    private int hashcode;

    /// <summary>
    /// Returns the length of the chromosome string
    /// </summary>
    public int Length { get { return Bitstring.Length; } }

    /// <summary>
    /// Constructs a random chromosome string of a given length
    /// </summary>
    public Chromosome(int length) {
      if (length == 0)
        return;
      Bitstring = new bool[length];
      for(int i = 0; i < length; i++)
        Bitstring[i] = RandomNum.RandomBool();
      hashcode = GetHashCode();
    }

    /// <summary>
    /// Construct a Chromosome string with the given bitstring
    /// </summary>
    public Chromosome(bool[] bitstring) {
      this.Bitstring = bitstring;
    }

    /// <summary>
    /// Construct a Chromosome string with a given bitstring and a reference to its parents
    /// as well as the amount of bits inherited from each
    /// </summary>
    public Chromosome(string bitstring) {
        Bitstring = new bool[bitstring.Length];
        for (int i = 0; i < bitstring.Length; i++) {
            Bitstring[i] = bitstring[i] == '1' ? true : false; 
        }
    }

    /// <summary>
    /// Returns the value of a particular position on the Chromosome string
    /// </summary>
    /// <param name="index">the position on the Chromosome string</param>
    public bool GetValue(int index) { 
      return Bitstring[index]; 
    }

    public override bool Equals(object other) {
      if (other == this)
        return true;
      if (other.GetType() != typeof(Chromosome))
        return false;
      if ((other as Chromosome).Bitstring == Bitstring)
        return true;
      if ((other as Chromosome).hashcode != hashcode)
        return false;
      
      //real equality check here
      if (Bitstring.Length != (other as Chromosome).Bitstring.Length)
        return false;
      for (int i = 0; i < Bitstring.Length; i++) {
        if (Bitstring[i] != (other as Chromosome).Bitstring[i])
          return false;
      }
      return true;
    }

    /// <summary>
    /// Returns a clone of itself
    /// </summary>
    public Chromosome Clone() {
      bool[] clonedBitstring = new bool[Bitstring.Length];
      for (int i = 0; i < Bitstring.Length; i++)
        clonedBitstring[i] = Bitstring[i];
      return new Chromosome(clonedBitstring);
    }

    /// <summary>
    /// Gets a mutated deep clone of itself according to a mutation rate in the range [0.0-1.0]
    /// </summary>
    /// <param name="mutationRate">The chance for each bit to be set to a a random value</param>
    /// <returns></returns>
    public Chromosome GetMutated(double mutationRate) {
      bool[] bitstring = new bool[Bitstring.Length];

      //if mutation rate is 1 or more, return a random Chromosome
      if (mutationRate >= 1.0)
          return new Chromosome(this.Length);

      for (int i = 0; i < Bitstring.Length; i++)
        if (RandomNum.RandomDouble() < mutationRate)
          bitstring[i] = RandomNum.RandomBool();
      return new Chromosome(bitstring);
    }

    public override int GetHashCode() {
      int hash = 0;
      for (int i = 0; i < Bitstring.Length; i++)
        hash += 314189 * i * (Bitstring[i] ? 1 : 0);
      return hash;
    }

    /// <summary>
    /// Calculates a signed integer from a sequence of bits on the Chromosome string.
    /// For a 5 bit string, a value is returned in the range [-8, 8]
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

    /// <summary>
    /// Calculates a double from a sequence of bits on the Chromosome string.
    /// A value is returned in the range [-5, 5].
    /// More bits adds more precision.
    /// </summary>
    /// <param name="from">the index of the first bit in the sequence</param>
    /// <param name="to">the index of the last bit in the sequence</param>
    /// <returns></returns>
    public double CalcDouble(int from, int to)
    {
        if (to < from)
            throw new Exception("Error when calculating double from bit string. To is less than from. To: " + to + " From: " + from);
        if (from < 0)
            throw new Exception("Error when calculating double from bit string. From was less than 0. From: " + from);
        if (to >= Length)
            throw new Exception("Error when calculating double from bit string. To was greater than Chromosome length: " + Length);
        
        //find out how many bits are used in the increasing sequence of powers of two
        int aggregateBits = from == to ? 1 : to - from; //If length is only 1 bit, that bit will be used for both negation and aggregation
        double maxVal = Math.Pow(2, aggregateBits) - 1;
        int result = 0;
        for (int i = 0; i < aggregateBits; i++) //sum power of 2's from aggregate bits
        {
            if (Bitstring[to - i])
                result += 1 << i;
        }

        //negate if sign bit is set
        result *= Bitstring[from] ? -1 : 1;

        //normalize to range [-1, 1]
        double normalized = result / maxVal;

        //transform to range [-5, 5] which is where sigmoid changes most
        return normalized * 5;
    }
  }
}
