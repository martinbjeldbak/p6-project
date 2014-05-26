using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Genetics;

namespace GANNAITests {
    [TestFixture()]
    public class ChromosomeTests {
      [Test()]
      public void TestCalcInt() {
        Chromosome a;

        a = new Chromosome(ToBitString(new int[]{1,0,0,1,1,0,1,0,1,1,1,1,0,1,0,1}));
        Assert.AreEqual(15, a.CalcInt(7, 11));

        a = new Chromosome(ToBitString(new int[] {0,1,0,1,1,1,0,0,1,1,1,0,0,1,1,1 }));
        Assert.AreEqual(-25, a.CalcInt(3, 8));

        a = new Chromosome(ToBitString(new int[] {1,0,1,0,1,0,0,1,1,1,0,1,1,1,0,1}));
        Assert.AreEqual(-41, a.CalcInt(0, 7));

        a = new Chromosome(ToBitString(new int[] { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0}));
        Assert.AreEqual(32, a.CalcInt(0, 15));

        a = new Chromosome(ToBitString(new int[] {1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0 }));
        Assert.AreEqual(21, a.CalcInt(5, 10));

        a = new Chromosome(ToBitString(new int[] { 0,1,0,1,0,1,1,1,0,1,1,1,0,0,1,1 }));
        Assert.AreEqual(59, a.CalcInt(4, 10));
      }

      bool[] ToBitString(int[] intstring) {
        bool[] result = new bool[intstring.Length];
        for (int i = 0; i < intstring.Length; i++)
          result[i] = intstring[i] == 1 ? true : false;
        return result;
      }
    }
}
