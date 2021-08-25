using HANEL.BUSINESS.Abstract.Finance;
using HANEL.MODEL.DataTransferModels.Finance;
using HANEL.MODEL.Entities.Finance;
using HANEL.MODEL.Enums;
using HANEL.MODEL.Module;
using KARYA.BUSINESS.Abstract.Karya;
using KARYA.COMMON.Attributes;
using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers
{
    public class BudgetController : BaseController
    {
        IActualCostManager _actualCostManager;
        IBudgetManager _budgetManager;
        IBudgetDetailManager _budgetDetailManager;
        IBudgetActualCostManager _budgetActualCostManager;
        IBudgetExchangeRateManager _budgetExchangeRateManager;
        IAuthorizeGroupDetailFieldAccessManager _groupDetailFieldAccessManager;
        public BudgetController(IActualCostManager actualCostManager, IBudgetManager budgetManager, 
            IBudgetDetailManager budgetDetailManager, IBudgetCodeNameManager budgetCodeNameManager,
            IBudgetActualCostManager budgetActualCostManager, IBudgetExchangeRateManager budgetExchangeRateManager,
            IAuthorizeGroupDetailFieldAccessManager groupDetailFieldAccessManager)
        {
            _budgetManager = budgetManager;
            _budgetDetailManager = budgetDetailManager;
            _actualCostManager = actualCostManager;
            _budgetActualCostManager = budgetActualCostManager;
            _budgetExchangeRateManager = budgetExchangeRateManager;
            _groupDetailFieldAccessManager = groupDetailFieldAccessManager;
        }

        [HttpGet("GetActualForBudget")]
        public async Task<IActionResult> GetActualCostForProject(string projectCode, short year, string currency)
        {
            var resultData = await _actualCostManager.GetActualCostWithMonths(projectCode, year, currency);

            if (resultData.Success)
            {
                return Ok(resultData.Data);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("GetProjectBudgetList")]
        [KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> GetProjectBudgetListWithStatus(short budgetYear)
        {
            var resultDataProjectBudget = await _budgetActualCostManager.GetProjectsBudgetListWithStatus(budgetYear);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok(resultDataProjectBudget.Data);
        }

        [HttpGet("GetBudgetsWithActual")]
        //[KaryaAuthorize(RoleEnum = AppModuleRole.BudgetEntry)]
        public async Task<IActionResult> GetBudgetwithMonths(string projectCode, short budgetYear, short actualYear, string currencyCode, bool isReport=false)
        {
            //var resultDataActual = await _actualCostManager.GetActualCostWithMonths(projectCode, actualYear, currency);
            //if (!resultDataActual.Success) return BadRequest(resultDataActual.Message);
            //var actualData = resultDataActual.Data.ToList();

            //var budgetCodesresultData = await _budgetCodeNameManager.List();
            //if (!budgetCodesresultData.Success) return BadRequest(budgetCodesresultData.Message);
            //var budgetCodes = budgetCodesresultData.Data;
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //var identity = 1;
            var resultDataUserAccesField = await _groupDetailFieldAccessManager.GetUserFieldAccess(Convert.ToInt32(userId));
            if (!resultDataUserAccesField.Success) return BadRequest(resultDataUserAccesField.Message);

            var resultDataExchanceRate = await _budgetExchangeRateManager.GetExchangeForecastForYear(budgetYear);
            if (!resultDataExchanceRate.Success) return BadRequest(resultDataExchanceRate.Message);

            var resultDataBudget = await _budgetActualCostManager.GetActualBudgetCostWithMonths(projectCode, budgetYear, actualYear, currencyCode);
            if (!resultDataBudget.Success) return BadRequest(resultDataBudget.Message);
            var filterData = isReport == false ? resultDataUserAccesField.Data.Where(y => y.ProjectCode == projectCode && y.Write == true) :
                resultDataUserAccesField.Data.Where(y => y.ProjectCode == projectCode && y.Read == true);

            var budgetData = resultDataBudget.Data;//.Where(x => filterData.Select(y => y.BudgetsubCode).Contains(x.BudgetSubCode));
            var currencyRates = resultDataExchanceRate.Data;
            //var resultDataBudgetSubDetail = await _budgetSubDetailManager.Select(budgetData.Select(x => x.Id));
            //if (!resultDataBudgetSubDetail.Success) return BadRequest(resultDataBudget.Message);
            //var budgetDataSubDetail = resultDataBudgetSubDetail.Data;

            return Ok(new { budgetData, currencyRates });
        }

        [HttpPost("SaveBudgetList")]
        [KaryaAuthorize(RoleEnum = HanelRole.BudgetEntryEdit)]
        public async Task<IActionResult> SaveBudgetForProject(SaveBudgetModel saveBudgetModel)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //var identity = 1;
            var resultDataUserAccesField = await _groupDetailFieldAccessManager.GetUserFieldAccess(Convert.ToInt32(userId));
            if (!resultDataUserAccesField.Success) return BadRequest(resultDataUserAccesField.Message);

            var projectCode = saveBudgetModel.ProjectCode;
            var bugdetList = saveBudgetModel.BugdetList;//.Where(x=>resultDataUserAccesField.Data.Where(y=>y.Write==true&&y.ProjectCode== projectCode).Select(z=>z.BudgetsubCode).Contains(x.BudgetSubCode));
            short year = saveBudgetModel.BudgetYear;

            foreach (var item in bugdetList)
            {
                BudgetType budgetType = BudgetType.ExpenditureBudget;
                if(item.BudgetMainCode=="K01") budgetType = BudgetType.InterestBudget;
                else if (item.BudgetMainCode == "G00") budgetType = BudgetType.IncomeBudget;
                else if (string.IsNullOrEmpty(item.BudgetMainCode)) budgetType = BudgetType.CreditBudget;

                var budget = new Budget
                {
                    SiteCode = item.SiteCode,
                    BudgetType = budgetType,
                    ProjectCode = projectCode,
                    BranchCode = item.BranchCode,
                    BudgetMainCode = item.BudgetMainCode,
                    BudgetSubCode = item.BudgetSubCode,
                    Description1 = item.Description1,
                    Description2 = item.Description2,
                    Description3 = item.Description3,
                    BudgetYear = year,
                    Enable = true,
                    BudgetTaxMultiplier = 1,
                    DescriptionDetail=item.DescriptionDetail
                };
                if (item.Id > 0) budget.Id = item.Id;

                //Buçede kalem var mı?
                if(!(item.BudgetOcak > 0 || item.BudgetSubat > 0 || item.BudgetMart > 0 || item.BudgetNisan > 0 || item.BudgetMayis > 0 || item.BudgetHaziran > 0 || item.BudgetTemmuz > 0 || item.BudgetAgustos > 0 || item.BudgetEylul > 0 || item.BudgetEkim > 0 || item.BudgetKasim > 0 || item.BudgetAralik > 0)) continue;

                var res = item.Id <= 0 ? await _budgetManager.Add(budget) : await _budgetManager.Update(budget);

                if (!res.Success) return BadRequest();

                int id = _budgetManager.ScopeIdentity();

                var budgetDetailList = new List<BudgetDetail>()
                {
                    new BudgetDetail
                    {
                        Id = item.BudgetOcakId,
                        PeriodDate = new DateTime(year, 1, 1),
                        BudgetId =id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=1,
                        Amount=item.BudgetOcak,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetSubatId,
                        PeriodDate=new DateTime(year, 2, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=2,
                        Amount=item.BudgetSubat,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetMartId,
                        PeriodDate=new DateTime(year, 3, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=3,
                        Amount=item.BudgetMart,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetNisanId,
                        PeriodDate=new DateTime(year, 4, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=4,
                        Amount=item.BudgetNisan,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetMayisId,
                        PeriodDate=new DateTime(year, 5, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=5,
                        Amount=item.BudgetMayis,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetHaziranId,
                        PeriodDate=new DateTime(year, 6, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=6,
                        Amount=item.BudgetHaziran,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetTemmuzId,
                        PeriodDate=new DateTime(year, 7, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=7,
                        Amount=item.BudgetTemmuz,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetAgustosId,
                        PeriodDate=new DateTime(year, 8, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=8,
                        Amount=item.BudgetAgustos,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetEylulId,
                        PeriodDate=new DateTime(year, 9, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=9,
                        Amount=item.BudgetEylul,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetEkimId,
                        PeriodDate=new DateTime(year, 10, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=10,
                        Amount=item.BudgetEkim,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetKasimId,
                        PeriodDate=new DateTime(year, 11, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=11,
                        Amount=item.BudgetKasim,
                        CurrencyCode=item.BudgetCurrencyCode
                    },
                    new BudgetDetail
                    {
                        Id=item.BudgetAralikId,
                        PeriodDate=new DateTime(year, 12, 1),
                        BudgetId=id,
                        Enable=true,
                        BudgetYear=year,
                        BudgetMonth=12,
                        Amount=item.BudgetAralik,
                        CurrencyCode=item.BudgetCurrencyCode
                    }
                };

                var resDet = await _budgetDetailManager.Add(budgetDetailList.Where(x => x.Id <= 0).Select(x=>new BudgetDetail { PeriodDate=x.PeriodDate, BudgetId=x.BudgetId, Enable=x.Enable, BudgetYear=x.BudgetYear, 
                    BudgetMonth=x.BudgetMonth,
                    Amount=x.Amount,CurrencyCode=x.CurrencyCode}));
                resDet = await _budgetDetailManager.Update(budgetDetailList.Where(x => x.Id > 0));

                if (!resDet.Success) return BadRequest();
            }

            return Ok();
        }



    }
}
