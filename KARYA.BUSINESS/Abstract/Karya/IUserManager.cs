using KARYA.BUSINESS.Abstract.Base;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Common.Auth;
using KARYA.MODEL.DataTransferModels.Karya.Auth;
using KARYA.MODEL.Entities.Karya;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.Karya
{
    public interface IUserManager : IBaseManager<Users>
    {
        Task<IDataResult<Users>> Login(UserLoginModel userLoginModel);
        Task<IDataResult<UserModel>> GetByIdWithAuthorizeGrups(int id);
        Task<IResult> AddComplex(UserModel user);
        Task<IResult> UpdateComplex(UserModel user);
        Task<IResult> AddUpdateComplex(UserModel user);
    }

}
