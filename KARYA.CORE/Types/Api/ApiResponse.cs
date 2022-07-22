using KARYA.CORE.Entities.Enum;
using KARYA.CORE.Types.Api.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Types.Api
{
    public class ApiResponse : IApiResponse
    {
        public ApiResponse(ResultCode code, string message) : this(code) => Message = message;
       
        public ApiResponse(ResultCode code) => Code = code;
        
        public ResultCode Code { get; }

        public string Message { get; }
    }
}
