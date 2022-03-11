using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieExceptions
{
    public class MovieNotException : Exception
    {
        public MovieNotException()
        {
        }

        public MovieNotException(string message) : base(message)
        {
        }

        public MovieNotException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MovieNotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }


    }

}
