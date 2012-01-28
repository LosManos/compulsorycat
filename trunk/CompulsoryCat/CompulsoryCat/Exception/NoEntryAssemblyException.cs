using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompulsoryCat.Exception
{
    /// <summary>This exception is used when one tries to Get an EntryAssembly when there is none.
    /// For instance when one tries to load through the unit test.
    /// See http://social.msdn.microsoft.com/Forums/eu/vststest/thread/7ff8caae-56c6-4baa-94c9-7224f69dbd17
    /// and http://msdn.microsoft.com/en-us/library/system.reflection.assembly.getentryassembly.aspx

    /// </summary>
    [Serializable]
    public class NoEntryAssemblyException : System.Exception
    {
        public NoEntryAssemblyException() { }
        public NoEntryAssemblyException(string message) : base(message) { }
        public NoEntryAssemblyException(string message, System.Exception inner) : base(message, inner) { }
        protected NoEntryAssemblyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
