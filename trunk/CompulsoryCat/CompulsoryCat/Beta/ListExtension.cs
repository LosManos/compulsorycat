using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompulsoryCat.Beta
{
    /// <summary>This class contains extention methods (and helper methods) to the List class.
    /// Well... it doesn't as of right now.
    /// But... it contains a static helper method.  For something similar to an array.
    /// </summary>
    public static class ListExtension
    {
        /// <summary>This method splits the incoming strings to equal length.
        /// If a string is longer than the others the items will be null.  Hmm... se example.
        /// E.g.: SplitTLOEL( [ "a", "abc", "abcde" ], 2 ) == [ ["a",null,null],["ab","c",null],["ab","cd","e"] ]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listOfStrings"></param>
        /// <returns></returns>
        public static List<List<string>> SplitToListsOfEqualLength( IList<string> listOfStrings, int length)
        {
            //   We now have for instance ["a","abc","abcde"].

            //  Convert to [["a"],["ab","c"],["ab","cd","e"]].
            List<IList<string>> lstlst = listOfStrings.Select(s => s.SplitToLength(length)).ToList();
         
            //  Get the length of the longest list.  In our example: ["ab","cd","e"] gives 3.
            int maxLength = lstlst.Select( lst => lst.Count).Max();

            //  Create the base to return.
            var ret = new List<List<string>>();

            //  Then fill upp to [ [],[],[] ].
            foreach( List<string> lst in lstlst ){
                ret.Add(new List<string>());
            }

            //  Now add nulls to maxlength.  Our example gives: [ [null,null,null],[null,null,null],[null,null,null] ]
            for (int i = 0; i < lstlst.Count; ++i)
            {
                ret[i].AddRange(new List<string>(new string[maxLength]));
            }

            //  Finally fill up with the values.
            for (int i = 0; i < lstlst.Count; ++i)
            {
                for (int j = 0; j < lstlst[i].Count; ++j)
                {
                    ret[i][j] = lstlst[i][j];
                }
            }

            return ret;
        }
    }
}
