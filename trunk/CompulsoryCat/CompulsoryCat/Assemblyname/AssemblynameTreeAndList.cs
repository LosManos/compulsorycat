using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompulsoryCat.Assemblyname
{
    ///<summary>This class contains two properties.  One is a tree of AssemblyNames and one is a list of them.
    ///</summary>
    public class AssemblynameTreeAndList
    {
        private readonly AssemblynameHelper.AssemblynameNode _info;

        /// <summary>We have a Dictionary instead of the simpler List since we want to be sure the list is unique
        /// without having to do or write explicit tests.
        /// </summary>
        private readonly Dictionary<string, AssemblyName> _assemblynameList;

        /// <summary>This list of AssemblyNames has unique Assemblies.
        /// </summary>
        public List<AssemblyName> AssemblynameList
        {
            get { return _assemblynameList.Values.ToList(); }
        }

        /// <summary>This tree of AssemblyNames has each AssemblyName with its referenced Assemblies.
        /// </summary>
        public AssemblynameHelper.AssemblynameNode Tree
        {
            get { return _info; }
        }

        /// <summary>This constructor takes all data and is the prefered one.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="assemblynameList"></param>
        internal AssemblynameTreeAndList(AssemblynameHelper.AssemblynameNode info, List<AssemblyName> assemblynameList)
        {
            if (null == info) { throw new System.ArgumentNullException("info"); }
            if (null == assemblynameList) { throw new System.ArgumentNullException("assemblynameList"); }

            _info = info;
            _assemblynameList = new Dictionary<string, AssemblyName>();
            assemblynameList.ForEach(an => _assemblynameList.Add(an));
        }
    }

    /// <summary>This is a helper class for the Dictionary we use.
    /// </summary>
    internal static class DictionaryExtensions
    {
        /// <summary>This helper extension adds the Add method that should have been there from start.
        /// </summary>
        /// <param name="me"></param>
        /// <param name="assemblyname"></param>
        internal static void Add(this Dictionary<string, AssemblyName> me, AssemblyName assemblyname)
        {
            me.Add(assemblyname.FullName, assemblyname);
        }
    }
}
