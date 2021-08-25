using KARYA.BUSINESS.Abstract.Karya;
using KARYA.BUSINESS.Concrete.Karya;
using KARYA.MODEL.Authorize.SahizaWorld;
using KARYA.MODEL.Common.Auth;
using KARYA.MODEL.Entities.Karya;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SAHIZA.WEB.MVC.Controllers
{
    public class AccountController : Controller
    {
        IUserManager _userManager;
        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult Login(string url)
        //{
        //    return View();
        //}

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            var result = await _userManager.Login(userLoginModel);
            if (result.Success == false)
            {
                return RedirectToPage("error.html");
            }
            if (result.Data == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı");
                ViewBag.userName = userLoginModel.UserName;
                ViewBag.password = userLoginModel.Password;
                return View();
            }
            else
            {
                AuthenticateUser(result.Data);

                return RedirectToAction("Index","Home");
            }

        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccessDenied(string ReturnUrl){
            return View();
        }

        public async void AuthenticateUser(Users user)
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
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim("Fullname", user.Name + " " + user.Lastname));
            //claims.Add(new Claim("FullName", this.FullName));
            //claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.ToString()));
            }

            var identity = new ClaimsIdentity(claims, "Login");

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


        }

    }
}
