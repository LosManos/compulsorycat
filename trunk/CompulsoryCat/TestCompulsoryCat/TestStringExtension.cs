using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompulsoryCat;
using CompulsoryCat.Beta;

namespace TestCompulsoryCat
{
    [TestClass]
    public class TestStringExtension
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
        public void TestNormalCase()
        {
            var s = "abcdefg";
            var res = s.SplitToLength(2);
            Assert.AreEqual(4, res.Count);
            Assert.AreEqual("ab", res[0]);
            Assert.AreEqual("cd", res[1]);
            Assert.AreEqual("ef", res[2]);
            Assert.AreEqual("g", res[3]);
        }

        [TestMethod]
        public void TestEmpty()
        {
            var res = "".SplitToLength(0);
            Assert.AreEqual(0, res.Count);

            res = "".SplitToLength(2);
            Assert.AreEqual(0, res.Count);
        }

        [TestMethod]
        public void TestTooLong()
        {
            var res = "a".SplitToLength(2);
            Assert.AreEqual(1, res.Count);
            Assert.AreEqual("a", res[0]);

            res = "abc".SplitToLength(100);
            Assert.AreEqual(1, res.Count);
            Assert.AreEqual("abc", res[0]);
        }

    }
}
