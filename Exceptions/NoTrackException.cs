using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GokartyProjekt.Exceptions
{
    public class NoTrackException : Exception
    {
        public NoTrackException()
        {
        }

        public NoTrackException(string message) : base(message)
        {
        }

        public NoTrackException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoTrackException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
