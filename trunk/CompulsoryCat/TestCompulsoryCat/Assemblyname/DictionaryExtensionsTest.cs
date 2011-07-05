//Down, down, down. Would the fall NEVER come to an end! `I wonder how many miles I've fallen by this time?' 
//she said aloud. `I must be getting somewhere near the centre of the earth. 
//Let me see: that would be four thousand miles down, I think--' (for, you see, Alice had learnt several 
//things of this sort in her lessons in the schoolroom, and though this was not a VERY good opportunity for 
//showing off her knowledge, as there was no one to listen to her, still it was good practice to say it over) 
//`--yes, that's about the right distance--but then I wonder what Latitude or Longitude I've got to?' 
//(Alice had no idea what Latitude was, or Longitude either, but thought they were nice grand words to say.)

using CompulsoryCat.Assemblyname;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace TestCompulsoryCat
{


    /// <summary>
    ///This is a test class for DictionaryExtensionsTest and is intended
    ///to contain all DictionaryExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DictionaryExtensionsTest
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
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            Assert.Inconclusive("TBA");
            Dictionary<string, AssemblyName> me = null; // TODO: Initialize to an appropriate value
            AssemblyName assemblyname = null; // TODO: Initialize to an appropriate value
            DictionaryExtensions.Add(me, assemblyname);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
