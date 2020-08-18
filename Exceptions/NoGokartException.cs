using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GokartyProjekt.Exceptions
{
    public class NoGokartException : Exception
    {
        public NoGokartException()
        {
        }

        public NoGokartException(string message) : base(message)
        {
        }

        public NoGokartException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoGokartException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
