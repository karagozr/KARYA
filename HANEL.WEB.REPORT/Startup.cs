using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using HANEL.BUSINESS.Abstract.Hotel;
using HANEL.BUSINESS.Concrete.Hotel;
using HANEL.WEB.REPORT.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace HANEL.WEB.REPORT {



    public class Startup {

        public DataSourceInMemoryStorage CreateDataSourceStorage()
        {
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            DashboardObjectDataSource objDataSource = new DashboardObjectDataSource("Hotel Data Source");
            dataSourceStorage.RegisterDataSource("objectDataSource", objDataSource.SaveToXml());

            DashboardObjectDataSource objDataSource1 = new DashboardObjectDataSource("Netsis Data Source");
            dataSourceStorage.RegisterDataSource("objectDataSource1", objDataSource1.SaveToXml());

            

            return dataSourceStorage;
        }

      

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment) {
            Configuration = configuration;
            FileProvider = hostingEnvironment.ContentRootFileProvider;
            DashboardExportSettings.CompatibilityMode = DashboardExportCompatibilityMode.Restricted;
        }

        public IFileProvider FileProvider { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services
                .AddResponseCompression()
                .AddDevExpressControls()
                .AddMvc();

            var serviceProvider = services.AddSingleton<IHotelReportManager, HotelReportManager>();

            //services.AddScoped<DashboardConfigurator>((IServiceProvider serviceProvider) => {
            //    DashboardConfigurator configurator = new DashboardConfigurator();

            //    configurator.DataLoading += (s, e) => {
            //        if (e.DataSourceName == "Hotel Data Source")
            //        {

            //            var aa = serviceProvider.GetService<IHotelReportManager>();
            //            e.Data = aa.RoomSaleAgentCountryMarket(new MODEL.Filter.Hotel.DateRangeModel()).Result.Data;
            //        }
            //        if (e.DataSourceName == "Netsis Data Source")
            //        {
            //            e.Data = SalesData.CreateData1();
            //        }

            //    };

            //    configurator.SetDataSourceStorage(CreateDataSourceStorage());
            //    return configurator;
            //});

            services.AddScoped<DashboardConfigurator>((IServiceProvider serviceProvider) => {
                DashboardConfigurator configurator = new DashboardConfigurator();

                configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(Configuration));

                var dataBaseDashboardStorage = new DataBaseEditaleDashboardStorage(
                    Configuration.GetConnectionString("DashboardStorageConnection"));

                configurator.SetDashboardStorage(dataBaseDashboardStorage);

                DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
                DashboardObjectDataSource objDataSource = new DashboardObjectDataSource("Object Data Source", typeof(SalesPersonData));

                objDataSource.DataMember = "GetSalesData";

                dataSourceStorage.RegisterDataSource("objectDataSource", objDataSource.SaveToXml());

                configurator.SetDataSourceStorage(dataSourceStorage);

                return configurator;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDevExpressControls();

            app.UseRouting();
            app.UseEndpoints(endpoints => {
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "dashboardControl", "DefaultDashboard");
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public class SalesData
    {
        public string SalesPerson { get; set; }
        public int Quantity { get; set; }

        public static List<SalesData> CreateData()
        {
            List<SalesData> data = new List<SalesData>();
            string[] salesPersons = { "Andrew Fuller", "Michael Suyama",
                                "Robert King", "Nancy Davolio",
                                "Margaret Peacock", "Laura Callahan",
                                "Steven Buchanan", "Janet Leverling" };
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                SalesData record = new SalesData();
                record.SalesPerson = salesPersons[rnd.Next(0, salesPersons.Length)];
                record.Quantity = rnd.Next(0, 100);
                data.Add(record);
            }
            return data;
        }

        public static List<SalesData> CreateData1()
        {
            List<SalesData> data = new List<SalesData>();
            string[] salesPersons = { "Rmazan Fuller", "Michael Suyama",
                                "Robert Lewandoski", "Nancy Davolio",
                                "Margaret Alla", "Dene Callahan",
                                "Steven Buchanan", "Janet Leverling" };
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                SalesData record = new SalesData();
                record.SalesPerson = salesPersons[rnd.Next(0, salesPersons.Length)];
                record.Quantity = rnd.Next(0, 100);
                data.Add(record);
            }
            return data;
        }
    }
}