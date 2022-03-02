using HANEL.BUSINESS.Abstract.Finance.Budgets;
using HANEL.MODEL.Dtos.Finance.Budget;
using HANEL.MODEL.Filter.Finance;
using KARYA.CORE.API.Controllers;
using KARYA.CORE.Types.Return.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers.Finance.v2
{
    [Route("api/v2/Finance/budget")]
    public class BudgetController : BaseController
    {
        IBudgetReportManager _budgetReportManager;
        IBudgetManager _budgetManager;
        IBudgetExchangeRateManager _budgetExchangeRateManager;
        //IBudgetActualCostManager _budgetActualCostManager;
        //IBudgetExchangeRateManager _budgetExchangeRateManager;
        //IAuthorizeGroupDetailFieldAccessManager _groupDetailFieldAccessManager;

        public BudgetController(IBudgetReportManager budgetReportManager, IBudgetManager budgetManager, IBudgetExchangeRateManager budgetExchangeRateManager)
        {
            _budgetReportManager = budgetReportManager;
            _budgetManager = budgetManager;
            _budgetExchangeRateManager = budgetExchangeRateManager;
        }

        [HttpGet("GetProjectBudgetList")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> GetProjectBudgetListWithStatus([FromQuery]BudgetReportFilterModel filter)
        {
            var resultDataProjectBudget = await _budgetReportManager.GetProjectBudgetListWithStatus(filter);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok(resultDataProjectBudget.Data);
        }

        [HttpGet("GetBudgetReport")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> GetBudgetReport([FromQuery] BudgetReportFilterModel filter)
        {
            var resultDataProjectBudget = await _budgetReportManager.GetProjectBudgetListWithStatus(filter);
            var tasks = new List<Task<IDataResult<IEnumerable<BudgetReportWithLastDto>>>>();

            foreach (var item in resultDataProjectBudget.Data)
            {
                var _filter = filter;
                _filter.ProjectCode = item.ProjectCode;
                var task = _budgetReportManager.GetProjectBudgetReport(filter);
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            List<BudgetReportWithLastDto> resultData = new List<BudgetReportWithLastDto>();

            foreach (var item in tasks)
            {
                resultData.AddRange(item.Result.Data);
            }

            return Ok(resultData);
        }

        [HttpGet("GetProjectBudgetReport")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> GetProjectBudgetReport([FromQuery] BudgetReportFilterModel filter)
        {
            var resultDataProjectBudget = await _budgetReportManager.GetProjectBudgetReport(filter);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok(resultDataProjectBudget.Data);
        }


        [HttpPost("AddBudgetList")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> AddBudgetList(IEnumerable<BudgetAddDto> budgets)
        {
            var resultDataProjectBudget = await _budgetManager.AddBudget(budgets);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok();
        }

        [HttpPost("EditBudgetList")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> EditBudgetList(IEnumerable<BudgetEditDto> budgets)
        {
            var resultDataProjectBudget = await _budgetManager.EditBudget(budgets);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok();
        }


        [HttpGet("GetBudgetDetail")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> GetBudgetDetail([FromQuery] BudgetReportFilterModel filter)
        {
            var resultDataProjectBudget = await _budgetReportManager.GetBudgetDetail(filter);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok(resultDataProjectBudget.Data);
        }

        [HttpPost("EditBudgetDetail")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> EditBudgetDetail(IEnumerable<BudgetEditDto> budgets)
        {
            var resultDataProjectBudget = await _budgetManager.EditBudgetDetail(budgets);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok();
        }

        [HttpGet("GetBudgetDetailOfProject")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> GetBudgetDetailOfProject([FromQuery] BudgetReportFilterModel filter)
        {
            var resultDataProjectBudget = await _budgetReportManager.GetBudgetDetailOfProject(filter);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok(resultDataProjectBudget.Data);
        }

        [HttpGet("GetExchangeRates")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> GetExchangeRates([FromQuery] BudgetExchangeRateFilterModel filter)
        {
            var result = await _budgetExchangeRateManager.List(filter);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpPost("EditExchangeRates")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> EditExchangeRates(IEnumerable<BudgetExchangeRateDto> rates)
        {
            var result = await _budgetExchangeRateManager.Edit(rates);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("GetExchangeRatesMontly")]
        //[KaryaAuthorize(RoleEnum = HanelRole.BudgetModule)]
        public async Task<IActionResult> GetExchangeRatesMontly([FromQuery] BudgetExchangeRateFilterModel filter)
        {
            var result = await _budgetExchangeRateManager.ListMonthly(filter);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Data);
        }

    }
}
