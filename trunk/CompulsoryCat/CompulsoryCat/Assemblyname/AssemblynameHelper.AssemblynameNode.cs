using System.Collections.Generic;
using System.Reflection;

namespace CompulsoryCat.Assemblyname
{
    partial class AssemblynameHelper
    {
        /// <summary>This class contains an AssemblyName and a list of its referenced AssemblyNames.
        /// </summary>
        public class AssemblynameNode
        {
            private readonly AssemblyName _assemblyname;

            /// <summary>This property is the actual AssemblyName.
            /// </summary>
            public AssemblyName AssemblyName
            {
                get { return _assemblyname; }
            }

            // ReSharper disable RedundantDefaultFieldInitializer
            private List<AssemblynameNode> _referencedAssemblyNames = null;
            // ReSharper restore RedundantDefaultFieldInitializer

            /// <summary>This is the list of referenced AssemblyNames.
            /// If the AssemblyName has none referenced AssemblyName then this list is empty.
            /// Note: If the AssemblyName is subject to circular reference, i.e. we have it somewhere else in the AssemblynameNode tree
            /// then this property is null.  If we didn't stop the recursion we would be circular reference.  (yes - the framework contains
            /// at least one circular reference)
            /// </summary>
            // ReSharper disable ConvertToAutoProperty
            public List<AssemblynameNode> ReferencedAssemblyNames
            // ReSharper restore ConvertToAutoProperty
            {
                get { return _referencedAssemblyNames; }
                internal set { _referencedAssemblyNames = value; }
            }

            /// <summary>This constructor is the prefered one since it takes all mandatory data.
            /// </summary>
            /// <param name="assemblyname"></param>
            public AssemblynameNode(AssemblyName assemblyname)
            {
                _assemblyname = assemblyname;
            }

            /// <summary>This method flattens the tree.
            /// For helping the caller avoid inventing the wheel again.
            /// </summary>
            /// <returns></returns>
            public IEnumerable<AssemblynameNode> AsFlattened()
            {
                return Flatten(this);
            }

            /// <summary>This is a helper method for the caller's benefit.  It flattens the tree.
            /// http://stackoverflow.com/questions/1938409/linq-how-to-convert-the-nested-hierarchical-object-to-flatten-object
            /// </summary>
            /// <param name="parent"></param>
            /// <returns></returns>
            private static IEnumerable<AssemblynameNode> Flatten(AssemblynameNode parent)
            {
                yield return parent;
                foreach (AssemblynameNode child in
                    parent.ReferencedAssemblyNames ?? new List<AssemblynameNode>()
                    )
                {
                    foreach (AssemblynameNode relative in Flatten(child))
                    {
                        yield return relative;
                    }
                }
            }
        }
    }
}
