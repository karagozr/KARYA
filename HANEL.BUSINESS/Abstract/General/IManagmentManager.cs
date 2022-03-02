using HANEL.MODEL.Dto.General;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Dtos.Erp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.General
{
    public interface IManagmentManager
    {
        Task<IDataResult<IEnumerable<SubeDto>>> ListBranch(string vkn = null);
        Task<IDataResult<IEnumerable<SubeDto>>> ListCompany(string vkn = null);
        Task<IDataResult<IEnumerable<ProjeDto>>> ListProjects(string projectCode = null);
        Task<IDataResult<IEnumerable<StockCodeDto>>> ListStokGrupCode1List();
        Task<IDataResult<IEnumerable<StockCodeDto>>> ListStokCode1List();
        Task<IDataResult<IEnumerable<StockAccountDetailCodeDto>>> ListMuhDetailCodes();
    }
}
