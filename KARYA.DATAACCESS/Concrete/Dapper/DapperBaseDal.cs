using KARYA.DATAACCESS.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;

namespace KARYA.DATAACCESS.Concrete.Dapper
{
    public abstract class DapperBaseDal
    {

        private SqlConnection SqlConnection(string _connectionString="")
        {
            _connectionString = DbHelper.GetConnectionString("HANELConnection");
            return new SqlConnection(_connectionString);
        }

        protected IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }

        
    }

}
