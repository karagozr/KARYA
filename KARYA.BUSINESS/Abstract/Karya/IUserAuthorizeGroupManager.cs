using KARYA.BUSINESS.Abstract.Base;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Karya
{
    public interface IUserAuthorizeGroupManager : IBaseManager<UserAuthorizeGroup>
    {
        Task<IDataResult<IEnumerable<UserAuthorizeGroup>>> GetUserAuthorizeGroup(int userId);
    }
}
