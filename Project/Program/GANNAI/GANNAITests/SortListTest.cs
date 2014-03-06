using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Utility;
using Genetics;

namespace GANNAITests {
  [TestFixture()]
  public class SortListTest {
    [Test()]
    public void TestBigSingleList() {
      SortList<int> list = new SortList<int>();
      for (int i = 0; i < 1000; i++)
        list.Add(Utility.RandomNum.RandomInt(0, 1000));
      Assert.AreEqual(1000, list.Count);
      int last = Int32.MaxValue;
      for (int i = 0; i < 1000; i++) {
        Assert.IsTrue(list.Get(i) <= last);
        last = list.Get(i);
      }
      list.Clear();
      Assert.AreEqual(list.Count, 0);
    }

    [Test()]
    public void TestSmallSingleList() {
      SortList<int> list = new SortList<int>();
      for (int i = 0; i < 20; i++) {
        list.Clear();
        for (int p = 0; p < i; p++) {
          list.Add(Utility.RandomNum.RandomInt(0, 1000));
        }
        int last = Int32.MaxValue;
        for (int q = 0; q < i; q++) {
          Assert.IsTrue(list.Get(q) <= last);
          last = list.Get(q);
        }
      }
    }
  }
}



