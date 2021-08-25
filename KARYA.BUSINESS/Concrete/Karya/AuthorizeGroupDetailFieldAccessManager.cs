using KARYA.BUSINESS.Abstract.Karya;
using KARYA.BUSINESS.Concrete.Base;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract.Authorize;
using KARYA.MODEL.DataTransferModels.Karya.Finance.Admin;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Karya
{
    public class AuthorizeGroupDetailFieldAccessManager : BaseManager<AuthorizeGroupDetailFieldAccess>, IAuthorizeGroupDetailFieldAccessManager
    {
        IAuthorizeGroupDetailFieldAccessDal  _groupDetailFieldAccessDal;
        public AuthorizeGroupDetailFieldAccessManager(IAuthorizeGroupDetailFieldAccessDal groupDetailFieldAccessDal) : base(groupDetailFieldAccessDal) => _groupDetailFieldAccessDal = groupDetailFieldAccessDal;

        public async Task<IDataResult<IEnumerable<AuthorizeGroupDetailFieldAccess>>> GetUserFieldAccess(int userId)
        {
            try
            {
                var result = await _groupDetailFieldAccessDal.List(x => x.AuthorizeGroupDetail.AuthorizeGroup.UserAuthorizeGroups.Where(w => w.UserId == userId).Any());

                return new SuccessDataResult<IEnumerable<AuthorizeGroupDetailFieldAccess>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<AuthorizeGroupDetailFieldAccess>>(null, ex.Message);
            }

        }


        public async Task<IResult> AddUpdateList(IEnumerable<AuthorizeGrupDetailFilterModel> authorizeGrupDetailFilterModels)
        {
            try
            {
                var authorizeGrupDetailFilters = new List<AuthorizeGroupDetailFieldAccess>();

                foreach (var item in authorizeGrupDetailFilterModels)
                {
                    authorizeGrupDetailFilters.Add(new AuthorizeGroupDetailFieldAccess
                    {
                        Id = item.Id,
                        AuthorizeGroupDetailId = item.AuthorizeGrupDetailId,
                        BudgetsubCode = item.BudgetsubCode,
                        ProjectCode = item.ProjectCode,
                        Read = item.Read,
                        Write = item.Write,
                        Delete = item.Delete
                    });
                }

                _groupDetailFieldAccessDal.AddUpdate(authorizeGrupDetailFilters);


                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
