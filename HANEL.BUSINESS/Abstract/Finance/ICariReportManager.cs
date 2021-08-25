using HANEL.MODEL.Common.Finance;
using HANEL.MODEL.Dtos.CariReport;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance
{
    public interface ICariReportManager
    {
        Task<IDataResult<IEnumerable<CariReportTitle>>> GetCariReportTitles();

        Task<IDataResult<IEnumerable<CariReportSubGroup>>> GetCariReportSubGroup(CariReportFilterModel cariReportFilterModel);

        Task<IDataResult<IEnumerable<CariReportSubGroupDetail>>> GetCariReportSubGroupDetail(CariReportFilterModel cariReportFilterModel);

        Task<IDataResult<IEnumerable<CariReportSubGroupDetail>>> GetCariReportSubGroupDetailFromFisNo(CariReportFilterModel cariReportFilterModel);
    }
}

