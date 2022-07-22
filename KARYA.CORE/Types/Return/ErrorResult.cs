using KARYA.CORE.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.CORE.Types.Return
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(success:false)
        {
        }

        public ErrorResult(string message) : base(success:false, message)
        {
        }

        public ErrorResult(string message, ResultCode code) : base(success: false, message,code)
        {
        }
    }
}
