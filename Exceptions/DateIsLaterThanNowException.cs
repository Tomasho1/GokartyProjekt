using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GokartyProjekt.Exceptions
{
    public class DateIsLaterThanNowException : Exception
    {
        public DateIsLaterThanNowException()
        {
        }

        public DateIsLaterThanNowException(string message) : base(message)
        {
        }

        public DateIsLaterThanNowException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DateIsLaterThanNowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
