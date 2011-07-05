﻿//Alice! a childish story take,
// And with gentle hand
// Lay it were Childhood's dreams are twined
// In Memory's mystic band,
// Like pilgrim's wither'd wreath of flowers
// Pluck'd in a far-off land.

using CompulsoryCat.Meta;
using System;

namespace CompulsoryCatExample
{
    class MyClass
    {
        internal void MyMethod()
        {
            Console.WriteLine(
                string.Format(
                    "We can get the class [{0}] and the method [{1}] right in a the method through extension methods." +
                    "  Just add a using statement in the file.", this.GetClass().Name, this.GetMethod().Name));
        }
    }

    class MyStaticClass
    {
        internal static void MyStaticMethod()
        {
            Console.WriteLine(
                "Also static classes [{0}] and static methods [{1}] can get their names.  But not through extension.",
                ReflectionUtility.GetClass().Name, ReflectionUtility.GetMethod().Name);
        }
    }
}
