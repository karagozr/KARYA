using Microsoft.AspNetCore.Mvc;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.MODEL.Dtos;
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
        public async Task<IActionResult> List()
        {
            var result = await _servisManager.List(new ServisFiltreDto { Tarih1=DateTime.Now.AddMonths(-1)});
            if (result.Success)
                return View(result.Data);
            else
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> List(ServisFiltreDto servisFiltreDto)
        {
            var result = await _servisManager.List(servisFiltreDto);
            if (result.Success)
                return View(result.Data);
            else
                return View();
        }

        [HttpGet]
        public IActionResult Bakim(int id=0)
        {
            if (id == 0)
                return View(new ServisDto());
            else
                return View(new ServisDto());
        }

        [HttpPost]
        public IActionResult Bakim(ServisDto servisDto)
        {
            return View(new ServisFiltreDto());
        }
    }
}
