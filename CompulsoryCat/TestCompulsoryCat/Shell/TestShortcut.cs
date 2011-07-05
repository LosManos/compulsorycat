//Presently she began again. `I wonder if I shall fall right THROUGH the earth! How funny it'll seem to come out 
//among the people that walk with their heads downward! The Antipathies, 
//I think--' (she was rather glad there WAS no one listening, this time, as it didn't sound at all the right word) 
//`--but I shall have to ask them what the name of the country is, you know. 
//Please, Ma'am, is this New Zealand or Australia?' (and she tried to curtsey as she 
//spoke--fancy CURTSEYING as you're falling through the air! Do you think you could manage it?) 
//`And what an ignorant little girl she'll think me for asking! No, it'll never do to ask: perhaps I shall see it written up somewhere.'

using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Shortcut = CompulsoryCat.Shell.Shortcut;

namespace TestCompulsoryCat
{
    /// <summary>Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestShortcut
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
        public void DeleteForTarget()
        {
            var executablePathFile = Assembly.GetExecutingAssembly().Location;
            var executablePath = Path.GetDirectoryName(executablePathFile);
            const string Shortcutname = "A6B1E7DE-8693-4354-9DA0-8181F072C20F";
            var shortcutPathFile = Path.Combine(executablePath, Shortcutname) + "." + CompulsoryCat.Shell.Shortcut.Suffix;

            //  Delete any already existing shortcuts.
            CompulsoryCat.Shell.Shortcut.DeleteForTarget(executablePath, executablePathFile);
            Assert.IsFalse(Exists(shortcutPathFile));

            //  Create a shortcut.
            using (var shortcut = new CompulsoryCat.Shell.Shortcut())
            {
                shortcut.Target = executablePathFile;
                shortcut.WorkingDirectory = executablePath;
                shortcut.Description = string.Format("Link to {0}", Shortcutname);
                shortcut.DisplayMode = CompulsoryCat.Shell.Shortcut.LinkDisplayMode.edmNormal;
                shortcut.Save(shortcutPathFile);
            }
            Assert.IsTrue(Exists(shortcutPathFile));

            //  Delete the shortcut.
            CompulsoryCat.Shell.Shortcut.DeleteForTarget(Path.GetDirectoryName(shortcutPathFile), executablePathFile);
            Assert.IsFalse(Exists(shortcutPathFile));
        }

        [TestMethod]
        public void EShellLinkResolveFlags()
        {
            var res = string.Join(",", Enum.GetNames(typeof(CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags)));
            Assert.AreEqual(
                "SLR_NO_UI,SLR_ANY_MATCH,SLR_UPDATE,SLR_NOUPDATE,SLR_NOSEARCH,SLR_NOTRACK,SLR_NOLINKINFO,SLR_INVOKE_MSI,SLR_NO_UI_WITH_MSG_PUMP",
                res);
            Assert.AreEqual(0x2, (int)CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_ANY_MATCH);
            Assert.AreEqual(0x80, (int)CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_INVOKE_MSI);
            Assert.AreEqual(0x40, (int)CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_NOLINKINFO);
            Assert.AreEqual(0x1, (int)CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_NO_UI);
            Assert.AreEqual(0x101, (int)CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_NO_UI_WITH_MSG_PUMP);
            Assert.AreEqual(0x8, (int)CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_NOUPDATE);
            Assert.AreEqual(0x10, (int)CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_NOSEARCH);
            Assert.AreEqual(0x20, (int)CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_NOTRACK);
            Assert.AreEqual(0x4, (int)CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_UPDATE);
        }

        [TestMethod]
        public void LinkDisplayMode()
        {
            var res = string.Join(",", Enum.GetNames(typeof(CompulsoryCat.Shell.Shortcut.LinkDisplayMode)));
            Assert.AreEqual(
                "edmNormal,edmMaximized,edmMinimized",
                res);
        }

        [TestMethod]
        public void Open()
        {
            Assert.Inconclusive("TBA");
            using (var shortcut = new Shortcut())
            {
                shortcut.Open(string.Empty);
                shortcut.Open(string.Empty, new IntPtr(), CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_ANY_MATCH);
                shortcut.Open( string.Empty, new IntPtr(), CompulsoryCat.Shell.Shortcut.EShellLinkResolveFlags.SLR_ANY_MATCH, 0 );
            }
        }

        [TestMethod]
        public void ShortcutProperties()
        {
            using (var shortcut = new Shortcut())
            {
                Assert.Inconclusive("We enumerate all properties but don't check they work.");
                shortcut.ShortCutFile = "A";
                var largeIcon = shortcut.LargeIcon;
                var smallIcon = shortcut.SmallIcon;
                shortcut.IconPath = "B";
                shortcut.IconIndex = 0;
                shortcut.Target = "C";
                shortcut.WorkingDirectory = "D";
                shortcut.Description = "E";
                shortcut.Arguments = "F";
                shortcut.DisplayMode = Shortcut.LinkDisplayMode.edmMaximized;
                shortcut.HotKey = Keys.A;
            }
        }

        [TestMethod]
        public void Save()
        {
            var executablePathFile = Assembly.GetExecutingAssembly().Location;
            var executablePath = Path.GetDirectoryName(executablePathFile);
            const string Shortcutname = "0BDA2F85-D2ED-4E2D-B3DE-44B08950DE76";
            var shortcutPathFile = Path.Combine(executablePath, Shortcutname) + "." + CompulsoryCat.Shell.Shortcut.Suffix;

            //  Delete any already existing shortcuts.
            CompulsoryCat.Shell.Shortcut.DeleteForTarget(executablePath, executablePathFile);
            Assert.IsFalse(Exists(shortcutPathFile));

            //  Create a shortcut.
            using (var shortcut = new CompulsoryCat.Shell.Shortcut())
            {
                shortcut.Target = executablePathFile;
                shortcut.WorkingDirectory = executablePath;
                shortcut.Description = string.Format("Link to {0}", Shortcutname);
                shortcut.DisplayMode = CompulsoryCat.Shell.Shortcut.LinkDisplayMode.edmNormal;
                shortcut.Save(shortcutPathFile);
            }
            Assert.IsTrue(Exists(shortcutPathFile));
        }

        [TestMethod]
        public void Suffix()
        {
            Assert.AreEqual("lnk", CompulsoryCat.Shell.Shortcut.Suffix);
        }

        /// <summary>This helper method returns true if the file exists.
        /// </summary>
        /// <param name="pathfile">Path and file and suffix, the full thingamajig.</param>
        /// <returns></returns>
        private static bool Exists(string pathfile)
        {
            var path = Path.GetDirectoryName(pathfile);
            var directoryInfo = new System.IO.DirectoryInfo(path);
            var fileArray = directoryInfo.GetFiles("*.lnk");
            return fileArray.ToList().Select(fi => fi.FullName).Contains(pathfile);
        }
    }
}
