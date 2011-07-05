//Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: 
//once or twice she had peeped into the book her sister was reading, but it had no pictures or conversations in it, 
//`and what is the use of a book,' thought Alice `without pictures or conversation?'

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompulsoryCat.Meta;

namespace TestCompulsoryCat
{
    /// <summary>Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestReflectionUtility
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
        public void TestGetClassVoid()
        {
            var cn = ReflectionUtility.GetClass().Name;
            Assert.AreEqual(cn, "TestReflectionUtility");

            cn = (new MyClass()).GetClassMethod().Name;
            Assert.AreEqual(cn, "MyClass");

            cn = MyStaticClass.StaticGetClassMethod().Name;
            Assert.AreEqual(cn, "MyStaticClass");
        }

        [TestMethod]
        public void TestGetClassObject()
        {
            var cn = ReflectionUtility.GetClass(this).Name;
            Assert.AreEqual(cn, "TestReflectionUtility");

            var o = new MyClass();
            cn = ReflectionUtility.GetClass(o).Name;
            Assert.AreEqual(cn, "MyClass");
        }

        [TestMethod]
        public void TestGetCallingMethod()
        {
            var o = new MyClass();
            var mn = o.GetCallingMethodNameMethod().Name;
            Assert.AreEqual(mn, "TestGetCallingMethod");

            mn = MyStaticClass.GetCallingMethodNameMethod().Name;
            Assert.AreEqual(mn, "TestGetCallingMethod");
        }

        [TestMethod]
        public void TestGetCallingMethodFullNameReturnParametertypes()
        {
            var o = new MyClass();
            var mn = o.GetCallingMethodFullNameReturnParametertypes();
            Assert.AreEqual(mn, "System.Void TestCompulsoryCat.TestReflectionUtility.TestGetCallingMethodFullNameReturnParametertypes ()");

            mn = MyStaticClass.GetCallingMethodFullNameReturnParametertypes();
            Assert.AreEqual(mn, "System.Void TestCompulsoryCat.TestReflectionUtility.TestGetCallingMethodFullNameReturnParametertypes ()");
        }

        [TestMethod]
        public void TestGetMethod()
        {
            var mn = ReflectionUtility.GetMethod().Name;
            Assert.AreEqual(mn, "TestGetMethod");
        }

        [TestMethod]
        public void TestGetMethodNameReturnStringLambda()
        {
            // ReSharper disable RedundantLambdaParameterType
            var mn = ReflectionUtility.GetMethodName<MyClass, Func<string>>((MyClass x) => x.GetMethodNameReturnString2);
            // ReSharper restore RedundantLambdaParameterType
            Assert.AreEqual(mn, "GetMethodNameReturnString2");

            mn = ReflectionUtility.GetMethodName<MyClass, Func<string>>(x => x.GetMethodNameReturnString2); //  Without type specification.
            Assert.AreEqual(mn, "GetMethodNameReturnString2");
        }

        [TestMethod]
        public void TestGetPropertyName()
        {
            var pn = ReflectionUtility.GetPropertyName((MyClass x) => x.MyProp);
            Assert.AreEqual(pn, "MyProp");
        }

        [TestMethod]
        public void TestMethodFullName()
        {
            var mn = (new MyClass()).MethodFullName2();
            Assert.AreEqual(mn, "TestCompulsoryCat.TestReflectionUtility.TestMethodFullName");

            mn = MyStaticClass.MethodFullname3();
            Assert.AreEqual(mn, "TestCompulsoryCat.TestReflectionUtility.TestMethodFullName");
        }

        [TestMethod]
        public void TestMethodFullNameReturn()
        {
            var mn = (new MyClass()).MethodFullNameReturn2();
            Assert.AreEqual(mn, "System.Void TestCompulsoryCat.TestReflectionUtility.TestMethodFullNameReturn");

            mn = MyStaticClass.MethodFullNameReturn3();
            Assert.AreEqual(mn, "System.Void TestCompulsoryCat.TestReflectionUtility.TestMethodFullNameReturn");
        }

        [TestMethod]
        public void TestMethodFullNameReturnParametertypes()
        {
            var mn = (new MyClass()).MethodFullNameReturnParametertypes2();
            Assert.AreEqual(mn, "System.Void TestCompulsoryCat.TestReflectionUtility.TestMethodFullNameReturnParametertypes ()");

            mn = MyStaticClass.MethodFullNameReturnParametertypes3();
            Assert.AreEqual(mn, "System.Void TestCompulsoryCat.TestReflectionUtility.TestMethodFullNameReturnParametertypes ()");
        }

        private class MyClass
        {
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            internal int MyProp { get; set; }
            // ReSharper restore UnusedAutoPropertyAccessor.Local
            // ReSharper disable MemberCanBeMadeStatic.Local
            internal Type GetClassMethod()
            {
                return ReflectionUtility.GetClass();
            }
            internal System.Reflection.MethodBase GetCallingMethodNameMethod()
            {
                return ReflectionUtility.GetCallingMethod();
            }
            internal string GetCallingMethodFullNameReturnParametertypes()
            {
                return ReflectionUtility.GetCallingMethodFullNameReturnParametertypes();
            }
            internal string GetMethodNameReturnString2()
            {
                return string.Empty;
            }
            internal string MethodFullName2()
            {
                return ReflectionUtility.MethodFullName(ReflectionUtility.GetCallingMethod());
            }
            internal string MethodFullNameReturn2()
            {
                return ReflectionUtility.MethodFullNameReturn(ReflectionUtility.GetCallingMethod());
            }
            internal string MethodFullNameReturnParametertypes2()
            {
                return ReflectionUtility.MethodFullNameReturnParametertypes(ReflectionUtility.GetCallingMethod());
            }
            // ReSharper restore MemberCanBeMadeStatic.Local
        }

        private static class MyStaticClass
        {
            internal static Type StaticGetClassMethod()
            {
                return ReflectionUtility.GetClass();
            }
            internal static System.Reflection.MethodBase GetCallingMethodNameMethod()
            {
                return ReflectionUtility.GetCallingMethod();
            }
            internal static string GetCallingMethodFullNameReturnParametertypes()
            {
                return ReflectionUtility.GetCallingMethodFullNameReturnParametertypes();
            }
            internal static string MethodFullname3()
            {
                return ReflectionUtility.MethodFullName(ReflectionUtility.GetCallingMethod());
            }
            internal static string MethodFullNameReturn3()
            {
                return ReflectionUtility.MethodFullNameReturn(ReflectionUtility.GetCallingMethod());
            }
            internal static string MethodFullNameReturnParametertypes3()
            {
                return ReflectionUtility.MethodFullNameReturnParametertypes(ReflectionUtility.GetCallingMethod());
            }
        }
    }
}
