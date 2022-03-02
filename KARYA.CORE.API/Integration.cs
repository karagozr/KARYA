using KARYA.CORE.API.Helpers;
using KARYA.CORE.API.Middlewares;
using KARYA.DATAACCESS.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.OpenApi.Models;
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
        public static void AddCoreApiServices(this IServiceCollection services, IConfiguration configuration)
        {

            var assemblyName = typeof(Integration).Assembly.GetName().Name;
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName(assemblyName)));
            services.AddCoreDependencies();
            services.AddKaryaMigrate(configuration);


            //services.AddControllers(o => {
            //    o.Conventions.Add(new GroupingByNamespaceConvertion());
            //});

            //services.AddApiVersioning(o => {
            //    o.AssumeDefaultVersionWhenUnspecified = true;
            //    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
            //});

            //services.AddSwaggerGen(c =>
            //{

            //    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "API V1 TITLE",
            //        Description = "API V1 DESCRIPTION"
            //    });

            //    c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Version = "v2",
            //        Title = "API V2 TITLE",
            //        Description = "API V2 DESCRIPTION"
            //    });

            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //    {
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer",
            //        BearerFormat = "JWT",
            //        In = ParameterLocation.Header,
            //        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //              new OpenApiSecurityScheme
            //                {
            //                    Reference = new OpenApiReference
            //                    {
            //                        Type = ReferenceType.SecurityScheme,
            //                        Id = "Bearer"
            //                    }
            //                },
            //                new string[] {}

            //        }
            //    });

            //c.TagActionsBy(api =>
            //{
            //    if (api.GroupName != null)
            //    {
            //        return new[] { api.GroupName };
            //    }

            //    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
            //    if (controllerActionDescriptor != null)
            //    {
            //        return new[] { controllerActionDescriptor.ControllerName };
            //    }

            //    throw new InvalidOperationException("Unable to determine tag for endpoint.");
            //});
            //c.DocInclusionPredicate((name, api) => true);

            //c.ResolveConflictingActions(a => a.First());
            //c.OperationFilter<RemoveVersionFromParameter>();
            //c.DocumentFilter<ReplaceVersionParameterInPath>();

            //});


        }
        //public static void AddCoreApiConfigure(this IApplicationBuilder app, IWebHostEnvironment env)
        //{
            
            
        //}
    }
}
