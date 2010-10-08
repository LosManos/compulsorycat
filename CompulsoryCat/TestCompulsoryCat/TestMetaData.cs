using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompulsoryCat;

namespace TestCompulsoryCat
{
    /// <summary>Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestMetaData
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
        public void TestGetClass()
        {
            var o = (new object()).GetClass().Name;
            Assert.AreEqual( o, "Object");

            var s = "".GetClass().Name;
            Assert.AreEqual(s, "String");
        }

        [TestMethod]
        public void TestGetMethod()
        {
            var m = this.GetMethod().Name;
            Assert.AreEqual(m, "TestGetMethod");

            m = ThisMethod().Name;
            Assert.AreEqual(m, "ThisMethod");
        }

        [TestMethod]
        public void TestGetClassForStatic()
        {
            var cn = ReflectionUtility.GetClass().Name;
            Assert.AreEqual(cn, "TestMetaData");

            cn = MyStaticClass.MyType().Name;
            Assert.AreEqual(cn, "MyStaticClass");
        }

        private System.Reflection.MethodBase ThisMethod()
        {
            return this.GetMethod();
        }

        private static class MyStaticClass
        {
            internal static Type MyType()
            {
                return ReflectionUtility.GetClass();
            }
        }
    }
}
