using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompulsoryCat
{
    /// <summary>This class contains extention methods (and helper methods) to the string class.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>This helper methods returns a list of string which are all of a max length.
        /// E.g.: "abcdefg".SplitToLength( 2 ) == ["ab", "cd", "ef", "g"]
        /// "".SplitToLength(2) == []
        /// It just calls SplitToLength( string, int ).
        /// </summary>
        /// <param name="me"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IList<string> SplitToLength(this string me, int length)
        {
            return StaticSplitToLength(me, length);
        }

        /// <summary>This helper methods returns a list of string which are all of a max length.
        /// E.g.: StaticSplitToLength( "abcdefg", 2 ) == ["ab", "cd", "ef", "g"]
        /// "".SplitToLength(2) == []
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static IList<string> StaticSplitToLength(string s, int length)
        {
            if (string.IsNullOrEmpty(s)) { return new List<string>(); }
            var ret = new List<string>() { string.Join(string.Empty, s.Take(length)) };
            var tail = string.Join(string.Empty, s.Skip(length));
            if ( tail.Length >= 1 ) {
                ret.AddRange(StaticSplitToLength(tail, length));
            }
            return ret;
        }
    }
}
