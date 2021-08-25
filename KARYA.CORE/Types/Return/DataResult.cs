using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.CORE.Types.Return
{
    public class DataResult<TData> : Result, IDataResult<TData>
    {
        public DataResult(TData data, bool success, string message): base(success,message)
        {
            Data = data;
        }

        public DataResult(TData data, bool success) : base(success)
        {
            Data = data;
        }
        public TData Data { get; }
    }
}
