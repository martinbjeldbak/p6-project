using NUnit.Framework;
using System;
using Genetics;
using System.Collections.Generic;

namespace GANNAITests {
  [TestFixture()]
  public class NNTDTest {
    [Test()]
    public void TestSpecieClassification() {
        Genetics.DiversityMeasures.NNTD nntd = new Genetics.DiversityMeasures.NNTD();
        Assert.AreEqual(1, nntd.CalcSpecie(new double[] { 4, 3, 2 }));
        Assert.AreEqual(7, nntd.CalcSpecie(new double[] { 34, 34, 34 }));
        Assert.AreEqual(1, nntd.CalcSpecie(new double[] { 4, -3, -13 }));
        Assert.AreEqual(1, nntd.CalcSpecie(new double[] { -2, -32, -4 }));
        Assert.AreEqual(37, nntd.CalcSpecie(new double[] {  203.3, 24, 203.3, 3.3, 49, 203.3, 29, -23232 }));
        Assert.AreEqual(32767, nntd.CalcSpecie(new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        Assert.AreEqual(973, nntd.CalcSpecie(new double[] { 1, 0, 1, 1, 0, 0, 1, 1, 1, 1 }));
    }

    [Test()]
    public void TestSimpsons() {
        Genetics.DiversityMeasures.NNTD nntd = new Genetics.DiversityMeasures.NNTD();
        Dictionary<int, int> dic;

        //test 1
        dic = new Dictionary<int, int>();
        dic.Add(4354, 23);
        dic.Add(223434, 4);
        dic.Add(1, 3);
        Assert.AreEqual(0.3977, nntd.CalcSimpsonsDiversity(dic), 0.0001);

        //test2
        dic = new Dictionary<int, int>();
        dic.Add(4354, 10);
        dic.Add(223434, 10);
        dic.Add(1, 10);
        Assert.AreEqual(0.6896, nntd.CalcSimpsonsDiversity(dic), 0.0001);

        //test3
        dic = new Dictionary<int, int>();
        dic.Add(4354, 9);
        dic.Add(223434, 10);
        dic.Add(1, 10);
        dic[4354]++;
        Assert.AreEqual(0.6896, nntd.CalcSimpsonsDiversity(dic), 0.0001);

        //test4
        dic = new Dictionary<int, int>();
        dic.Add(4354, 9);
        Assert.AreEqual(0, nntd.CalcSimpsonsDiversity(dic), 0.0001);
    }
  }
}

