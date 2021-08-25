using HANEL.MODEL.Common.PlReport;
using HANEL.MODEL.Dtos.Finance;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.PlReport
{
    public interface IPlReportManager
    {
        Task<IDataResult<IEnumerable<ActualRawData>>> GetRawData(PlReportFilterModel plReportFilterModel);
        Task<IDataResult<HANEL.MODEL.Dtos.Finance.PlReport>> GetReport(PlReportFilterModel plReportFilterModel);

        Task<IDataResult<IEnumerable<PlReportWithDetail>>> GetReportWithDetails(PlReportFilterModel plReportFilterModel);

        Task<IDataResult<IEnumerable<ProjectsForPlReportFilter>>> GetProjectsForReportFilter();

        Task<IDataResult<IEnumerable<PlReportDetailForBudgetOrCost>>> GetReportValuesDetails(PlReportFilterModel plReportFilterModel);
    }
}
