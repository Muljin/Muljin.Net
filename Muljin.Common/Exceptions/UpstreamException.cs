using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.Exceptions
{
    /// <summary>
    /// Exception for selected user not found
    /// </summary>
    public class UpstreamException : MuljinException
    {
        public UpstreamException(){
            new UserNotFoundException("Exception occured when calling upstream service");
        }

        public UpstreamException(string message)
        {
            new UserNotFoundException(message, "UPS001");
        }

        public UpstreamException(string message, string errorCode): base(message, errorCode) { }
    }
}
