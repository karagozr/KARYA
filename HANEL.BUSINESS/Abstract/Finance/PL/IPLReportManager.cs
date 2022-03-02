using HANEL.MODEL.Common.PlReport;
using HANEL.MODEL.Dtos.Finance.PL;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance.PL
{
    public interface IPLReportManager
    {
        Task<IDataResult<IEnumerable<PlReportDto>>> GetPL(PlReportFilterModel plReportFilterModel);
        Task<IDataResult<IEnumerable<PlReportDetailDto>>> GetPLDetail(PlReportFilterModel plReportFilterModel);
    }
}
