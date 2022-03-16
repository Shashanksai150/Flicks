using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLib
{
    public class MRNotException : Exception
    {
        
        public MRNotException()
        {
        }

        public MRNotException(string message) : base(message)
        {
        }

        public MRNotException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MRNotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
