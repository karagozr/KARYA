using KARYA.BUSINESS.Abstract.Karya;
using KARYA.MODEL.Authorize.SahizaWorld;
using KARYA.MODEL.DataTransferModels.Karya.Auth;
using KARYA.MODEL.Dtos.Karya;
using KARYA.MODEL.Entities.Karya;
using SAHIZA.WEB.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KARYA.COMMON.Attributes;
using SAHIZA.MODEL.Module;

namespace SAHIZA.WEB.MVC.Controllers
{
    public class AuthorizeTreeNode
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }

    }

    [KaryaAuthorize(Role = SahizaRole.AdminPanel)]
    public class AdminController : Controller
    {
        IUserManager _userManager;
        IAuthorizeGroupManager _authorizeGroupManager;

        public AdminController(IUserManager userManager, IAuthorizeGroupManager authorizeGroupManager)
        {
            _userManager = userManager;
            _authorizeGroupManager = authorizeGroupManager;
        }

        [KaryaAuthorize(Role = SahizaRole.UserControl)]
        public async Task<IActionResult> UserList()
        {
            var result = await _userManager.GetAll();

            if (result.Success)
                return View(result.Data);
            else
                return View();
        }
        
        [HttpGet]
        [KaryaAuthorize(Role = SahizaRole.UserControl)]
        public async Task<IActionResult> EditUser(int Id = 0)
        {
            var authorizeGrupsResult = await _authorizeGroupManager.GetAll();
            if (authorizeGrupsResult.Success)
            {
                ViewBag.AuthorizeGroupList = new SelectList(authorizeGrupsResult.Data.ToList(), "Id", "Name");
            }
            else {
                return View("error");
            } 
            if (Id == 0)
            {
                return View(new UserModel());
            }
            else
            {
                var result = await _userManager.GetByIdWithAuthorizeGrups(Id);

                if (result.Success)
                {
                    //result.Data.UserAuthorizeGroups.ToList().Add(new UserAuthorizeGroup { Id = 1, AuthorizeGroupId = 1, UserId = 1 });
                    return View(result.Data);
                }
                else
                    return View();
            }
        }

        [HttpPost]
        [KaryaAuthorize(Role = SahizaRole.UserUpdate)]
        public async Task<IActionResult> EditUser(UserModel user)
        {
            var result = await _userManager.AddUpdateComplex(user);
            if (result.Success)
            {
                return RedirectToAction("UserList");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> AuthorizeList()
        {
            var result = await _authorizeGroupManager.GetAll();

            if (result.Success)
                return View(result.Data);
            else
                return View();
        }

        [HttpGet]
        [KaryaAuthorize(Role = SahizaRole.AuthorizeModul)]
        public async Task<IActionResult> EditAuthorize(int Id = 0)
        {
            

            if (Id == 0)
            {
                var authorizeTree = new List<dynamic>();
                var modules = new SahizaModules();

                foreach (var item in modules.ModuleList)
                {
                    authorizeTree.Add(new
                    {
                        id = item.Id.ToString(),
                        parent = item.ParentId == 0 ? "#" : item.ParentId.ToString(),
                        text = item.Name,
                        state = new { selected = false }
                    });
                }


                ViewBag.Json = JsonConvert.SerializeObject(authorizeTree);

                return View(new AuthorizeGroupDto());
            }
            else
            {
                var result = await _authorizeGroupManager.GetWithDetail(Id);

                if (result.Success)
                {
                    var authorizeTree = new List<dynamic>();
                    var modules = new SahizaModules();

                    foreach (var item in modules.ModuleList)
                    {
                        var vv = result.Data.AuthorizeGroupDetails.Any(x => x.AppModuleId == item.Id && x.IsAuthorize == true);
                        authorizeTree.Add(new { id = item.Id.ToString(), parent = item.ParentId == 0 ? "#" : item.ParentId.ToString(), 
                            text = item.Name, 
                            state = new { selected = result.Data.AuthorizeGroupDetails.Any(x=>x.AppModuleId==item.Id && x.IsAuthorize==true), } });
                    }


                    ViewBag.Json = JsonConvert.SerializeObject(authorizeTree);

                    return View(result.Data);
                }
                else
                    return View();
            }
        }

        [HttpPost]
        [KaryaAuthorize(Role = SahizaRole.AuthorizeEdit)]
        public async Task<IActionResult> EditAuthorize(AuthorizeGroupDto authorizeGroup)
        {
            
        
            var reult = await _authorizeGroupManager.AddUpdateComplex(authorizeGroup);
            if (reult.Success)
            {
                return RedirectToAction("AuthorizeList");
            }
            else
            {
                return View();
            }
        }
    }
}
