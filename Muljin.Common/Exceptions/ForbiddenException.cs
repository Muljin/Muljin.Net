using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Exceptions
{
    /// <summary>
    /// Exceptions thrown directly against user actions performed primarily via API calls.
    /// </summary>
    public class ForbiddenException : MuljinException
    {
        public ForbiddenException() : base() { }

        public ForbiddenException(string message) : base(message) { }

        public ForbiddenException(string message, string errorCode) : base(message, errorCode)
        {
        }


    }
}
