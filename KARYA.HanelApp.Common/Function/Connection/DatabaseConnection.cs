using KARYA.Core.Types.Return;
using KARYA.Core.Types.Return.Interfaces;
using KARYA.HanelApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.HanelApp.Common.Function.Connection
{
    public static class DatabaseConnection
    {
       
        public static string ConnectionString { get; set; }
        public static string Server     { get; set; }
        public static string DbName     { get; set; }
        public static string User       { get; set; }
        public static string Password   { get; set; }

        public static IResult TestConnection(ConnectionValuesModel connectionValuesModel)
        {
            var connectionString = $"Server={connectionValuesModel.Server};Database={connectionValuesModel.Database};User Id={connectionValuesModel.User};Password={connectionValuesModel.Password};";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return new SuccessResult("Connection is successful");
                }
                catch (SqlException ex)
                {
                    return new ErrorResult(ex.Message);
                }
            }
        }

    }
}
