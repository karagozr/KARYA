using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Middlewares
{
    public static class SwaggerMiddleware
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {

            //services.AddApiVersioning(o =>
            //{
            //    o.AssumeDefaultVersionWhenUnspecified = true;
            //    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            //});

            //services.AddSwaggerGen(c =>
            //{
            //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api", Version = "v1" });

            //c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            //{
            //    Version = "v1",
            //    Title = "API V1 TITLE",
            //    Description = "API V1 DESCRIPTION"
            //});

            //c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
            //{
            //    Version = "v2",
            //    Title = "API V2 TITLE",
            //    Description = "API V2 DESCRIPTION"
            //});

            //c.ResolveConflictingActions(a => a.First());
            //c.OperationFilter<RemoveVersionFromParameter>();
            //c.DocumentFilter<ReplaceVersionParameterInPath>();

            //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //{
            //    Name = "Authorization",
            //    Type = SecuritySchemeType.ApiKey,
            //    Scheme = "Bearer",
            //    BearerFormat = "JWT",
            //    In = ParameterLocation.Header,
            //    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            //});
            //c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //    {
            //          new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                }
            //            },
            //            new string[] {}

            //    }
            //});
            //});

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("swagger/v1/swagger.json", "KARYA Web Api");
            //    c.RoutePrefix = string.Empty;
            //    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            //});

            //app.UseSwagger();
            //app.UseSwaggerUI(x =>
            //{
            //    x.SwaggerEndpoint($"/swagger/v1/swagger.json", "API V1");
            //    x.SwaggerEndpoint($"/swagger/v2/swagger.json", "API V2");
            //});

            return app;
        }
        //public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        //{
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api", Version = "v1" });


        //        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        //        {
        //            Name = "Authorization",
        //            Type = SecuritySchemeType.ApiKey,
        //            Scheme = "Bearer",
        //            BearerFormat = "JWT",
        //            In = ParameterLocation.Header,
        //            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        //        });
        //        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //        {
        //            {
        //                  new OpenApiSecurityScheme
        //                    {
        //                        Reference = new OpenApiReference
        //                        {
        //                            Type = ReferenceType.SecurityScheme,
        //                            Id = "Bearer"
        //                        }
        //                    },
        //                    new string[] {}

        //            }
        //        });
        //    });

        //    return services;
        //}

        //public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI(c =>
        //    {
        //        c.SwaggerEndpoint("swagger/v1/swagger.json", "KARYA Web Api");
        //        c.RoutePrefix = string.Empty;
        //        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        //    });

        //    return app;
        //}



    }
}



