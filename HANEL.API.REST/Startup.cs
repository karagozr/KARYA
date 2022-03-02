using HANEL.API.REST.Middlewares;
using HANEL.DATAACCESS.Middlewares;
using KARYA.CORE.API;
using KARYA.DATAACCESS.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HANEL.API.REST
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddCoreApiServices(Configuration);

            services.AddMsDependencies();
            

            services.AddHanelMigrate(Configuration);
            
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
           

            services.AddControllers(options =>
            {
                options.Conventions.Add(new GroupingByNamespaceConvertion());
            });
            services.AddSwaggerGen(config =>
            {
                var titlebase = "HANEL REST API";
                
                
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = titlebase + " V1",
                    //Description = desc,
                    //Contact = contact,
                    //License = license,
                    //TermsOfService = termsofservice
                });
                config.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = titlebase + " V2",
                    //Description = desc,
                    //License = license,
                    //TermsOfService = termsofservice
                });

                config.TagActionsBy(api =>
                {

                    if (api.GroupName != null)
                    {
                        if (api.RelativePath.Split('/').Length > 2)
                        {
                            var controllerName = api.ActionDescriptor.GetType().GetProperty("ControllerName").GetValue(api.ActionDescriptor); //api.RelativePath.Split('/').Length > 3 ? "-" + api.RelativePath.Split('/')[3] : "";

                            var groupName = controllerName.ToString() == api.RelativePath.Split('/')[2] ? api.RelativePath.Split('/')[2] 
                            : api.RelativePath.Split('/')[2] + "-" + controllerName.ToString();

                           

                            return new[] { groupName };
                        }
                        else
                            return new[] { "OTHER" };
                    }

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor != null)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
                //config.DocInclusionPredicate((name, api) => true);
            });

            
            services.AddMvc();

            services.AddSwaggerDocumentation();

            //services.AddApiVersioning(options =>
            //{
            //    options.DefaultApiVersion = new ApiVersion(1, 0);
            //    options.AssumeDefaultVersionWhenUnspecified = true;
            //    options.ReportApiVersions = true;
            //});

            //services.AddVersionedApiExplorer(options =>
            //{
            //    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service  
            //    // note: the specified format code will format the version as "'v'major[.minor][-status]"  
            //    options.GroupNameFormat = "'v'VVV";

            //    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat  
            //    // can also be used to control the format of the API version in route templates  
            //    options.SubstituteApiVersionInUrl = true;
            //});
            ////services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            ////services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());

            //services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"));
            }

            app.UseSwagger();
           
            app.UseSwaggerUI(c => {
                c.DocExpansion(DocExpansion.None);
                //c.DefaultModelExpandDepth(-1);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");
            });
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            
            //app.AddCoreApiConfigure(env);


            //app.UseSwaggerDocumentation();

            
        }
    }
}
