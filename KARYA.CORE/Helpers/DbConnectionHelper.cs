using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
}
