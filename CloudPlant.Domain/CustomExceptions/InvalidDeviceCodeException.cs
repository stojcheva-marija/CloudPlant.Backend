using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.CustomExceptions
{
    public class InvalidDeviceCodeException : Exception
    {
        public InvalidDeviceCodeException()
        {
        }

        public InvalidDeviceCodeException(string message) : base(message)
        {
        }

        public InvalidDeviceCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDeviceCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
