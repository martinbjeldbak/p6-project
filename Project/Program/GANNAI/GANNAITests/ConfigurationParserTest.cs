using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Genetics;
using GANNAI;

namespace GANNAITests {
    [TestFixture()]
    public class ConfigurationParserTest {
        [Test()]
        public void TestParse() {
            ConfigurationParser cp = new ConfigurationParser(new string[]{"2, 3", "-3", "[1.2-1.4]:0.1"});
            Assert.IsTrue(ListEquals(cp.getNextConfiguration(), new double[] { 2, -3, 1.2 }));
            Assert.IsTrue(ListEquals(cp.getNextConfiguration(), new double[] { 3, -3, 1.2 }));
            Assert.IsTrue(ListEquals(cp.getNextConfiguration(), new double[] { 2, -3, 1.3 }));
            Assert.IsTrue(ListEquals(cp.getNextConfiguration(), new double[] { 3, -3, 1.3 }));
            Assert.IsTrue(ListEquals(cp.getNextConfiguration(), new double[] { 2, -3, 1.4 }));
            Assert.IsTrue(ListEquals(cp.getNextConfiguration(), new double[] { 3, -3, 1.4 }));
            Assert.AreEqual(cp.getNextConfiguration(), null);
        }

        private bool ListEquals(double[] l1, double[] l2) {
            if (l1.Length != l2.Length)
                return false;
            for (int i = 0; i < l1.Length; i++) {
                if (l1[i] != l2[i]) {
                    return false;
                }
            }
            return true;
        }
    }
}
