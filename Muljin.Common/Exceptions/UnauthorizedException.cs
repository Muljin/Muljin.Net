using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Exceptions
{
    /// <summary>
    /// Authenticated user is not authorized to perform requested action
    /// </summary>
    public class UnauthorizedException : UserActionException
    {
        public UnauthorizedException() {
            
        }

        public UnauthorizedException(string message)
        {
            new UnauthorizedException(message, "UU001");
        }

        public UnauthorizedException(string message, string errorCode) : base(message,errorCode) { }
    }
}
