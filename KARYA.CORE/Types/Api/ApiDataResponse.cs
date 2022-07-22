using KARYA.CORE.Entities.Enum;
using KARYA.CORE.Types.Api.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Types.Api
{
    public class ApiDataResponse<TData> : ApiResponse, IApiDataResponse<TData>
    {
        public ApiDataResponse(ResultCode code, string message,TData data) : base(code, message) => Data = data;
        
        public ApiDataResponse(ResultCode code,TData data) : base(code) => Data = data;

        public TData Data { get; }
    }
}
