using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.CORE.Types.Return.Interfaces
{
    public interface IDataResult<TData>:IResult
    {
        TData Data { get; }
    }
}
