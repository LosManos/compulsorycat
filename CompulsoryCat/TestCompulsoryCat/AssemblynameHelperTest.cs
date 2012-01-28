using CompulsoryCat.Assemblyname;
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


        /// <summary>A test for Get.
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        // ReSharper disable InconsistentNaming
        public void GetTest_Assembly()
        // ReSharper restore InconsistentNaming
        {
            var res = AssemblynameHelper.Get((Assembly)null);
        }

        /// <summary>A test for Get.
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(CompulsoryCat.Exception.NoEntryAssemblyException), "There is no EntryAssembly for unit test.  How should one test this? through an external exe?")]
        // ReSharper disable InconsistentNaming
        public void GetTest_Void()
        // ReSharper restore InconsistentNaming
        {
            //  See http://social.msdn.microsoft.com/Forums/eu/vststest/thread/7ff8caae-56c6-4baa-94c9-7224f69dbd17
            //  and http://msdn.microsoft.com/en-us/library/system.reflection.assembly.getentryassembly.aspx
            var res = AssemblynameHelper.Get();
            Assert.IsNull(res, "There is no EntryAssembly for unit test.  How should one test this? through an external exe?");
        }

        /// <summary>A failing test for GetRecursive.
        /// 
        /// This is not a valid test since GetRecursive is private.  I keep the code here anyway since it is a reminder of the
        /// automatically generated AssemblynameHelper_Accessor class. /OF
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        [DeploymentItem("CompulsoryCat.dll")]   //  What is this?
        public void GetRecursiveTestFailing()
        {
            var res = AssemblynameHelper_Accessor.GetRecursive((Assembly)null);
        }
    }
}
