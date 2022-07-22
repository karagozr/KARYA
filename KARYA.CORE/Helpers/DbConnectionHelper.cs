using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KARYA.CORE.Helpers
{
    public static class DbConnectionHelper
    {
        public static string GetConnectionString(string connectionName)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var Configuration = builder.Build();

            var connStr = Configuration.GetConnectionString(connectionName);

            return connStr;
        }


    }

    public static class AppsettingHelper
    {
        public static string GetConnectionString(string connectionName)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var Configuration = builder.Build();

            var connStr = Configuration.GetConnectionString(connectionName);

            return connStr;
        }

        public static List<string> GetStringArrayValue(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var Configuration = builder.Build();

            var sections = Configuration.GetSection(key).GetChildren().Select(x => x.Value).ToList();


            return sections;
        }

        public static string GetSingleValue(string key,string subKey)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var Configuration = builder.Build();

            var val = Configuration.GetSection(key).GetSection(subKey).Value;


            return val;
        }


    }
}
