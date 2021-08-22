using System;

namespace Muljin.Exceptions
{
    public class RecordNotFoundException : MuljinException
    {
        public RecordNotFoundException() { }

        public RecordNotFoundException(string message) : base(message) { }

        public RecordNotFoundException(string message, string errorCode) : base(message, errorCode) { }
    }
}
