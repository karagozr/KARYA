using HANEL.MODEL.Dtos.Construction.Report;
using HANEL.MODEL.Filter.Construction;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Construction.Report
{
    public interface IConstructionActivityReport
    {
        Task<IDataResult<IEnumerable<ActivityReportDto>>> GetActivityReport(ActivityReportFilterModel activityReportFilterModel);
        Task<IDataResult<IEnumerable<ActivityReportDetailDto>>> GetActivityReportDetail(ActivityReportDetailFilterModel activityReportDetailFilterModel);
    }
}
