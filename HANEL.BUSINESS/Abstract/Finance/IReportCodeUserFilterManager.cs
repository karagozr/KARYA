using HANEL.MODEL.Dtos.Finance;
using HANEL.MODEL.Entities.Finance;
using HANEL.MODEL.Filter.Finance;
using KARYA.CORE.Abstract;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance
{
    public interface IReportCodeUserFilterManager : IBaseManager<ReportCodeUserFilter>
    {
        Task<IDataResult<IEnumerable<ReportCodeUserFilterEditDto>>> GetEditList(ReportCodeUserFilterFilterModel reportCodeUserFilterFilterModel);
        Task<IResult> EditList(IEnumerable<ReportCodeUserFilter> reportCodeUserFilters);
    }
}
