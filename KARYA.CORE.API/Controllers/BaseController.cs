//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using KARYA.COMMON.Attributes;


//namespace KARYA.CORE.API.Controllers
//{
//    //[Authorize]
//    [ApiController]
//    //[Route("[controller]")]
//    public class BaseController : Controller
//    {
//        public JsonSerializerSettings _SERILAZERSETTING;

//        public string UserId;
//        public BaseController()
//        {
//            _SERILAZERSETTING = new JsonSerializerSettings();
//            _SERILAZERSETTING.ContractResolver = new CamelCasePropertyNamesContractResolver();
//            if (HttpContext!=null)
//             UserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
//        }
//    }
//}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KARYA.COMMON.Attributes;
using KARYA.CORE.Types.Api;
using KARYA.CORE.Entities.Enum;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using KARYA.CORE.Types.Api.Interface;
using Microsoft.AspNetCore.Http;
using KARYA.COMMON.Helpers;
using KARYA.CORE.Types.Return.Interfaces;

namespace KARYA.CORE.API.Controllers
{
    //[Authorize]

    [ApiController]
    public class BaseController : Controller
    {
        public JsonSerializerSettings _SERILAZERSETTING;

        public string UserId;
        public BaseController()
        {
            _SERILAZERSETTING = new JsonSerializerSettings();
            _SERILAZERSETTING.ContractResolver = new CamelCasePropertyNamesContractResolver();
            if (HttpContext != null)
                UserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }

        protected virtual BaseApiResult ApiResult(ResultCode resultCode)
        {
            return new BaseApiResult(resultCode);
        }

        protected virtual BaseApiResult ApiResult(IResult result)
        {
            return new BaseApiResult(result.Code, result.Message);
        }

        protected virtual BaseApiResult<TData> ApiResult<TData>(IDataResult<TData> result)
        {
            return new BaseApiResult<TData>(result.Code, result.Message, result.Data);
        }

        protected virtual BaseApiResult ApiResult(ResultCode resultCode, string message)
        {
            return new BaseApiResult(resultCode, message);
        }

        protected virtual BaseApiResult<TData> ApiResult<TData>(ResultCode resultCode, TData data)
        {
            return new BaseApiResult<TData>(resultCode, data);
        }

        protected virtual BaseApiResult<TData> ApiResult<TData>(ResultCode resultCode, string message, TData data)
        {
            return new BaseApiResult<TData>(resultCode, message, data);
        }

    }

    public class BaseApiResult : ApiResponse, IActionResult, IApiResponse
    {
        
        public BaseApiResult(ResultCode code) : base(code)
        {
        }

        public BaseApiResult(ResultCode code, string message) : base(code, message)
        {
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(null)
            {
                StatusCode = (int)Code,
                Value = new
                {
                    Message = Message ?? Code.Description(),
                }
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }

    public class BaseApiResult<T> : ApiDataResponse<T>, IActionResult, IApiDataResponse<T>
    {
        public BaseApiResult(ResultCode code, T data) : base(code, data)
        {
        }

        public BaseApiResult(ResultCode code, string message, T data) : base(code, message, data)
        {
        }


        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(null)
            {
                StatusCode = (int)Code,
                Value = new
                {
                    Message = Message ?? Code.Description(),
                    Data = Data
                }
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
