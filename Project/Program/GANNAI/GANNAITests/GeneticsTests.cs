using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Genetics;

namespace TestArtificialNeuralNetwork {
  class GeneticsTests {

    [TestFixture()]
    public class ArtificialNeuralNetworkTest {
      [Test()]
      public void BasicStructureTest() {
        DNA a = new DNA(1000);
        DNA b = new DNA(1000);
        DNA c = a.GetSinglePointCrossover(b);
        for (int i = 0; i < c.Length; i++) {
          Assert.True(c.GetValue(i) == a.GetValue(i) || c.GetValue(i) == b.GetValue(i));
        }
      }
    }

  }
}
