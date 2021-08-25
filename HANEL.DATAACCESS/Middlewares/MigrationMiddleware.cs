using HANEL.DATAACCESS.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.DATAACCESS.Middlewares
{
    public static class MigrationMiddleware
    {
        public static void AddHanelMigrate(this IServiceCollection services, IConfiguration configuration)
        {
            string programName = typeof(MigrationMiddleware).Assembly.GetName().Name;
            services.AddDbContext<HanelContext>(options => options.UseSqlServer(configuration.GetConnectionString("HANELConnection"), x => x.MigrationsAssembly(programName)));
            services.BuildServiceProvider().GetService<HanelContext>().Database.Migrate();
        }
    }
}

