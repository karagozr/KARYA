using KARYA.BUSINESS.Abstract.Base;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.DataTransferModels.Karya.Finance.Admin;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Karya
{
    public interface IAuthorizeGroupDetailFieldAccessManager : IBaseManager<AuthorizeGroupDetailFieldAccess>
    {
        Task<IDataResult<IEnumerable<AuthorizeGroupDetailFieldAccess>>> GetUserFieldAccess(int userId);

        Task<IResult> AddUpdateList(IEnumerable<AuthorizeGrupDetailFilterModel> authorizeGrupDetailFilterModels);


    }
}
