﻿using CompulsoryCat.Assemblyname;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace TestCompulsoryCat
{


    /// <summary>
    ///This is a test class for AssemblynameHelperTest and is intended
    ///to contain all AssemblynameHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AssemblynameHelperTest
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
        ///A test for Get
        ///</summary>
        [TestMethod()]
        // ReSharper disable InconsistentNaming
        public void GetTest_Assembly()
        // ReSharper restore InconsistentNaming
        {
            Assert.Inconclusive("TBA");
            var res = AssemblynameHelper.Get((Assembly)null);
        }

        /// <summary>
        ///A test for Get
        ///</summary>
        [TestMethod()]
        // ReSharper disable InconsistentNaming
        public void GetTest_Void()
        // ReSharper restore InconsistentNaming
        {
            Assert.Inconclusive("TBA");
            var res = AssemblynameHelper.Get();
        }

        /// <summary>
        ///A test for GetRecursive
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CompulsoryCat.dll")]
        public void GetRecursiveTest()
        {
            Assert.Inconclusive("TBA");
            var res = AssemblynameHelper_Accessor.GetRecursive((Assembly)null);
        }
    }
}
