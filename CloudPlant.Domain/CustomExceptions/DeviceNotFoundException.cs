using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.CustomExceptions
{
    public class DeviceNotFoundException : Exception
    {
        public DeviceNotFoundException()
        {
        }

        public DeviceNotFoundException(string message) : base(message)
        {
        }

        public DeviceNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeviceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
