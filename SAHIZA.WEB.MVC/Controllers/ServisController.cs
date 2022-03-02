using KARYA.COMMON.Attributes;
using Microsoft.AspNetCore.Mvc;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Enums;
using SAHIZA.MODEL.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAHIZA.WEB.MVC.Controllers
{
    public class ServisController : Controller
    {
        IServisManager _servisManager;
        public ServisController(IServisManager servisManager)
        {
            _servisManager = servisManager;
        }

        [HttpGet]
        [KaryaAuthorize(Role = SahizaRole.ServisModule)]
        public async Task<IActionResult> List()
        {
            var result = await _servisManager.List(new ServisFiltreDto { Tarih1=DateTime.Now.AddMonths(-1)});
            if (result.Success)
                return View(result.Data);
            else
                return View();
        }

        [HttpPost]
        [KaryaAuthorize(Role = SahizaRole.ServisModule)]
        public async Task<IActionResult> List(ServisFiltreDto servisFiltreDto)
        {
            var result = await _servisManager.List(servisFiltreDto);
            if (result.Success)
                return View(result.Data);
            else
                return View();
        }

       

        [HttpGet]
        [KaryaAuthorize(Role = SahizaRole.ServisModule)]
        public async Task<IActionResult> Bakim(int id=0, ServisIslemTur servisIslemTur=0)
        {
            if (id == 0 && servisIslemTur!=0)
                return View(new ServisDto {
                    CreatedTime=DateTime.Now,
                    ServisIslemTur=servisIslemTur
                });
            else
            {
                var result = await _servisManager.GetBakimById(id);
                return View(result.Data);
            }
        }

        [HttpPost]
        [KaryaAuthorize(Role = SahizaRole.ServisUpdate)]
        public async Task<IActionResult> Bakim(ServisDto servisDto)
        {
            var result = await _servisManager.AddUpdateBakim(servisDto);
            if (result.Success)
                return RedirectToAction("List");
            else
                return View(servisDto);
        }
    }
}
