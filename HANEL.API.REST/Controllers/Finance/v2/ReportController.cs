using HANEL.BUSINESS.Abstract.Finance;
using HANEL.BUSINESS.Abstract.Finance.PL;
using HANEL.BUSINESS.Abstract.PlReport;
using HANEL.MODEL.Common.Finance;
using HANEL.MODEL.Common.PlReport;
using HANEL.MODEL.DataTransferModels.Finance;
using HANEL.MODEL.Entities.Finance;
using HANEL.MODEL.Module;
using KARYA.COMMON.Attributes;
using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers.Finance.v2
{
    [Route("api/v2/Finance/Reports")]
    public class ReportController : BaseController
    {
        IPLReportManager _plReportManager;
        public ReportController(IPLReportManager plReportManager)
        {
            _plReportManager = plReportManager; ;
        }

        [HttpPost("Getpl")]
        [KaryaAuthorize(Role = HanelRole.PLReport)]
        public async Task<IActionResult> GetPlReportValues(PlReportFilterModel plReportFilterModel)
        {
            var resultData = await _plReportManager.GetPL(plReportFilterModel);

            if (resultData.Success)
            {
                return Ok(resultData.Data);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("Getpldetail")]
        [KaryaAuthorize(Role = HanelRole.PLReport)]
        public async Task<IActionResult> GetPlReportDetailValues(PlReportFilterModel plReportFilterModel)
        {
            var resultData = await _plReportManager.GetPLDetail(plReportFilterModel);

            if (resultData.Success)
            {
                return Ok(resultData.Data);
            }
            else
            {
                return NotFound();
            }
        }



    }
}
