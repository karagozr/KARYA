using HANEL.BUSINESS.Abstract.Finance;
using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers
{
    public class CashFlowController : BaseController
    {
        INakitAkisManager _nakitAkisManager;
        public CashFlowController(INakitAkisManager nakitAkisManager)
        {
            _nakitAkisManager = nakitAkisManager;
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var resultData = await _nakitAkisManager.List();

            if (resultData.Success)
            {
                return Ok(resultData.Data);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
