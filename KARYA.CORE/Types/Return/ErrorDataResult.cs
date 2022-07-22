using KARYA.CORE.Entities.Enum;
using KARYA.CORE.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.CORE.Types.Return
{
    public class ErrorDataResult<TData> : DataResult<TData>
    {
        public ErrorDataResult(TData data ) : base(data, success:false)
        {

        }

        public ErrorDataResult(TData data, string message) : base(data, success:false, message)
        {

        }
        public ErrorDataResult(string message):base(default,success:false,message)
        {

        }

        public ErrorDataResult(TData data, string message, ResultCode code) : base(data, success: false, message, code)
        {

        }

        public ErrorDataResult(TData data, ResultCode code) : base(data, success: false, code.Description(), code)
        {

        }

        public ErrorDataResult(TData data, ResultCode code,string message) : base(data, success: false, message, code)
        {

        }

        public ErrorDataResult() : base(default, success: false)
        {

        }
    }
}
