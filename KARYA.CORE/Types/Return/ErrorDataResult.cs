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

        public ErrorDataResult() : base(default, success: false)
        {

        }
    }
}
