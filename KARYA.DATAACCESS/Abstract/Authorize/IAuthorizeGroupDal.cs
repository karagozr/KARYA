using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.DATAACCESS.Abstract.Authorize
{
    public interface IAuthorizeGroupDal : IBaseDal<AuthorizeGroup>
    {
        Task<AuthorizeGroup> GetWithDetails(Expression<Func<AuthorizeGroup, bool>> filter);
      
        Task UpdateCascade(AuthorizeGroup authorizeGroup);

    }
}
