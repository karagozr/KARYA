using HANEL.MODEL.Dtos.Finance;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Abstract;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance
{
    public interface IReportCodeManager : IBaseManager<ReportCode>
    {
        Task<IDataResult<IEnumerable<ReportCodeEditDto>>> GetEditList();
        Task<IResult> EditList(IEnumerable<ReportCodeEditDto> reportCodeEditDto);
    }
}
