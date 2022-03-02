using KARYA.BUSINESS.Abstract;
using KARYA.COMMON.Attributes;
using KARYA.MODEL.Dtos.User;
using KARYA.MODEL.Module;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KARYA.CORE.API.Controllers.v2
{
    [Route("api/v2/Admin/User")]
    public class AdminUserController:BaseController
    {
        IUserManager _userManager;
        public AdminUserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetForEdit")]
        [KaryaAuthorize(Role = BaseRole.UserPanel)]
        public async Task<IActionResult> GetForEdit(int id)
        {
            var result = await _userManager.Get(id);
            if (!result.Success) return BadRequest(result.Message);
            else return Ok(result.Data);
        }

        [HttpGet("ListForEdit")]
        [KaryaAuthorize(Role = BaseRole.UserPanel)]
        public async Task<IActionResult> ListForEdit()
        {
            var result = await _userManager.ListWithAuthGroups();
            if (!result.Success) return BadRequest(result.Message);
            else return Ok(result.Data);
        }

        [HttpPost("ResetPassword")]
        [KaryaAuthorize(Role = BaseRole.UserResetPassword)]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDto userPasswordDto)
        {
            var result = await _userManager.ResetPassword(userPasswordDto);
            if (!result.Success && result.Message == "KRY102")
                return NotFound();
            if (!result.Success) return BadRequest(result.Message);
            else return Ok();
        }

        [HttpPost("Edit")]
        [KaryaAuthorize(Role = BaseRole.UserEdit)]
        public async Task<IActionResult> Edit(UserSDto editUser)
        {
            var resultUser = await _userManager.Edit(editUser);
            if (!resultUser.Success) return BadRequest(resultUser.Message);
            else return Ok();
        }
    }
}
