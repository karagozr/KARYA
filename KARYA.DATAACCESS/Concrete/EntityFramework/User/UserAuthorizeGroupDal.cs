using KARYA.CORE.Concrete.EntityFramework;
using KARYA.DATAACCESS.Abstract.User;
using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using KARYA.MODEL.Entities.Karya;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.User
{
    public class UserAuthorizeGroupDal : EfRepository<UserAuthorizeGroup, KaryaContext>, IUserAuthorizeGroupDal
    {
    }
}
