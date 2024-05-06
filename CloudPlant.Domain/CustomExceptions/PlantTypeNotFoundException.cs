using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.CustomExceptions
{
    public class PlantTypeNotFoundException : Exception
    {
        public PlantTypeNotFoundException()
        {
        }

        public PlantTypeNotFoundException(string message) : base(message)
        {
        }

        public PlantTypeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlantTypeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
