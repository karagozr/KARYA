using Microsoft.AspNetCore.Mvc;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SAHIZA.WEB.MVC.Controllers
{
    public class BelgeController : Controller
    {
        IBelgeManager _belgeManager;
        IDizaynManager _dizaynManager;

        public BelgeController(IBelgeManager belgeManager, IDizaynManager dizaynManager)
        {
            _belgeManager = belgeManager;
            _dizaynManager = dizaynManager;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _belgeManager.GetAll();
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                return View(new List<Belge>());
            }
            
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id=0, int dizaynId=0)
        {
            if (id == 0 && dizaynId>0)
            {
                var dizaynTemplate = await _dizaynManager.GetByIdForNewBelge(dizaynId);
                return View(dizaynTemplate.Data);
            }
            else if(id> 0 && dizaynId == 0)
            {
                var belge = await _belgeManager.GetByIdWithDetay(id);
                return View(belge.Data);
            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Show(int id = 0)
        {
            var belge = await _belgeManager.GetByIdWithDetay(id);
            if (belge.Success)
            {
                return View(belge.Data);
            }
            else
            {
                return View(new List<DizaynBelgeDto>());
            }

        }


        [HttpPost]
        public async Task<IActionResult> Edit(DizaynBelgeDto dizaynBelgeDto)
        {
            var reult = await _belgeManager.AddUpdateComplex(dizaynBelgeDto);
            if (reult.Success)
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
