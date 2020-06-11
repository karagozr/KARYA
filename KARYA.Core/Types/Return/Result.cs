using KARYA.Core.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.Core.Types.Return
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
