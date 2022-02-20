using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Exceptions
{
    public class ServiceUnavailableException : MuljinException
    {
        public ServiceUnavailableException() { }

        public ServiceUnavailableException(string message) : base(message) { }

        public ServiceUnavailableException(string message, string errorCode) : base(message, errorCode) { }
}
}
