using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract
{
    public interface IUserManager
    {
        Task<IDataResult<IEnumerable<UserLDto>>> List();
        Task<IDataResult<IEnumerable<UserSDto>>> ListWithAuthGroups();
        Task<IDataResult<UserSDto>> Get(int id);
        Task<IResult> Edit(UserSDto userSDto);
        Task<IResult> ResetPassword(UserResetPasswordDto userPasswordDto);
        Task<IResult> Delete(int userId);
    }
}
