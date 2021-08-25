using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.CORE.Types.Return.Interfaces
{
    public interface IResult
    {
        bool Success { get; }

        string Message { get; }
    }
}
