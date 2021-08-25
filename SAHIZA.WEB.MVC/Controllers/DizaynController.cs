using KARYA.COMMON.Attributes;
using Microsoft.AspNetCore.Mvc;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using SAHIZA.MODEL.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAHIZA.WEB.MVC.Controllers
{
    public class DizaynController : Controller
    {
        IDizaynManager _dizaynManager;
        public DizaynController(IDizaynManager dizaynManager)
        {
            _dizaynManager = dizaynManager;
        }

        [HttpGet]
        [KaryaAuthorize(RoleEnum = SahizaRole.DizaynModule)]
        public async Task<IActionResult> List()
        {
            var result = await _dizaynManager.GetAll();

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
        [KaryaAuthorize(RoleEnum = SahizaRole.DizaynModule)]
        public async Task<IActionResult> Edit(int Id = 0)
        {

            if (Id == 0)
            {
                return View(new DizaynDto());
            }
            else
            {
                var result = await _dizaynManager.GetByIdWithDetay(Id);

                if (result.Success)
                {
                    return View(result.Data);
                }
                else
                    return View();
            }
        }

        [HttpPost]
        [KaryaAuthorize(RoleEnum = SahizaRole.DizaynUpdate)]
        public async Task<IActionResult> Edit(DizaynDto dizayn)
        {
            var reult = await _dizaynManager.AddUpdateComplex(dizayn);
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
        [KaryaAuthorize(RoleEnum = SahizaRole.DizaynModule)]
        public async Task<IEnumerable<dynamic>> DizaynList()
        {
            var result = await _dizaynManager.GetAll();
            if (result.Success)
            {
                return result.Data.Select(x => new
                {
                    Id = x.Id,
                    DizaynKodu = x.DizaynKodu,
                    DizaynAdi = x.DizaynAdi,
                    DizaynAciklama = x.Aciklama

                });
            }
            else
            {
                return null;
            }
        }
    }
}

