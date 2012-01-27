using System;
using System.Reflection;

namespace CompulsoryCat
{
    /// <summary>This class contains extension methods for the MemberInfo class.
    /// </summary>
    public static class MemberInfoExtension
    {
        /// <summary>This helper method returns the Property name in a formatted manner.
        /// This means that the property "Title" returns its name as "Title" and not "get_Title"
        /// as the CLR has it.
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static string FormattedPropertyName( this MemberInfo me)
        {
            if (me.Name.StartsWith("get_"))
            {
                return me.Name.Substring(4);
            }
            if (me.Name.StartsWith("set_"))
            {
                return me.Name.Substring(4);
            }
            return me.Name;
        }
    }
}
