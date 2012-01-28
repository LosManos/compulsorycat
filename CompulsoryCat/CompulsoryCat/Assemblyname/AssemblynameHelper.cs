using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompulsoryCat.Assemblyname
{
    /// <summary>This class returns info about the Assemblies as a tree of AssemblyNames.
    /// It is not thread safe since we keep an internal list of assemblynames 
    /// to avoid stack overflow due to circular reference.
    /// </summary>
    public static partial class AssemblynameHelper
    {
        private static Dictionary<string, AssemblyName> _assemblynameList;

        /// <summary>This method is for getting the entry Assembly's AssemblyName 
        /// and all its referenced AssemblyNames and so forth in a tree.
        /// A list of the unique AssemblyNames is also returned.
        /// </summary>
        /// <returns></returns>
        public static AssemblynameTreeAndList Get()
        {
            //  If we call this method several times it is important to reset the list because it is static.
            //  I don't really like this behaviour since it makes the method non threadable.  But... why
            //  would we multi thread a AssemblyName enumerator?
            //  Maybe for Web?
            //  Anyhow.  Having the method static makes for a good syntax at the client.
            //  Maybe we could create the method as a static constructor instead?
            //  or pass the List as parameter to the recursive method.  But that would require some rewrite.
            _assemblynameList = new Dictionary<string, AssemblyName>();

            Assembly entryAssembly = Assembly.GetEntryAssembly();

            if (null == entryAssembly) { throw new Exception.NoEntryAssemblyException(); }

            return Get(entryAssembly);
        }

        /// <summary>This method is for getting any Assembly's AssemblyName 
        /// and all its referenced AssemblyNames and so forth in a tree.
        /// A list of the unique AssemblyNames is also returned.
        /// </summary>
        /// <returns></returns>
        public static AssemblynameTreeAndList Get(Assembly assembly)
        {
            if (null == assembly) { throw new System.ArgumentNullException("assembly"); }

            //  See comments for Get(void).
            _assemblynameList = new Dictionary<string, AssemblyName>();

            var infoTree = GetRecursive(assembly);
            return new AssemblynameTreeAndList(infoTree, _assemblynameList.Values.ToList());
        }

        /// <summary>This is the method for recursing through the AssemblyNames.
        /// It returns a tree of AssemblyNames.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static AssemblynameNode GetRecursive(Assembly assembly)
        {
            if (null == assembly) { throw new System.ArgumentNullException("assembly"); }

            //  http://msdn.microsoft.com/en-us/magazine/cc163641.aspx <- reflection
            //  http://dotnetdebug.net/2005/11/15/net-assembly-loader/
            //  http://stackoverflow.com/questions/3971793/what-when-assembly-getreferencedassemblies-returns-exe-dependency    <- reflectiononlyload and ditto loadfrom.  solves which problem?

            //  We always have an AssemblyName to return.
            var ret = new AssemblynameNode(assembly.GetName());

            //  Loop through the AssemblyNames the actual Assembly references.  Note that we might have already been into the AssemblyName through
            //  another Assembly and then we have a circular reference which means stack overflow.  It is taken care of in the loop.
            foreach (var assemblyname in assembly.GetReferencedAssemblies())
            {
                //  We only want to set the Info to have a list if we are sure we have referenced assemblies.  If we don't have any referenced assemblies we will keep it as null.
                //  If we are in the loop we know there are references Assemblies.  Below is shorthand for making sure we have a List and not touch it if we already have a List.
                ret.ReferencedAssemblyNames = ret.ReferencedAssemblyNames ?? new List<AssemblynameNode>();

                //  Check if we alreay have found this Assemblyname.  If we have; add it as a node but don't recurse its siblings.
                if (_assemblynameList.ContainsKey(assemblyname.FullName))
                {
                    ret.ReferencedAssemblyNames.Add(new AssemblynameNode(assemblyname));
                }
                else
                {   //  The AssemblyName is new for us.

                    //  Add the AssemblyName to the list of AssemblyNames we have found.
                    _assemblynameList.Add(assemblyname.FullName, assemblyname);

                    //  Gotta load the Assembly to get its references.  Just AssemblyName won't do since AssemblyName doesn't have information about referenced Assemblies.
                    {
                        var ass = Assembly.Load(assemblyname.FullName);
                        ret.ReferencedAssemblyNames.Add(GetRecursive(ass));

// ReSharper disable RedundantAssignment
                        ass = null; //  How do I unload?  Can I?  Should I?
// ReSharper restore RedundantAssignment
                        //  Well... we can't unload in the default app domain.  We should create a new, temporary, app domain and load/unload it there.
                        //  Not being able to unload means we have a memory leak for every call.
                        //  http://blogs.msdn.com/b/jasonz/archive/2004/05/31/145105.aspx
                    }
                }
            }

            return ret;
        }
    }
}
