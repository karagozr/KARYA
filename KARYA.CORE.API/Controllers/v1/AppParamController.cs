using KARYA.BUSINESS.Abstract.Karya;
using KARYA.COMMON.Authorize;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.API.Controllers.v1
{
    [Route("api/v1/AppParam")]
    public class AppParamController:BaseController
    {
        IAppParameterManager _appParameterManager;
        public AppParamController(IAppParameterManager appParameterManager)
        {
            _appParameterManager = appParameterManager;
        }

        [HttpGet("EditSingleParam")]
        //[KaryaAuthorize]
        public async Task<IActionResult> EditSingleParam(string name, string value)
        {
            var result = await _appParameterManager.EditSingleParam(name, value);

            if (result.Success) return Ok();
            else return BadRequest();
        }

        [HttpGet("GetSingleParam")]
        //[KaryaAuthorize]
        public async Task<IActionResult> GetSingleParam(string name)
        {
            var result = await _appParameterManager.GetSingleParamValue(name);

            if (result.Success) return Ok(result.Data);
            else return BadRequest();
        }
    }
}
