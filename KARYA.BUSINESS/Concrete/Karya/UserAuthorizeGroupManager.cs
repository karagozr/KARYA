using KARYA.BUSINESS.Abstract.Karya;
using KARYA.BUSINESS.Concrete.Base;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract.User;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Karya
{
    public class UserAuthorizeGroupManager : BaseManager<UserAuthorizeGroup>, IUserAuthorizeGroupManager
    {
        IUserAuthorizeGroupDal _userAuthorizeGroupDal;
        public UserAuthorizeGroupManager(IUserAuthorizeGroupDal userAuthorizeGroupDal) : base(userAuthorizeGroupDal) => _userAuthorizeGroupDal = userAuthorizeGroupDal;

        public async Task<IDataResult<IEnumerable<UserAuthorizeGroup>>> GetUserAuthorizeGroup(int userId)
        {

            try
            {
                var result = await _userAuthorizeGroupDal.List(x => x.UserId == userId);
                return new SuccessDataResult<IEnumerable<UserAuthorizeGroup>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<UserAuthorizeGroup>>(null, ex.Message);
            }

        }
    }
}
