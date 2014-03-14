using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Genetics;

namespace GANNAITests {
    [TestFixture()]
    public class RankMethodTest {
      [Test()]
      public void TestLinearMethod() {
        LinearRankMethod rm = new LinearRankMethod();
        int[] results = new int[100];
        for (int i = 0; i < 10000; i++) {
          results[rm.GetRandomIndex(100)]++;
        }
        Assert.IsTrue(results[0] > results[99]);
      }
    }
}
