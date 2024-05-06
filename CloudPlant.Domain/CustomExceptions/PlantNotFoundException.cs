using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.CustomExceptions
{
    public class PlantNotFoundException : Exception
    {
        public PlantNotFoundException()
        {
        }

        public PlantNotFoundException(string message) : base(message)
        {
        }

        public PlantNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlantNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
