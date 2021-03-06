using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.Core.Types.Return
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(success:true)
        {
        }

        public SuccessResult(string message) : base(success:true, message)
        {
        }
    }
}
