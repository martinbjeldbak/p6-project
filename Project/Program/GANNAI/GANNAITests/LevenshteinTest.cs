using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Utility;
using Genetics;

namespace GANNAITests {
  [TestFixture()]
  public class LevenshteinTest {
    [Test()]
    public void TestSingleDistance() {
        List<int[]> string1s = new List<int[]>();
        List<int[]> string2s = new List<int[]>();
        List<int> distances = new List<int>();

        string1s.Add(new int[] { 1, 1, 1, 0, 0, 0, 1 });
        string2s.Add(new int[] { 1, 1, 1, 0, 0, 0, 1 });
        distances.Add(0);

        string1s.Add(new int[] { 1, 0, 1, 0, 0, 0, 1 });
        string2s.Add(new int[] { 1, 1, 1, 0, 0, 0, 1 });
        distances.Add(1);

        string1s.Add(new int[] { 0, 0, 1, 1, 1, 0, 1 });
        string2s.Add(new int[] { 1, 1, 1, 0, 0, 0, 1 });
        distances.Add(4);

        string1s.Add(new int[] { 1, 1, 1, 0, 0, 0, 1 });
        string2s.Add(new int[] { 1, 1, 0, 0, 0 });
        distances.Add(2);

        Assert.AreEqual(string1s.Count, string2s.Count);
        Assert.AreEqual(string1s.Count, distances.Count);

        Genetics.DiversityMeasures.Levenshtein lev = new Genetics.DiversityMeasures.Levenshtein();
        for (int i = 0; i < string1s.Count; i++) {
            int calcedDist = lev.LevenshteinDistance(ToBitstring(string1s[i]), ToBitstring(string2s[i]));
            Assert.AreEqual(distances[i], calcedDist);
        }
    }
    private bool[] ToBitstring(int[] intArr) {
        bool[] ret = new bool[intArr.Length];
        for (int i = 0; i < intArr.Length; i++)
            ret[i] = intArr[i] == 1 ? true : false;
        return ret;
    }
  }
}



