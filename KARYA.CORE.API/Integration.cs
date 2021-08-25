using KARYA.CORE.API.Middlewares;
using KARYA.DATAACCESS.Middlewares;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.API
{
    public static class Integration
    {
        public static void AddCoreApi(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblyName = typeof(Integration).Assembly.GetName().Name;
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName(assemblyName)));
            services.AddCoreDependencies();
            services.AddKaryaMigrate(configuration);

        }
    }
}
