//`Well!' thought Alice to herself, `after such a fall as this, I shall think nothing of tumbling down stairs! 
//How brave they'll all think me at home! Why, I wouldn't say anything about it, even if I fell off the top of the house!' (Which was very likely true.)

using CompulsoryCat.Assemblyname;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace TestCompulsoryCat
{


    /// <summary>
    ///This is a test class for AssemblynameTreeAndListTest and is intended
    ///to contain all AssemblynameTreeAndListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AssemblynameTreeAndListTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
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


        /// <summary>
        ///A test for AssemblynameTreeAndList Constructor
        ///</summary>
        [TestMethod()]
        public void AssemblynameTreeAndListConstructorTest()
        {
            Assert.Inconclusive("TBA");
            var res = new AssemblynameTreeAndList((AssemblynameHelper.AssemblynameNode)null, (List<AssemblyName>)null);
        }

        /// <summary>
        ///A test for AssemblynameList
        ///</summary>
        [TestMethod()]
        public void AssemblynameListTest()
        {
            Assert.Inconclusive("TBA");
            AssemblynameHelper.AssemblynameNode info = null; // TODO: Initialize to an appropriate value
            List<AssemblyName> assemblynameList = null; // TODO: Initialize to an appropriate value
            var target = new AssemblynameTreeAndList(info, assemblynameList); // TODO: Initialize to an appropriate value
            var res = target.AssemblynameList;
        }

        /// <summary>
        ///A test for Tree
        ///</summary>
        [TestMethod()]
        public void TreeTest()
        {
            Assert.Inconclusive("TBA");
            AssemblynameHelper.AssemblynameNode info = null; // TODO: Initialize to an appropriate value
            List<AssemblyName> assemblynameList = null; // TODO: Initialize to an appropriate value
            var target = new AssemblynameTreeAndList(info, assemblynameList); // TODO: Initialize to an appropriate value
            var res = target.Tree;
        }
    }
}
