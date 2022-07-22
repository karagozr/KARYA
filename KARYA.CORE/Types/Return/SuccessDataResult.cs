using KARYA.CORE.Entities.Enum;
using KARYA.CORE.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.CORE.Types.Return
{
    public class SuccessDataResult<TData> : DataResult<TData>
    {
        public SuccessDataResult(TData data ) : base(data, success:true)
        {

        }

        public SuccessDataResult(TData data, string message) : base(data, success:true, message)
        {

        }

        public SuccessDataResult(TData data, string message, ResultCode code) : base(data, success: true, message,code)
        {

        }

        public SuccessDataResult(string message):base(default,success:true,message)
        {

        }

        public SuccessDataResult(TData data, ResultCode code) : base(data, success: true, code.Description(), code)
        {

        }

        public SuccessDataResult(TData data, ResultCode code, string message) : base(data, success: true, message, code)
        {

        }

    }
}
