using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Exceptions
{
    public class MuljinException : Exception
    {
        public MuljinException() { }

        public MuljinException(string message, string errorCode = "GENERR") : base(message)
        {
            ErrorCode = errorCode;
        }

        public string ErrorCode { get; }
    }
}
