using KARYA.COMMON.Attributes;
using KARYA.MODEL.Authorize.SahizaWorld;
using Microsoft.AspNetCore.Mvc;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.MODEL.Entities;
using SAHIZA.MODEL.Module;
using SAHIZA.WEB.MVC.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAHIZA.WEB.MVC.Controllers
{

    public class CariController : Controller
    {
        ICariManager _cariManager;
        public CariController(ICariManager cariManager)
        {
            _cariManager = cariManager;
        }

        [HttpGet]
        [KaryaAuthorize(RoleEnum = SahizaRole.CariModule)]
        public async Task<IActionResult> List()
        {
            var result = await _cariManager.GetAll();

            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        [KaryaAuthorize(RoleEnum = SahizaRole.CariModule)]
        public async Task<IActionResult> EditCari(int Id=0)
        {

            if (Id == 0)
            {
                return View(new Cari());
            }
            else
            {
                var result = await _cariManager.GetById(Id);

                if (result.Success)
                {
                    return View(result.Data);
                }
                else
                    return View();
            }
        }

        [HttpPost]
        [KaryaAuthorize(RoleEnum = SahizaRole.CariUpdate)]
        public async Task<IActionResult> EditCari(Cari cari)
        {
            var reult = await _cariManager.AddUpdate(cari);
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
        [KaryaAuthorize(RoleEnum = SahizaRole.CariModule)]
        public async Task<IEnumerable<dynamic>> ContactList()
        {

            var result = await _cariManager.GetAll();
            if (result.Success)
            {
                return result.Data.Select(x => new
                {
                    Id = x.Id,
                    CariAdi = x.CariAdi,
                    CariKodu = x.CariKodu,
                    CariTip = x.CariTip.Description()

                }) ;
            }
            else
            {
                return null;
            }

        }
    }
}