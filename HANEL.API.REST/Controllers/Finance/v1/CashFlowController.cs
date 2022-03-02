using HANEL.API.REST.Models.CashFlow;
using HANEL.BUSINESS.Abstract.Finance;
using HANEL.MODEL.Filter.Finance;
using HANEL.MODEL.Module;
using KARYA.COMMON.Attributes;
using KARYA.CORE.API.Controllers;
using KARYA.MODEL.Authorize.Karya;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers.Finance.v1
{
    [Route("api/v1/Finance/cashflow")]
    public class CashFlowController : BaseController
    {
        INakitAkisManager _nakitAkisManager;
        public CashFlowController(INakitAkisManager nakitAkisManager)
        {
            _nakitAkisManager = nakitAkisManager;
        }

        [HttpGet("GetList")]
        [KaryaAuthorize(Role = HanelRole.CashFlow)]
        public async Task<IActionResult> GetList([FromQuery]CashFlowListFilter filter)
        {
            if (filter.SectorName == "ges")
                if (!User.IsInRole(HanelRole.CashFlowGes.ToString()))
                    return Forbid();

            if (filter.SectorName == "hotel")
                if (!User.IsInRole(HanelRole.CashFlowHotel.ToString()))
                    return Forbid();

            if (filter.SectorName == "insaat")
                if (!User.IsInRole(HanelRole.CashFlowConstruction.ToString()))
                    return Forbid();

            var cashFlowFilterModel = new CashFlowFilterModel
            {
                Year = filter.Year,
                CurrencyCode = filter.CurrencyCode,
                SectorName = filter.SectorName,
                Date1 = filter.Date1,
                Date2 = filter.Date2
            };

            var resultData = await _nakitAkisManager.List(cashFlowFilterModel);

            if (resultData.Success)
                return Ok(resultData.Data);
            else
                return BadRequest();
            
        }

       

        [HttpGet("GetDetail")]
        [KaryaAuthorize(Role = HanelRole.CashFlow)]
        public async Task<IActionResult> GetDetail([FromQuery] CashFlowDetailFilter filter)
        {
            if (filter.SectorName == "ges")
                if (!User.IsInRole(HanelRole.CashFlowDetailGes.ToString()))
                    return Forbid();


            if (filter.SectorName == "otel")
                if (!User.IsInRole(HanelRole.CashFlowDetailHotel.ToString()))
                    return Forbid();

            if (filter.SectorName == "insaat")
                if (!User.IsInRole(HanelRole.CashFlowDetailConstruction.ToString()))
                    return Forbid();


            var cashFlowFilterModel = new CashFlowFilterModel
            {
                CurrencyCode = filter.CurrencyCode,
                SectorName = filter.SectorName,
                Month=filter.Month,
                RefCode=filter.RefCode,
                Year=filter.Year,
                Date1=filter.Date1,
                Date2=filter.Date2
            };

            var resultData = await _nakitAkisManager.ListDetail(cashFlowFilterModel);

            if (resultData.Success)
                return Ok(resultData.Data);
            else
                return BadRequest();

        }

        
    }
}
