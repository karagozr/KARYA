using KARYA.COMMON.Attributes;
using KARYA.MODEL.Authorize.SahizaWorld;
using KARYA.MODEL.Enums.SahizaWorld;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using SAHIZA.MODEL.Module;
using SAHIZA.WEB.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAHIZA.WEB.MVC.Controllers
{
    public class StokController : Controller
    {
        IStokManager _stokManager;
        public StokController(IStokManager stokManager)
        {
            _stokManager = stokManager;
           
        }

        [KaryaAuthorize(RoleEnum = SahizaRole.StokModule)]
        public async Task<IActionResult> List()
        {
            var result = await _stokManager.GetAll();

            if (result.Success)
                return View(result.Data);
            else 
                return View();

        }
        
        [HttpGet]
        [KaryaAuthorize(RoleEnum = SahizaRole.StokModule)]
        public async Task<IActionResult> EditStok(int Id=0)
        {
            if (Id == 0)
            {
                return View(new Stok());
            }
            else
            {
                var result = await _stokManager.GetById(Id);
                
                if (result.Success)
                {
                    return View(result.Data);
                }
                else
                    return View();
            }
            
        }
        
        [HttpPost]
        [KaryaAuthorize(RoleEnum = SahizaRole.StokUpdate)]
        public async Task<IActionResult> EditStok(Stok stok)
        {

            var reult = await _stokManager.AddUpdate(stok);
            if (reult.Success)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        [KaryaAuthorize(RoleEnum = SahizaRole.StokModule)]
        public async Task<IEnumerable<dynamic>> ContactList()
        {
            var result = await _stokManager.GetAll();
            if (result.Success)
            {
                return result.Data;
            }
            else
            {
                return null;
            }

        }
    }
}
