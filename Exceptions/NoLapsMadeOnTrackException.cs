using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GokartyProjekt.Exceptions
{
    public class NoLapsMadeOnTrackException : Exception
    {
        public NoLapsMadeOnTrackException()
        {
        }

        public NoLapsMadeOnTrackException(string message) : base(message)
        {
        }

        public NoLapsMadeOnTrackException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoLapsMadeOnTrackException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
