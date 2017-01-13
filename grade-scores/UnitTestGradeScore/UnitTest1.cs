using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using grade_scores;
using System.Collections.Generic;

namespace UnitTestGradeScore
{
    [TestClass]
    public class UnitTest1
    {
        List<Person> lp, rp; 
        [TestInitialize]
        public void TestInitialize()
        {
            //this is unsorted order
            rp = new List<Person>();
            rp.Add(new Person("KING", "MADISON", 88));
            rp.Add(new Person("SMITH", "ALLAN", 70));
            rp.Add(new Person("SMITH", "FRANCIS", 85));
            rp.Add(new Person("BUNDY", "TERESSA", 88));

            //sorted order
            lp = new List<Person>();
            lp.Add(new Person("BUNDY", "TERESSA", 88));
            lp.Add(new Person("KING", "MADISON", 88));
            lp.Add(new Person("SMITH", "FRANCIS", 85));
            lp.Add(new Person("SMITH", "ALLAN", 70));
        }
        
        [TestMethod]
        public void TestNoChangeOnOriginalList()
        {
            Person.sort(rp);
            Assert.AreEqual(88, rp[0].grade);
            Assert.AreEqual("KING", rp[0].lastName);
            Assert.AreEqual("MADISON", rp[0].firstName);

            Assert.AreEqual(70, rp[1].grade);
            Assert.AreEqual("SMITH", rp[1].lastName);
            Assert.AreEqual("ALLAN", rp[1].firstName);

            Assert.AreEqual(85, rp[2].grade);
            Assert.AreEqual("SMITH", rp[2].lastName);
            Assert.AreEqual("FRANCIS", rp[2].firstName);

            Assert.AreEqual(88, rp[3].grade);
            Assert.AreEqual("BUNDY", rp[3].lastName);
            Assert.AreEqual("TERESSA", rp[3].firstName);

        }

        [TestMethod]
        public void TestSortCorrectness()
        {
            List<Person> op = Person.sort(lp);
            for(int i = 0; i < op.Count; i++)
            {
                Assert.AreEqual(op[i].grade, lp[i].grade);
                Assert.AreEqual(op[i].lastName, lp[i].lastName);
                Assert.AreEqual(op[i].firstName, lp[i].firstName);
            }
        }

        [TestMethod]
              [ExpectedException(typeof(System.IO.FileNotFoundException),"file not found.")]
        public void TestFileNotFoundError()
        {
            Person.Main(new string[1] { "nosuchfile.txt" });
        }

        
    }
}
