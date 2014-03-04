using NUnit.Framework;
using System;
using Genetics;

namespace GANNAITests {
  [TestFixture()]
  public class ConfigurationTests {
    [Test()]
    public void TestAllowedCrossoverMethods() {

      //These tests must be rewritten - gl&hf :)
      Assert.AreEqual(true, false);

      /*
      Configuration.AllowSinglePointCrossover = true;
      Assert.AreEqual(Configuration.AllowSinglePointCrossover, true);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetSinglePointCrossover), true);
      Configuration.AllowTwoPointCrossover = true;
      Assert.AreEqual(Configuration.AllowTwoPointCrossover, true);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetTwoPointCrossover), true);
      Configuration.AllowUniformCrossover = true;
      Assert.AreEqual(Configuration.AllowUniformCrossover, true);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetUniformCrossover), true);

      Configuration.AllowSinglePointCrossover = true;
      Assert.AreEqual(Configuration.AllowSinglePointCrossover, true);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetSinglePointCrossover), true);
      Configuration.AllowTwoPointCrossover = true;
      Assert.AreEqual(Configuration.AllowTwoPointCrossover, true);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetTwoPointCrossover), true);
      Configuration.AllowUniformCrossover = true;
      Assert.AreEqual(Configuration.AllowUniformCrossover, true);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetUniformCrossover), true);

      Configuration.AllowSinglePointCrossover = false;
      Assert.AreEqual(Configuration.AllowSinglePointCrossover, false);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetSinglePointCrossover), false);
      Configuration.AllowTwoPointCrossover = false;
      Assert.AreEqual(Configuration.AllowTwoPointCrossover, false);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetTwoPointCrossover), false);
      Configuration.AllowUniformCrossover = false;
      Assert.AreEqual(Configuration.AllowUniformCrossover, false);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetUniformCrossover), false);

      Configuration.AllowSinglePointCrossover = false;
      Assert.AreEqual(Configuration.AllowSinglePointCrossover, false);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetSinglePointCrossover), false);
      Configuration.AllowTwoPointCrossover = false;
      Assert.AreEqual(Configuration.AllowTwoPointCrossover, false);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetTwoPointCrossover), false);
      Configuration.AllowUniformCrossover = false;
      Assert.AreEqual(Configuration.AllowUniformCrossover, false);
      Assert.AreEqual(AIPlayer.IsCrossoverMethodAllowed(AIPlayer.GetUniformCrossover), false);
      */
    }
  }
}

