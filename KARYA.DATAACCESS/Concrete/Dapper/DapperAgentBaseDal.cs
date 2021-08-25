using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using System.Data;
using KARYA.DATAACCESS.Helpers;

namespace KARYA.DATAACCESS.Concrete.Dapper
{
    public abstract class DapperAgentBaseDal
    {

        private SqlConnection SqlConnection(string _connectionString="")
        {
            _connectionString = DbHelper.GetConnectionString("AGENTConnection");
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
