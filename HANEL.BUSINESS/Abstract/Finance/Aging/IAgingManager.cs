using HANEL.MODEL.Dtos.Finance.Aging;
using HANEL.MODEL.Filter.Finance;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance.Aging
{
    public interface IAgingManager
    {
        Task<IDataResult<IEnumerable<AgingReportDto>>> GetAgingList(AgingFilterModel filter);
        Task<IDataResult<IEnumerable<AgingDetailReportDto>>> GetAgingDetail(AgingFilterModel filter);
        Task<IDataResult<IEnumerable<AgingReportDto>>> GetAgingProjectDetail(AgingFilterModel filter);
        Task<IDataResult<IEnumerable<AgingReportDto>>> GetAgingBranchDetail(AgingFilterModel filter);
    }
}
