using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLib
{
    public class CustomerNotException : Exception
    {
        public CustomerNotException() { }
        public CustomerNotException(string message) : base(message) { }
        public CustomerNotException(string message, CustomerNotException inner) : base(message, inner) { }
        protected CustomerNotException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

