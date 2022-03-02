using KARYA.BUSINESS.Abstract;
using KARYA.COMMON.Attributes;
using KARYA.MODEL.Dtos.AuthGroup;
using KARYA.MODEL.Dtos.User;
using KARYA.MODEL.Module;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.API.Controllers.v2
{
    [Route("api/v2/Admin/AuthGroup")]
    public class AdminAuthorizeGroupController : BaseController
    {
        IAuthGroupManager _authGroupManager;
        ICoreModules _appModules;
        public AdminAuthorizeGroupController(IAuthGroupManager authGroupManager, ICoreModules appModules)
        {
            _authGroupManager = authGroupManager;
            _appModules = appModules;
        }

        [HttpGet("AppModules")]
        [KaryaAuthorize(Role = BaseRole.AdminPanel)]
        public async Task<IActionResult> AppModules()
        {
            return Ok(_appModules.ModuleList);
        }

        [HttpGet("List")]
        [KaryaAuthorize(Role = BaseRole.AuthGroupPanel)]
        public async Task<IActionResult> List()
        {
            var result = await _authGroupManager.List();
            if (!result.Success) return BadRequest(result.Message);
            else return Ok(result.Data);
        }

        [HttpGet("Get")]
        [KaryaAuthorize(Role = BaseRole.AuthGroupPanel)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _authGroupManager.GetWithDetail(id);
            if (!result.Success) return BadRequest(result.Message);
            else return Ok(result.Data);
        }

        [HttpPost("Edit")]
        [KaryaAuthorize(Role = BaseRole.AuthGroupEdit)]
        public async Task<IActionResult> Edit(AuthGroupSDto authGroupSDto)
        {
            var resultUser = await _authGroupManager.Edit(authGroupSDto);
            if (!resultUser.Success) return BadRequest(resultUser.Message);
            else return Ok();
        }
    }
}
