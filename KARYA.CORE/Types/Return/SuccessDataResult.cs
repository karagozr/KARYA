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
        public SuccessDataResult(string message):base(default,success:true,message)
        {

        }

    }
}
