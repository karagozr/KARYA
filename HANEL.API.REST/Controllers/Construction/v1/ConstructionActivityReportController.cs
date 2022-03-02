using HANEL.BUSINESS.Abstract.Construction.Report;
using HANEL.MODEL.Filter.Construction;
using HANEL.MODEL.Module;
using KARYA.COMMON.Attributes;
using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers.Construction.v1
{

    [Route("api/v1/Construction/Activity")]
    public class ConstructionActivityReportController : BaseController
    {
        IConstructionActivityReport _constructionActivityReport;
        public ConstructionActivityReportController(IConstructionActivityReport constructionActivityReport)
        {
            _constructionActivityReport = constructionActivityReport; ;
        }

        [HttpGet("GetReport")]
        [KaryaAuthorize(Role = HanelRole.ConstructionActivityReport)]
        public async Task<IActionResult> GetActivityReport([FromQuery]ActivityReportFilterModel filter)
        {
            var resultData = await _constructionActivityReport.GetActivityReport(filter);

            if (resultData.Success)
            {
                return Ok(resultData.Data);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("GetReportDetail")]
        [KaryaAuthorize(Role = HanelRole.ConstructionActivityReport)]
        public async Task<IActionResult> GetActivityReportDetail([FromQuery]ActivityReportDetailFilterModel filter)
        {
            var resultData = await _constructionActivityReport.GetActivityReportDetail(filter);

            if (resultData.Success)
            {
                return Ok(resultData.Data);
            }
            else
            {
                return NoContent();
            }
        }



    }
}
