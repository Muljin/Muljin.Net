using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Exceptions
{
    /// <summary>
    /// Conflict in selected action.
    /// </summary>
    public class ConflictException : UserActionException
    {
        public ConflictException() {
            new ConflictException("Conflict");
        }

        public ConflictException(string message){
            new ConflictException(message, "CE001");
        }

        public ConflictException(string message, string errorCode) : base(message, errorCode) { }
    }
}
