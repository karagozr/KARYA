using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KARYA.CORE.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BaseController : Controller
    {
        public JsonSerializerSettings _SERILAZERSETTING;
        
        public string UserId;
        public BaseController()
        {
            _SERILAZERSETTING = new JsonSerializerSettings();
            _SERILAZERSETTING.ContractResolver = new CamelCasePropertyNamesContractResolver();
            if (HttpContext!=null)
             UserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
