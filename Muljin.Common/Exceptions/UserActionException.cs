using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Exceptions
{
    /// <summary>
    /// Exceptions thrown directly against user actions performed primarily via API calls.
    /// </summary>
    public class UserActionException : MuljinException
    {
        public UserActionException() : base() { }

        public UserActionException(string message) : base(message) { }

        public UserActionException(string message, string errorCode) : base(message, errorCode)
        {
        }


    }
}
