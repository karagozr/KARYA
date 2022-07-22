﻿using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

namespace HANEL.WEB.REPORT.Controllers {

    
    public class DefaultDashboardController : DashboardController {

        IConfiguration _configurationManager;
        private readonly string connectionString;
        public DefaultDashboardController(IConfiguration configurationManager,DashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null)
            : base(configurator, dataProtectionProvider) {

            _configurationManager = configurationManager;

            connectionString = _configurationManager.GetConnectionString("DashboardStorageConnection");
        }


        //[HttpPost("dashboardControl/dashboards")]
        //public IActionResult AddDashboard(NewDash newDash, string DashboardName , string dashboardName)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        MemoryStream stream = new MemoryStream();
        //        newDash.document.Save(stream);
        //        stream.Position = 0;

        //        SqlCommand InsertCommand = new SqlCommand(
        //            "INSERT INTO Dashboards (Dashboard, Caption) " +
        //            "output INSERTED.ID " +
        //            "VALUES (@Dashboard, @Caption)");
        //        InsertCommand.Parameters.Add("Caption", SqlDbType.NVarChar).Value = newDash.dashboardName;
        //        InsertCommand.Parameters.Add("Dashboard", SqlDbType.VarBinary).Value = stream.ToArray();
        //        InsertCommand.Connection = connection;
        //        string ID = InsertCommand.ExecuteScalar().ToString();
        //        connection.Close();
        //        return Ok(ID);
        //    }
        //}

    }

    public class NewDash
    {
        public XDocument document { get; set; }
        public string dashboardName { get; set; }

        public XDocument Document { get; set; }
        public string DashboardName { get; set; }
    }
}