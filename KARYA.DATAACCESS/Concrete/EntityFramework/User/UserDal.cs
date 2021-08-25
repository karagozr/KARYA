using KARYA.CORE.Concrete.EntityFramework;
using KARYA.DATAACCESS.Abstract.User;
using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using KARYA.MODEL.Entities.Karya;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.User
{
    public class UserDal : EfRepository<Users, KaryaContext>, IUserDal
    {
       
        public async Task<Users> GetUserWithAutorizeGroups(Expression<Func<Users, bool>> filter)
        {
            using (var context = new KaryaContext())
            {
                return await context.Set<Users>().Where(filter).Include(x => x.UserAuthorizeGroups).ThenInclude(z=>z.AuthorizeGroup).ThenInclude(y=>y.AuthorizeGroupDetails).FirstOrDefaultAsync();
            }
        }

        public async override Task<Users> Get(Expression<Func<Users, bool>> filter)
        {
            using (var context = new KaryaContext())
            {
                return await context.Set<Users>().Include(x => x.UserAuthorizeGroups).FirstOrDefaultAsync(filter);
            }
        }

        public override async Task AddComplex(Users entity)
        {
            using (var context = new KaryaContext())
            {
                entity = UpdateLog(entity);
                var addedEntity = context.Users.Add(entity);

                await context.SaveChangesAsync();
            }
        }


        public override async Task UpdateComplex(Users users)
        {
            using (var context = new KaryaContext())
            {
                users = UpdateLog(users);
                var currentAuthorize = context.UserAuthorizeGroup.Where(x => x.UserId == users.Id).ToList();

                var delete = currentAuthorize.Where(x => x.UserId == users.Id && !users.UserAuthorizeGroups.Select(a => a.AuthorizeGroupId).Contains(x.AuthorizeGroupId)).ToList();
                context.UserAuthorizeGroup.RemoveRange(delete);
                users.UserAuthorizeGroups = users.UserAuthorizeGroups.Where(x => !currentAuthorize.Select(x => x.AuthorizeGroupId).Contains(x.AuthorizeGroupId)).ToList();

                var updateEntity = context.Users.Update(users);

                await context.SaveChangesAsync();
            }
        }
    }
}
