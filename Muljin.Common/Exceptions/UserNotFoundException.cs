using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Exceptions
{
    /// <summary>
    /// Exception for selected user not found
    /// </summary>
    public class UserNotFoundException : UserActionException
    {
        public UserNotFoundException(){
            new UserNotFoundException("User not found");
        }

        public UserNotFoundException(string message)
        {
            new UserNotFoundException(message, "UNF001");
        }

        public UserNotFoundException(string message, string errorCode): base(message, errorCode) { }
    }
}
