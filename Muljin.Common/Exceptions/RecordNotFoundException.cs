using System;

namespace Muljin.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException() { }

        public RecordNotFoundException(string message) : base(message) { }
    }
}
