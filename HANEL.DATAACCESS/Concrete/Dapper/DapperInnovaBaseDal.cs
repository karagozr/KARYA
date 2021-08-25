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
using KARYA.CORE.Helpers;

namespace KARYA.DATAACCESS.Concrete.Dapper
{
    public abstract class DapperInnovaBaseDal
    {

        private SqlConnection SqlConnection(string _connectionString="")
        {
            _connectionString = DbConnectionHelper.GetConnectionString("NETSISConnection");
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
