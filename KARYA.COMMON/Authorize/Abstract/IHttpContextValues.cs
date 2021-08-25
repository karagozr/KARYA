using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.COMMON.Authorize.Abstract
{
    public interface IHttpContextValues
    {
        HttpContext HttpContext { get; set; }

        string UserId();
    }
}
