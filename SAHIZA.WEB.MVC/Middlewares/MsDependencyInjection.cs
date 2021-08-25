
using KARYA.BUSINESS.Abstract.Karya;
using KARYA.BUSINESS.Concrete.Karya;
using KARYA.DATAACCESS.Abstract.Authorize;
using KARYA.DATAACCESS.Abstract.User;
using KARYA.DATAACCESS.Concrete.EntityFramework.Authorize;
using KARYA.DATAACCESS.Concrete.EntityFramework.User;
using KARYA.MODEL.Authorize;
using KARYA.MODEL.Authorize.SahizaWorld;
using KARYA.MODEL.Module;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.BUSINESS.Concrete;
using SAHIZA.DATAACCESS.Abstarct;
using SAHIZA.DATAACCESS.Abstract;
using SAHIZA.DATAACCESS.Concrete.EntityFramework;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Module;

namespace SAHIZA.WEB.MVC.Middlewares
{
    public static class MsDependencyInjection
    {
        public static void AddMsDependencies(this IServiceCollection services)
        {

            services.AddScoped<ICoreModules, SahizaModules>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<IUserManager, UserManager>();

            services.AddScoped<IAuthorizeGroupDal, AuthorizeGroupDal>();
            services.AddScoped<IAuthorizeGroupManager, AuthorizeGroupManager>();
            services.AddScoped<IAppModules, AppModules>();

            services.AddScoped<IStokDal, StokDal>();
            services.AddScoped<IStokManager, StokManager>();

            services.AddScoped<IStokHaraketDal, StokHaraketDal>();
            services.AddScoped<IStokHaraketManager, StokHaraketManager>();

            services.AddScoped<ICariDal, CariDal>();
            services.AddScoped<ICariManager, CariManager>();

            services.AddScoped<IDizaynDal, DizaynDal>();
            services.AddScoped<IDizaynManager, DizaynManager>();

            services.AddScoped<IDizaynDetayDal, DizaynDetayDal>();
            services.AddScoped<IDizaynDetayManager, DizaynDetayManager>();

            services.AddScoped<IBelgeDal, BelgeDal>();
            services.AddScoped<IBelgeManager, BelgeManager>();

            services.AddScoped<IServisDal, ServisDal>();
            services.AddScoped<IServisManager, ServisManager>();

        }
    }
}
