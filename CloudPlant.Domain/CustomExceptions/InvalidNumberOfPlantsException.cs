using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.CustomExceptions
{
    public class InvalidNumberOfPlantsException : Exception
    {
        public InvalidNumberOfPlantsException()
        {
        }

        public InvalidNumberOfPlantsException(string message) : base(message)
        {
        }

        public InvalidNumberOfPlantsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidNumberOfPlantsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
