using KARYA.MODEL.Authorize.SahizaWorld;
using KARYA.MODEL.Entities.Karya;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.WEB.MVC.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        public BaseController()
        {

        }

        public void AuthenticateUser(Users user)
        {
            var userAuthorizeGroups = user.UserAuthorizeGroups;
            var autorizeGroups = userAuthorizeGroups.Select(x => x.AuthorizeGroup.AuthorizeGroupDetails);
            var roles = new List<int>();

            foreach (var group in autorizeGroups)
            {
                foreach (var item in group)
                {
                    if (roles.Count(x => x == item.AppModuleId) == 0)
                        if (item.IsAuthorize == true)
                            roles.Add(item.AppModuleId);
                }
            }

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Name, user.Lastname));
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, Enum.GetName(typeof(AppRole), item).ToString()));
            }

            ClaimsIdentity identity = null;

            identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);
            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);


        }

        
    }

}
