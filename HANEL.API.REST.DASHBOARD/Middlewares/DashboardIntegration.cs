using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.Json;
using HANEL.API.REST.DASHBOARD.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.DASHBOARD.Middlewares
{
    public static class DashboardIntegration
    {
        public static void AddERPDashboardService(this IServiceCollection services)
        {

            services.AddScoped((IServiceProvider serviceProvider) => {

                DashboardConfigurator configurator = new();
                DataSourceInMemoryStorage dataSourceStorage = new();

                DashboardObjectDataSource objDataSource = new("Otel Konaklama Satış");
                objDataSource.DataId = "hotelRaw";
                
                dataSourceStorage.RegisterDataSource("hotelRaw", objDataSource.SaveToXml());
                configurator.DataLoading += DataLoading;

                // DashboardJsonDataSource jsonDataSourceUrl = new("JSON Data Source (URL)");
                // jsonDataSourceUrl.JsonSource = new UriJsonSource(new Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json"));
                // jsonDataSourceUrl.RootElement = "Customers";
                // jsonDataSourceUrl.Fill();
                // dataSourceStorage.RegisterDataSource("jsonDataSourceUrl", jsonDataSourceUrl.SaveToXml());
                // configurator.SetDataSourceStorage(dataSourceStorage);
                configurator.SetDataSourceStorage(dataSourceStorage);
                return configurator;

            });

        }



        private static void DataLoading(object sender, DataLoadingWebEventArgs e)
        {
            if (e.DataId == "hotelRaw")
            {
                var source = new HotelERPDatasources();
                e.Data = source.GetHotelAccomodation();
            }
        }
    }
}
