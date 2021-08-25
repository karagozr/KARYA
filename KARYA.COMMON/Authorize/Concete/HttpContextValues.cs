using KARYA.COMMON.Authorize.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace KARYA.COMMON.Authorize.Concete
{
    public class HttpContextValues : IHttpContextValues
    {

        private IHttpContextAccessor _httpContextAccessor;
        public HttpContextValues(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            HttpContext = httpContextAccessor.HttpContext;
        }


        public HttpContext HttpContext { get; set; }

        public string UserId()
        {
            if (HttpContext.User.Claims.Count()>0)
            {
                return HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            }
            else
            {
                return "0";
            }

        }
    }
}
