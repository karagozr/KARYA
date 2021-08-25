
using KARYA.COMMON.Attributes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using SAHIZA.MODEL.Enums;
using SAHIZA.MODEL.Module;
using System;
using System.Threading.Tasks;

namespace SAHIZA.WEB.MVC.Controllers
{
    public class StokHaraketController : Controller
    {
        IStokHaraketManager _stokHaraketManager;
        public StokHaraketController(IStokHaraketManager stokHaraketManager)
        {
            _stokHaraketManager = stokHaraketManager;
            
        }

        [KaryaAuthorize(RoleEnum = SahizaRole.StokHaraketModule)]
        public async Task<IActionResult> List()
        {
            var result = await _stokHaraketManager.GetAll();


            if (result.Success)
                return View(result.Data);
            else 
                return View();

        }
        [HttpGet]
        [KaryaAuthorize(RoleEnum = SahizaRole.StokHaraketModule)]
        public async Task<IActionResult> EditHaraket(StokHaraketTur stokHaraketTur, int Id=0)
        {

            if (Id == 0)
            {
                return View(new StokHaraketDto { StokHaraketTur=stokHaraketTur});
            }
            else
            {
                var result = await _stokHaraketManager.GetById(Id);
                
                if (result.Success)
                {
                    return View(result.Data);
                }
                else
                    return View();
            }
            
        }
        [HttpPost]
        [KaryaAuthorize(RoleEnum = SahizaRole.StokHaraketUpdate)]
        public async Task<IActionResult> EditHaraket(StokHaraket stokHaraket)
        {

            var result = await _stokHaraketManager.AddUpdate(stokHaraket);
            if (result.Success)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
            
        }
    }
}
