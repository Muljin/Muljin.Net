using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.AspNetCore
{
    public class ErrorResult
    {
        public string ErrorCode { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}
