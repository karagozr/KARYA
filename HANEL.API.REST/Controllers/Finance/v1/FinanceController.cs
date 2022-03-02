using HANEL.BUSINESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance;
using HANEL.MODEL.Entities.Finance;
using HANEL.MODEL.Filter.Finance;
using HANEL.MODEL.Module;
using KARYA.COMMON.Attributes;
using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers.Finance.v1
{

    [Route("api/v1/Finance")]
    public class FinanceController : BaseController
    {
        IReportCodeManager _reportCodeManager;
        IReportCodeUserFilterManager _reportCodeUserFilterManager;
        public FinanceController(IReportCodeManager reportCodeManager, IReportCodeUserFilterManager reportCodeUserFilterManager)
        {
            _reportCodeManager = reportCodeManager;
            _reportCodeUserFilterManager = reportCodeUserFilterManager;
        }

        [HttpGet("GetReportCodeList")]
        [KaryaAuthorize(Role = HanelRole.FinanceReports)]
        public async Task<IActionResult> GetReportCodeList()
        {
            var result = await _reportCodeManager.GetEditList();

            if (result.Success) return Ok(result.Data);
            else return BadRequest(result.Message);
        }

        [HttpPost("EditReportCodeList")]
        [KaryaAuthorize(Role = HanelRole.FinanceReports)]
        public async Task<IActionResult> EditReportCodeList(IEnumerable<ReportCodeEditDto> reportCodeEditDto)
        {
            var result = await _reportCodeManager.EditList(reportCodeEditDto);

            if (result.Success) return Ok();
            else return BadRequest(result.Message);
        }


        [HttpGet("GetReportCodeUserFilterList")]
        //[KaryaAuthorize(Role = HanelRole.FinanceReports)]
        public async Task<IActionResult> GetReportCodeListForUser([FromQuery]ReportCodeUserFilterFilterModel reportCodeUserFilterFilterModel)
        {
            var result = await _reportCodeUserFilterManager.GetEditList(reportCodeUserFilterFilterModel);

            if (result.Success) return Ok(result.Data);
            else return BadRequest(result.Message);
        }

        [HttpPost("EditReportCodeUserFilterList")]
        //[KaryaAuthorize(Role = HanelRole.FinanceReports)]
        public async Task<IActionResult> EditReportCodeListForUser(IEnumerable<ReportCodeUserFilter> reportCodeUserFilters)
        {
            var result = await _reportCodeUserFilterManager.EditList(reportCodeUserFilters);



            if (result.Success) return Ok();
            else return BadRequest(result.Message);
        }

        
    }
}
