//Thus grew the tale of Wonderland:
// Thus slowly, one by one,
// Its quaint events were hammered out -
// And now the tale is done,
// And home we steer, a merry crew,
// Beneath the setting sun.

using System;
using CompulsoryCat.Meta;

namespace CompulsoryCatExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("In a method we can ask for its name with a method call. [{0}]",
                                            ReflectionUtility.GetMethod().Name));
            Console.WriteLine(string.Format("or its class. [{0}]", ReflectionUtility.GetClass().Name));
            Console.WriteLine(string.Format("note that we get the whole Info so we can gete more [{0}]", ReflectionUtility.GetClass()));
            Console.WriteLine();

            var o = new MyClass();
            o.MyMethod();
            MyStaticClass.MyStaticMethod();

            Console.WriteLine();
            Console.WriteLine("The ReflectionUtility class contains more good stuff.");
            Console.WriteLine("But there are also big holes in it.  There are problems with getting data from a static method or class" +
                " outside it.");

            Console.WriteLine();
            Console.Write("Press any key");
            Console.ReadKey();
        }
    }
}
