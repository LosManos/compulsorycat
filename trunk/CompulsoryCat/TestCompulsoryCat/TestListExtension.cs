using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompulsoryCat;

namespace TestCompulsoryCat
{
    [TestClass]
    public class TestListExtension
    {
        private TestContext _testContextInstance;

        /// <summary>Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        
        [TestMethod]
        public void TestNormal()
        {
            var lst = new List<string> { "a", "abc", "abcde" };
            var res = CompulsoryCat.ListExtension.SplitToListsOfEqualLength(lst, 2);
            Assert.AreEqual(3, res.Count);
            Assert.AreEqual(3, res[0].Count);
            Assert.AreEqual("a", res[0][0]);
            Assert.AreEqual(null, res[0][1]);
            Assert.AreEqual(null, res[0][2]);
            Assert.AreEqual(3, res[1].Count);
            Assert.AreEqual("ab", res[1][0]);
            Assert.AreEqual("c", res[1][1]);
            Assert.AreEqual(null, res[1][2]);
            Assert.AreEqual(3, res[2].Count);
            Assert.AreEqual("ab", res[2][0]);
            Assert.AreEqual("cd", res[2][1]);
            Assert.AreEqual("e", res[2][2]);
        }

        [TestMethod]
        public void TestWithNull()
        {
            var lst = new List<string> { "a", null, "abcde" };
            var res = CompulsoryCat.ListExtension.SplitToListsOfEqualLength(lst, 4);
            Assert.AreEqual(3, res.Count);
            Assert.AreEqual(2, res[0].Count);
            Assert.AreEqual("a", res[0][0]);
            Assert.AreEqual(null, res[0][1]);
            Assert.AreEqual(2, res[1].Count);
            Assert.AreEqual(null, res[1][0]);
            Assert.AreEqual(null, res[1][1]);
            Assert.AreEqual(2, res[2].Count);
            Assert.AreEqual("abcd", res[2][0]);
            Assert.AreEqual("e", res[2][1]);
        }

       
        [TestMethod]
        public void TestAllNull()
        {
            var lst = new List<string> { null, null };
            var res = CompulsoryCat.ListExtension.SplitToListsOfEqualLength(lst, 3);
            Assert.AreEqual(2, res.Count);
            Assert.AreEqual(0, res[0].Count);
            Assert.AreEqual(0, res[1].Count);
        }
    }
}
