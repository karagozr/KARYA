using HANEL.BUSINESS.Abstract.Finance.Aging;
using HANEL.MODEL.Filter.Finance;
using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers.Finance.v2
{
    [Route("api/v2/Finance/aging")]
    public class AgingController : BaseController
    {
        IAgingManager _agingManager;

        public AgingController(IAgingManager agingManager)
        {
            _agingManager = agingManager;
        }

  

        [HttpGet("report")]
        public async Task<IActionResult> GetAgingReport([FromQuery] AgingFilterModel filter)
        {
            //return Ok();
            var resultDataProjectBudget = await _agingManager.GetAgingList(filter);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok(resultDataProjectBudget.Data);
        }

        [HttpGet("report/branch")]
        public async Task<IActionResult> GetAgingReportBranch([FromQuery] AgingFilterModel filter)
        {
            //return Ok();
            var resultDataProjectBudget = await _agingManager.GetAgingBranchDetail(filter);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok(resultDataProjectBudget.Data);
        }

        [HttpGet("report/project")]
        public async Task<IActionResult> GetAgingReportProject([FromQuery] AgingFilterModel filter)
        {
            //return Ok();
            var resultDataProjectBudget = await _agingManager.GetAgingProjectDetail(filter);
            if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            return Ok(resultDataProjectBudget.Data);
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetAgingReportDetail([FromQuery] AgingFilterModel filter)
        {
            return Ok();
            //var resultDataProjectBudget = await _budgetReportManager.GetProjectBudgetListWithStatus(filter);
            //if (!resultDataProjectBudget.Success) return BadRequest(resultDataProjectBudget.Message);

            //return Ok(resultDataProjectBudget.Data);
        }
    }
}
