using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GokartyProjekt.Exceptions
{
    public class NoDriverException : Exception
    {
        public NoDriverException()
        {
        }

        public NoDriverException(string message) : base(message)
        {
        }

        public NoDriverException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoDriverException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
