using KARYA.CORE.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Types.Api.Interface
{
    public interface IApiResponse
    {
        ResultCode Code { get; }
        string Message { get; }
    }
}
