using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CompulsoryCat
{
    /// <summary>This is a utility class for reflection.
    /// See http://www.selfelected.com/catch-property-field-and-method-name-changes-compile-time-in-dotnet/
    /// http://www.selfelected.com/get-calling-methods-name-automatically-in-dotnet/
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public class ReflectionUtility
    {
        /// <summary>This method returns the Class of a static class.
        /// Call it like:
        /// C#: string className = ReflectionUtility.GetClass().Name;
        /// </summary>
        public static Type GetClass()
        {
            return new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().DeclaringType;
        }

        /// <summary>This method returns the Class of a static class.
        /// Call it like:
        /// C#: string className = ReflectionUtility.GetClass( myObject ).Name;
        /// </summary>
        public static Type GetClass( object o)
        {
            return o.GetType();
        }

        /// <summary>This method returns the calling method to the caller of this method.
        /// Like this:
        /// class Main{
        ///    public System.Reflection.MethodBase _method;
        ///    class First{
        ///        public static void FirstMethod(){ Second.SecondMethod(); }
        ///    }
        ///    class Second{
        ///        public static void SecondMethod(){ _method = GetCallingMethod();}
        ///    }
        /// }
        /// Calling myMain.First() would render _methodName == "First".
        /// </summary>
        /// <returns></returns>
        public static MethodBase GetCallingMethod()
        {
            return new System.Diagnostics.StackTrace().GetFrame(2).GetMethod();
        }

        /// <summary>This method returns the full name of the calling method of the caller.
        /// A full name is including namespaces and classes.
        /// </summary>
        /// <returns></returns>
        public static string GetCallingMethodFullNameReturnParametertypes()
        {
            return MethodFullNameReturnParametertypes(new System.Diagnostics.StackTrace().GetFrame(2).GetMethod());
        }

        /// <summary>This method returns data about the method wherefrom the method
        /// is called.  It is a simpler case of 
        ///     System.Reflection.MethodBase.GetCurrentMethod()
        /// or
        ///     System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()
        /// </summary>
        /// <returns></returns>
        public static MethodBase GetMethod()
        {
            return GetCallingMethod();
        }

        /// <summary>This method returns the method name.
        /// Call it like: string methodName = ReflectionUtility.GetMethodName [ MyClass, Func [ int ] ] ((MyClass x) => x.MyMethod);
        /// See http://www.selfelected.com/get-calling-methods-name-automatically-in-dotnet/
        /// Unfortunately it cannot handle method without return value and cannot handle
        /// methods with arguments.
        /// It also cannot handle static methods, at least I haven't found out how to do.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetMethodName<T, TReturn>(Expression<Func<T, TReturn>> expression)
        {
            var body = expression.Body as UnaryExpression;
            var operand = body.Operand as MethodCallExpression;
            var argument = operand.Arguments[2] as ConstantExpression;
            var methodInfo = argument.Value as System.Reflection.MethodInfo;
            return methodInfo.Name;
        }

        /// <summary>This method returns the property name.
        /// Call it like: 
        /// C#:  string fieldName = ReflectionUtility.GetPropertyName((MyClass x) => x.MyField);
        /// VB:  G.ReflectionUtility.GetPropertyName(Function(x As BABWebRef.SokArendeAvanceradRad) x.Diarienummer)
        /// See http://www.selfelected.com/catch-property-field-and-method-name-changes-compile-time-in-dotnet/
        /// It doesn't work with static classes or static properties, at least I haven't found out how.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetPropertyName<T, TReturn>(Expression<Func<T, TReturn>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }

        /// <summary>This method returns the full name of a method.
        /// A full name is including namespaces and classes.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string MethodFullName(System.Reflection.MethodBase method)
        {
            return string.Format( "{0}.{1}", method.DeclaringType.FullName, method.Name);
        }

        /// <summary>This method returns the full name of a method and its return type.
        /// A full name is including namespaces and classes.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string MethodFullNameReturn(System.Reflection.MethodBase method)
        {
            return string.Format("{0} {1}.{2}", ((System.Reflection.MethodInfo)method).ReturnType, method.DeclaringType.FullName, method.Name);
        }

        /// <summary>This method returns the full name of a method and its return type and its parameters.
        /// A full name is including namespaces and classes.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string MethodFullNameReturnParametertypes(System.Reflection.MethodBase method)
        {
            return string.Format("{0} {1}.{2} ({3})",
                ((System.Reflection.MethodInfo)method).ReturnType,
                method.DeclaringType.FullName,
                method.Name,
                string.Join(",", method.GetParameters().Select(p => p.ParameterType.ToString() + " " + p.Name).ToArray())   // () or (int) or (int,string) etc.
                );
        }

    }
}
