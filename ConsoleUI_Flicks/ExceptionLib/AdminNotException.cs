using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLib
{
    public class AdminNotException : Exception
    {
        public AdminNotException() { }
        public AdminNotException(string message) : base(message) { }
        public AdminNotException(string message, CustomerNotException inner) : base(message, inner) { }
        protected AdminNotException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

