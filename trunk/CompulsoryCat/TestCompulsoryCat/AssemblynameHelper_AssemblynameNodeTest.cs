using CompulsoryCat.Assemblyname;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace TestCompulsoryCat
{
    
    
    /// <summary>
    ///This is a test class for AssemblynameHelper_AssemblynameNodeTest and is intended
    ///to contain all AssemblynameHelper_AssemblynameNodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AssemblynameHelper_AssemblynameNodeTest
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
        ///A test for AssemblynameNode Constructor
        ///</summary>
        [TestMethod()]
        public void AssemblynameHelper_AssemblynameNodeConstructorTest()
        {
            Assert.Inconclusive("TBA");
            AssemblyName assemblyname = null; // TODO: Initialize to an appropriate value
            var target = new AssemblynameHelper.AssemblynameNode(assemblyname);
        }

        /// <summary>
        ///A test for AsFlattened
        ///</summary>
        [TestMethod()]
        public void AsFlattenedTest()
        {
            Assert.Inconclusive("TBA");
            AssemblyName assemblyname = null; // TODO: Initialize to an appropriate value
            var target = new AssemblynameHelper.AssemblynameNode(assemblyname); // TODO: Initialize to an appropriate value
            IEnumerable<AssemblynameHelper.AssemblynameNode> actual = target.AsFlattened();
        }

        /// <summary>
        ///A test for Flatten
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CompulsoryCat.dll")]
        public void FlattenTest()
        {
            Assert.Inconclusive("TBA");
            AssemblynameHelper.AssemblynameNode parent = null; // TODO: Initialize to an appropriate value
            IEnumerable<AssemblynameHelper.AssemblynameNode> actual = AssemblynameHelper_Accessor.AssemblynameNode.Flatten(parent);
        }

        /// <summary>
        ///A test for AssemblyName
        ///</summary>
        [TestMethod()]
        public void AssemblyNameTest()
        {
            Assert.Inconclusive("TBA");
            AssemblyName assemblyname = null; // TODO: Initialize to an appropriate value
            var target = new AssemblynameHelper.AssemblynameNode(assemblyname); // TODO: Initialize to an appropriate value
            AssemblyName actual = target.AssemblyName;
        }

        /// <summary>
        ///A test for ReferencedAssemblyNames
        ///</summary>
        [TestMethod()]
        public void ReferencedAssemblyNamesTest()
        {
            Assert.Inconclusive("TBA");
            AssemblyName assemblyname = null; // TODO: Initialize to an appropriate value
            var target = new AssemblynameHelper.AssemblynameNode(assemblyname); // TODO: Initialize to an appropriate value
            List<AssemblynameHelper.AssemblynameNode> actual = target.ReferencedAssemblyNames;
        }
    }
}
