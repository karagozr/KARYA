using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KARYA.BUSINESS.Abstract.Karya;
using KARYA.COMMON.Authorize;
using KARYA.MODEL.Authorize.Karya;
using KARYA.MODEL.Common.Auth;
using KARYA.MODEL.Entities.Karya;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace KARYA.CORE.API.Controllers.v1
{
    [Route("api/v1/Auth")]
    public class AuthController : BaseController
    {
        IConfiguration _configuration;

        IUserManager _userManager;
        IUserAuthorizeGroupManager _userAuthorizeGroupManager;

        public AuthController(IUserManager userManager, IUserAuthorizeGroupManager userAuthorizeGroupManager, IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
            _userAuthorizeGroupManager = userAuthorizeGroupManager;
           
            var UserId = HttpContext != null? HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value : "0";
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginModel)
        {
            var resultUser = await _userManager.Login(userLoginModel);

            if (resultUser.Success == false) return BadRequest();
            if (resultUser.Data == null) return NoContent();

            //return Ok(new { resultUser.Data.Name, resultUser.Data.UserName});

            var expiresDate = DateTime.UtcNow.AddDays(7);
            if (resultUser.Success == true)
            {
                if (resultUser.Data != null)
                {
                    return Ok(new
                    {
                        login = true,
                        Token = GenerateToken(resultUser.Data),
                        EndTime = expiresDate,
                        Message = resultUser.Message
                    });
                }
                else
                {
                    return NoContent();
                }

            }
            else
            {
                return BadRequest(new
                {
                    login = false,
                    Message = resultUser.Message
                });
            }


            string GenerateToken(Users users)
            {

                var userAuthorizeGroups = users.UserAuthorizeGroups;
                var autorizeGroups = userAuthorizeGroups.Select(x => x.AuthorizeGroup.AuthorizeGroupDetails);
                var roles = new List<int>();

                foreach (var group in autorizeGroups)
                {
                    foreach (var item in group)
                    {
                        if(roles.Count(x=>x == item.AppModuleId)==0)
                            if(item.IsAuthorize==true)
                                roles.Add(item.AppModuleId);
                    }
                }



                var roleList = new List<Claim>();
                roleList.Add(new Claim(ClaimTypes.NameIdentifier, users.Id.ToString()));
                roleList.Add(new Claim(ClaimTypes.Name, users.UserName.ToString()));
                roleList.Add(new Claim("Fullname", users.Name + " " + users.Lastname));
                //var vals = Enum.GetValues(typeof(AppRole));

                foreach (var item in roles)
                {
                    roleList.Add(new Claim(ClaimTypes.Role, item.ToString()));
                }

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    roleList.ToArray(),
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: credentials); ;

                return new JwtSecurityTokenHandler().WriteToken(token);

            }

        }


        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            
            return "Login user : " + identity;
        }

        [HttpGet("GetValues")]
        [KaryaAuthorize(RoleEnum = AppRole.AdminModule)]
        public IEnumerable<string> GetValues()
        {

            return new string[]
            {
                "Values",
                "Values1",
                "Values2"
            };
        }
    }
}
