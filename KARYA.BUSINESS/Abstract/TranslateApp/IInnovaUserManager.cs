using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.TranslateApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.TranslateApp
{
    public interface IInnovaUserManager
    {
        Task<IResult> AddUser(InnovaUser innovaUser);

        Task<IResult> UpdateUser(InnovaUser innovaUser);

        Task<IResult> DeleteUser(InnovaUser innovaUser);

        Task<IDataResult<InnovaUser>> LoginUser(string username, string password);
    }
}
