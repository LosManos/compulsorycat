using CompulsoryCat.Assemblyname;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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

        /// <summary>Gets or sets the test context which provides
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

        /// <summary>A simple test for AssemblynameNode Constructor.
        ///</summary>
        [TestMethod()]
        public void AssemblynameHelper_AssemblynameNodeConstructorTest()
        {
            var assemblyname = new AssemblyName();
            var target = new AssemblynameHelper.AssemblynameNode(assemblyname);
            Assert.IsNotNull(target);
        }

        /// <summary>A test for AsFlattened.
        ///</summary>
        [TestMethod()]
        public void AsFlattenedTest()
        {
            AssemblynameTreeAndList assemblynameInfo = AssemblynameHelper.Get( Assembly.GetExecutingAssembly());
            var res = assemblynameInfo.Tree.AsFlattened();
            Assert.IsTrue(res.Count() > 1);

            AssemblyName assemblyname = Assembly.GetExecutingAssembly().GetName();
            var target = new AssemblynameHelper.AssemblynameNode(assemblyname);
            res = target.AsFlattened();
            Assert.AreEqual(1, res.Count());
        }

        /// <summary>A test for AssemblyName.
        ///</summary>
        [TestMethod()]
        public void AssemblyNameTest()
        {
            var assemblyname = new AssemblyName();
            var res = new AssemblynameHelper.AssemblynameNode(assemblyname); // TODO: Initialize to an appropriate value
            Assert.AreEqual(assemblyname, res.AssemblyName);
        }

        /// <summary>
        ///A test for ReferencedAssemblyNames
        ///</summary>
        [TestMethod()]
        public void ReferencedAssemblyNamesTest()
        {
            AssemblyName assemblyname = Assembly.GetExecutingAssembly().GetName();
            var target = new AssemblynameHelper.AssemblynameNode(assemblyname);
            var res = target.ReferencedAssemblyNames;
            Assert.IsNull(res);

            AssemblynameTreeAndList assemblynameInfo = AssemblynameHelper.Get(Assembly.GetExecutingAssembly());
            var q = assemblynameInfo.Tree.AsFlattened().Where(ani => ani.ReferencedAssemblyNames != null);

            Assert.IsTrue(q.Count() >= 1, "There should be at least one referenced assembly from whatever executed this DLL, shouldn't there?");
        }
    }
}
