using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Authorize
{
    public class HttpContextValues
    {
        private IHttpContextAccessor _httpContextAccessor;
        public HttpContext HttpContext { get; set; }
        public HttpContextValues()
        {
            _httpContextAccessor = new HttpContextAccessor();
            HttpContext = _httpContextAccessor.HttpContext;
        }

        public int UserId()
        {
            if (HttpContext.User.Claims.Count() > 0)
            {
                var result = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                return Convert.ToInt32(result);
            }
            else
            {
                return 0;
            }

        }
    }
}
