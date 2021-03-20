using System;

namespace Muljin
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException() { }

        public RecordNotFoundException(string message) : base(message) { }
    }
}
