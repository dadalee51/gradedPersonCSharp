using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGradeScore
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(2,2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("Fellow".ToUpper(), "FELLOW".ToUpper());
        }
    }
}
