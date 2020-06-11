using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.Core.Types.Return.Interfaces
{
    public interface IResult
    {
        bool Success { get; }

        string Message { get; }
    }
}
