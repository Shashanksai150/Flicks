using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace ExceptionLib
{
    public class CRNotException : Exception
    {
        public CRNotException()
        {
        }

        public CRNotException(string message) : base(message)
        {
        }

        public CRNotException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CRNotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
