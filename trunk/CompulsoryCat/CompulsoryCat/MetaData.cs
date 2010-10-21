using System;
using System.Linq;
using System.Reflection;

namespace CompulsoryCat
{
    public static class MetaData
{
       /// <summary>This method returns data about the class.
       /// Just do a 
       ///  using MetaData
       /// and you have it in the object.
       /// </summary>
       /// <param name="me"></param>
       /// <returns></returns>
        public static Type GetClass( this object me )
        {
            return me.GetType();
        }

        /// <summary>This method returns data about the method.
        /// Just do a 
        ///  using MetaData
        /// and you have it in the object.
        /// 
        /// One can probably use
        /// System.Reflection.MethodBase.GetCurrentMethod()
        /// or
        /// System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()
        /// for the same result.
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static MethodBase GetMethod(this object me)
        {
            return ReflectionUtility.GetCallingMethod();
        }

        /// <summary>This method returns the MemberInfo of the property we are calling it from.
        /// Use it like:
        /// class MyClass{
        ///     public string Title{
        ///         Log( this.GetProperty().FormattedPropertyName );    //  Just call with this.GetProperty.
        ///         return _title;
        ///     }
        /// }
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static MemberInfo GetProperty( this object me)
        {
            return me.GetType().GetMember(ReflectionUtility.GetCallingMethod().Name).Single();
        }
    }
}
