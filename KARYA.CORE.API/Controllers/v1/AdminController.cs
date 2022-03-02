using KARYA.BUSINESS.Abstract.Karya;
using KARYA.COMMON.Authorize;
using KARYA.MODEL.Authorize.Karya;
using KARYA.MODEL.DataTransferModels.Karya.Auth;
using KARYA.MODEL.DataTransferModels.Karya.Finance.Admin;
using KARYA.MODEL.Dtos.Karya.Admin;
using KARYA.MODEL.Entities.Karya;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.CORE.API.Controllers.v1
{
    //[KaryaAuthorize(RoleEnum = AppModuleRole.AdminPanel)]
    [Route("api/v1/Admin")]
    public class AdminController : BaseController
    {
        IConfiguration _configuration;

        IUserManager _userManager;
        IUserAuthorizeGroupManager _userAuthorizeGroupManager;
        IAuthorizeGroupManager _authorizeGroupManager;
        IAuthorizeGroupDetailFieldAccessManager _authorizeGroupDetailFieldAccessManager;
        IAppParameterManager _appParameterManager;
        public AdminController(IUserManager userManager, IUserAuthorizeGroupManager userAuthorizeGroupManager,
            IConfiguration configuration, IAuthorizeGroupManager authorizeGroupManager, 
            IAuthorizeGroupDetailFieldAccessManager authorizeGroupDetailFieldAccessManager,
            IAppParameterManager appParameterManager)
        {
            _authorizeGroupManager = authorizeGroupManager;
            _configuration = configuration;
            _userManager = userManager;
            _userAuthorizeGroupManager = userAuthorizeGroupManager;
            _authorizeGroupDetailFieldAccessManager = authorizeGroupDetailFieldAccessManager;
            _appParameterManager = appParameterManager;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userManager.GetAll();
            if (!result.Success) return BadRequest(result.Message);
            else return Ok(result.Data);
        }

        //[KaryaAuthorize(RoleEnum = AppModuleRole.UserAdd)]
        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser(UserEditDto editUser)
        {
            var resultUser = await _userManager.Edit(editUser);
            if (!resultUser.Success) return BadRequest(resultUser.Message);
            else return Ok();
        }

        //[KaryaAuthorize(RoleEnum = AppModuleRole.UserEdit)]
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserModel userModel)
        {
            var resultUpdateUser = await _userManager.UpdateComplex(userModel);
            if (!resultUpdateUser.Success) return BadRequest(resultUpdateUser.Message);

            return Ok();
        }

        //[KaryaAuthorize(RoleEnum = AppModuleRole.UserDelete)]
        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var resultUser = await _userManager.Delete(userId);
            if (!resultUser.Success) return BadRequest(resultUser.Message);
            else return Ok();
        }

        [HttpGet("GetAuthorizeGroups")]
        public async Task<IActionResult> GetAuthorizeGroups()
        {
            var result = await _authorizeGroupManager.GetAll();
            if (!result.Success) return BadRequest(result.Message);
            else return Ok(result.Data);
        }

        [HttpGet("GetAuthorizeGroup")]
        public async Task<IActionResult> GetAuthorizeGroup(int Id)
        {

            var result = await _authorizeGroupManager.GetWithDetail(Id);
            if (!result.Success) return BadRequest(result.Message);
            else return Ok(result.Data);
        }

        [HttpPost("AddAuthorizeGroup")]
        public async Task<IActionResult> AddAuthorizeGroup(AuthorizeGrupModel authorizeGrupModel)
        {

            var result = await _authorizeGroupManager.Add(authorizeGrupModel);
            if (!result.Success) return BadRequest(result.Message);
            else return Ok();
        }

        [HttpPost("UpdateAuthorizeGroup")]
        public async Task<IActionResult> UpdateAuthorizeGroup(AuthorizeGrupModel authorizeGrupModel)
        {
            var result = await _authorizeGroupManager.Update(authorizeGrupModel);
            if (!result.Success) return BadRequest(result.Message);
            else return Ok();
        }

        [HttpGet("DeleteAuthorizeGroup")]
        public async Task<IActionResult> DeleteAuthorizeGroup(int authorizeGrupId)
        {

            var result = await _authorizeGroupManager.Delete(authorizeGrupId);
            if (!result.Success) return BadRequest(result.Message);
            return Ok();
        }


        [HttpPost("AddUpdateAuthorizeGroupFilter")]
        public async Task<IActionResult> AddUpdateAuthorizeGroupFilter(IEnumerable<AuthorizeGrupDetailFilterModel> authorizeGrupDetailFilterModels)
        {
            var result = await _authorizeGroupDetailFieldAccessManager.AddUpdateList(authorizeGrupDetailFilterModels);
            if (!result.Success) return BadRequest(result.Message);
            return Ok();
        }

        [HttpPost("DeleteAuthorizeGroupFilter")]
        public async Task<IActionResult> DeleteAuthorizeGrouFilterp(IEnumerable<int> ids)
        {
            var result = await _authorizeGroupDetailFieldAccessManager.DeleteList(ids);
            if (!result.Success) return BadRequest(result.Message);
            return Ok();
        }

        [HttpGet("GetAllAppParameters")]
        public async Task<IActionResult> GetAllAppParameters()
        {
            var result = await _appParameterManager.GetAll();
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result.Data);
        }
        [HttpPost("SetAppParameter")]
        public async Task<IActionResult> SetAppParameter(AppParameter appParameter)
        {
            var result = await _appParameterManager.AddUpdate(appParameter);
            if (!result.Success) return BadRequest(result.Message);
            return Ok();
        }
    }
}
