using DevExpress.DashboardWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HANEL.WEB.REPORT
{
    public class DashboardStorage : IEditableDashboardStorage
    {
        private string connectionString;

        public DashboardStorage(string connectionString)
        {
            this.connectionString = connectionString;
        }

        

        public XDocument LoadDashboard(string dashboardID)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand GetCommand = new SqlCommand("SELECT  Dashboard FROM Dashboards WHERE ID=@ID");
            //    GetCommand.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(dashboardID);
            //    GetCommand.Connection = connection;
            //    SqlDataReader reader = GetCommand.ExecuteReader();
            //    reader.Read();
            //    byte[] data = reader.GetValue(0) as byte[];
            //    MemoryStream stream = new MemoryStream(data);
            //    connection.Close();
            //    return XDocument.Load(stream);
            //}

            return XDocument.Load("");
        }

        public IEnumerable<DashboardInfo> GetAvailableDashboardsInfo()
        {
            List<DashboardInfo> list = new List<DashboardInfo>();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand GetCommand = new SqlCommand("SELECT ID, Caption FROM Dashboards");
            //    GetCommand.Connection = connection;
            //    SqlDataReader reader = GetCommand.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        string ID = reader.GetInt32(0).ToString();
            //        string Caption = reader.GetString(1);
            //        list.Add(new DashboardInfo() { ID = ID, Name = Caption });
            //    }
            //    connection.Close();
            //}
            return list;
        }

        public void SaveDashboard(string dashboardID, XDocument document)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    MemoryStream stream = new MemoryStream();
            //    document.Save(stream);
            //    stream.Position = 0;

            //    SqlCommand InsertCommand = new SqlCommand(
            //        "UPDATE Dashboards Set Dashboard = @Dashboard " +
            //        "WHERE ID = @ID");
            //    InsertCommand.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(dashboardID);
            //    InsertCommand.Parameters.Add("Dashboard", SqlDbType.VarBinary).Value = stream.ToArray();
            //    InsertCommand.Connection = connection;
            //    InsertCommand.ExecuteNonQuery();

            //    connection.Close();
            //}
        }

        public string AddDashboard(XDocument dashboard, string dashboardName)
        {
            throw new NotImplementedException();
        }
    }
}
