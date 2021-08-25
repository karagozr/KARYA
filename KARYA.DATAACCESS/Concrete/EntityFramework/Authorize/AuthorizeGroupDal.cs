using KARYA.CORE.Concrete.EntityFramework;
using KARYA.DATAACCESS.Abstract.Authorize;
using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using KARYA.MODEL.Entities.Karya;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.Authorize
{
    public class AuthorizeGroupDal : EfRepository<AuthorizeGroup, KaryaContext>, IAuthorizeGroupDal
    {
        public async Task<AuthorizeGroup> GetWithDetails(Expression<Func<AuthorizeGroup, bool>> filter)
        {
            using (var context = new KaryaContext())
            {
                return await context.Set<AuthorizeGroup>().Where(filter).Include(z => z.AuthorizeGroupDetails).ThenInclude(a=>a.AppModule).FirstOrDefaultAsync();
            }
        }

        public async Task UpdateCascade(AuthorizeGroup authorizeGroup)
        {
            using (var context = new KaryaContext())
            {
                var oldAuthorizeGrupDetails = context.AuthorizeGroupDetail.Where(x => x.AuthorizeGroupId == authorizeGroup.Id);
                var notDelete = authorizeGroup.AuthorizeGroupDetails.Where(z => z.Id > 0).Select(y => y.Id);

                foreach (var item in oldAuthorizeGrupDetails.Where(x => !notDelete.Contains(x.Id)))
                {
                    context.Set<AuthorizeGroupDetail>().Remove(item);
                }

                context.Set<AuthorizeGroup>().Update(authorizeGroup);

                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = authorizeGroup.Id;

            }
        }
    }
}


/*
 {
  "id": 8,
  "name": "string",
  "description": "string",
  "authorizeGrupDetailModels": [
    {
      "id": 2027,
      "appModuleId": 3,
      "isAuthorize": true
    },{
      "authorizeGroupId": 8,
      "appModuleId": 1,
      "isAuthorize": true
    },{
      "authorizeGroupId": 8,
      "appModuleId": 2,
      "isAuthorize": true
    }
  ]
}
*/