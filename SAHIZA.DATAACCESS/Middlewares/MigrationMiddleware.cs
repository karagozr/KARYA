using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAHIZA.DATAACCESS.Concrete.EntityFramework;

namespace SAHIZA.DATAACCESS.Middlewares
{
    public static class MigrationMiddleware
    {
        public static void AddSahizaMigrate(this IServiceCollection services, IConfiguration configuration)
        {
            string programName = typeof(MigrationMiddleware).Assembly.GetName().Name;
            services.AddDbContext<SahizaWorldContext>(options => options.UseSqlServer(configuration.GetConnectionString("SAHIZAWORLDConnection"), x => x.MigrationsAssembly(programName)));
            services.BuildServiceProvider().GetService<SahizaWorldContext>().Database.Migrate();
        }
    }
}

