using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Genetics;

namespace GANNAITests {
    [TestFixture()]
    public class GeneticsTests {
      [Test()]
      public void TestDNA() {
        DNA a = new DNA(1000);
        DNA b = new DNA(1000);
        SinglePointCrossover spc = new SinglePointCrossover();
        DNA c = spc.Cross(a, b);
        for (int i = 0; i < c.Length; i++) {
          Assert.IsTrue(c.GetValue(i) == a.GetValue(i) || c.GetValue(i) == b.GetValue(i));
        }
      }
    }
}
