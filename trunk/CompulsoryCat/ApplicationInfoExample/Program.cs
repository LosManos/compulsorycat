using System;
using System.Linq;
using CompulsoryCat.Assemblyname;

namespace ApplicationInfoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblynameTreeAndList assemblynameInfo = AssemblynameHelper.Get();

            Console.WriteLine("List:");
            assemblynameInfo.AssemblynameList.OrderBy(an => an.Name).ToList().ForEach(
                an => Console.WriteLine(string.Format("{0}", an.Name))
            );
            Console.WriteLine();

            Console.WriteLine("Flattened tree:");
            assemblynameInfo.Tree.AsFlattened().ToList().ForEach(
                info => Console.WriteLine("{0}\t{1}",
                    info.AssemblyName.Name,
                    null == info.ReferencedAssemblyNames
                        ? "null"
                        : info.ReferencedAssemblyNames.Count().ToString()
                )
            );
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Press any key");
            Console.ReadKey();
        }

    }
}
