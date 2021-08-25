using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KARYA.DATAACCESS.Helpers
{
    public static class DbHelper
    {
        public static string GetConnectionString(string connectionName)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var Configuration = builder.Build();

            var connStr = Configuration.GetConnectionString(connectionName);

            return connStr;
        }
        
        /*
         *  services.AddDbContext<KaryaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KARYAConnection"), x => x.MigrationsAssembly(programName)));
            services.AddDbContext<HanelContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HANELConnection"), x => x.MigrationsAssembly(programName)));

            services.BuildServiceProvider().GetService<KaryaContext>().Database.Migrate();
            services.BuildServiceProvider().GetService<HanelContext>().Database.Migrate();
         */


    }
}
