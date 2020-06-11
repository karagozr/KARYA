using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.Core.Types.Return.Interfaces
{
    public interface IDataResult<TData>:IResult
    {
        TData Data { get; }
    }
}
