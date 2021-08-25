using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.DATAACCESS.Abstract.Authorize
{
    public interface IAuthorizeGroupDetailFieldAccessDal : IBaseDal<AuthorizeGroupDetailFieldAccess>
    {
        //Task<IEnumerable<AuthorizeGroupDetailFieldAccess>> GetUserAuthorizeGroupDetailFieldAccessList(Expression<Func<Users, bool>> filter);
    }
}
