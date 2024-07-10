using System;
using System.Collections.Generic;
using System.Text;

namespace Muljin.AspNetCore
{
    public record ErrorResult
    {
        public string ErrorCode { get; set; }

        public required string Message { get; set; }

        public bool Success { get; set; }
    }
}
