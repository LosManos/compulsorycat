using CompulsoryCat;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace TestCompulsoryCat
{
    
    /// <summary>This is a test class for MemberInfoExtensionTest and is intended
    ///to contain all MemberInfoExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MemberInfoExtensionTest
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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>A test for FormattedPropertyName
        ///</summary>
        [TestMethod()]
        public void FormattedPropertyNameTest()
        {
            var p = typeof (MyClass).GetProperty("MyProperty");
            var n = p.FormattedPropertyName();
            Assert.AreEqual("MyProperty", n);
        }

        private class MyClass
        {
            public string MyProperty
            {
                get { return string.Empty; }
                // ReSharper disable ValueParameterNotUsed
                set
                {
                    /*NOP*/
                }
                // ReSharper restore ValueParameterNotUsed
            }
        }
    }
}
