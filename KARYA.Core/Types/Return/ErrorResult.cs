using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.Core.Types.Return
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(success:false)
        {
        }

        public ErrorResult(string message) : base(success:false, message)
        {
        }
    }
}
