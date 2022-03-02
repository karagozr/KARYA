using KARYA.CORE.Abstarct;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.DATAACCESS.Abstract.User 
{ 

    public interface IUserDal :IBaseDal<Users>
    {
        Task<Users> GetUserWithAutorizeGroups(Expression<Func<Users, bool>> filter);
        Task<IEnumerable<Users>> GetUserListWithAutorizeGroups(Expression<Func<Users, bool>> filter);
        Task AddComplex(Users users);

        Task UpdateComplex(Users users);
    }
}
