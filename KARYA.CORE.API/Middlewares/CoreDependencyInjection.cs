using KARYA.BUSINESS.Abstract.Karya;
using KARYA.BUSINESS.Concrete;
using KARYA.BUSINESS.Concrete.Karya;
using KARYA.COMMON.Authorize.Abstract;
using KARYA.COMMON.Authorize.Concete;
using KARYA.DATAACCESS.Abstract.App;
using KARYA.DATAACCESS.Abstract.Authorize;
using KARYA.DATAACCESS.Abstract.User;
using KARYA.DATAACCESS.Concrete.EntityFramework.Authorize;
using KARYA.DATAACCESS.Concrete.EntityFramework.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace KARYA.CORE.API.Middlewares
{
    public static class CoreDependencyInjection
    {
        public static void AddCoreDependencies(this IServiceCollection services)
        {

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //TODO Kullanım dışı kalacak IUserManager
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserDal, UserDal>();

            services.AddScoped<IHttpContextValues, HttpContextValues>();

            services.AddScoped<IUserAuthorizeGroupDal, UserAuthorizeGroupDal>();
            services.AddScoped<IUserAuthorizeGroupManager, UserAuthorizeGroupManager>();

            services.AddScoped<IAuthorizeGroupDetailFieldAccessDal, AuthorizeGroupDetailFieldAccessDal>();
            services.AddScoped<IAuthorizeGroupDetailFieldAccessManager, AuthorizeGroupDetailFieldAccessManager>();

            services.AddScoped<IAuthorizeGroupDal, AuthorizeGroupDal>();
            services.AddScoped<IAuthorizeGroupManager, AuthorizeGroupManager>();

            services.AddScoped<IAppParameterDal, AppParameterDal>();
            services.AddScoped<IAppParameterManager, AppParameterManager>();

            services.AddScoped<KARYA.BUSINESS.Abstract.IUserManager, EfUserManager>();

            services.AddScoped<KARYA.BUSINESS.Abstract.IAuthGroupManager, EfAuthGroupManager>();

        }
    }
}
