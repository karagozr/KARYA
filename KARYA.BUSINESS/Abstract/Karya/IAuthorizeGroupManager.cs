using KARYA.BUSINESS.Abstract.Base;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.DataTransferModels.Karya.Finance.Admin;
using KARYA.MODEL.Dtos.Karya;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Karya
{
    public interface IAuthorizeGroupManager : IBaseManager<AuthorizeGroup>
    {
        Task<IDataResult<AuthorizeGroupDto>> GetWithDetail(int Id);
        Task<IResult> Add(AuthorizeGrupModel authorizeGrupModel);
        Task<IResult> Update(AuthorizeGrupModel authorizeGrupModel);
        Task<IResult> AddUpdateComplex(AuthorizeGroupDto authorizeGrupModel);

    }
}
