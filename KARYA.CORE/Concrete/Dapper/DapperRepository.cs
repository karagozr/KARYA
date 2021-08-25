using KARYA.CORE.Abstract;
using KARYA.CORE.Helpers;
using Microsoft.Data.SqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Concrete.Dapper
{
    public abstract class DapperRepository : IDapperRepository
    {
        private string _dbName;
        public DapperRepository(string dbName) => _dbName = dbName;
        private SqlConnection SqlConnection(string _connectionString = "")
        {
            _connectionString = DbConnectionHelper.GetConnectionString(_dbName);
            return new SqlConnection(_connectionString);
        }
        private NpgsqlConnection PostgresConnection(string _connectionString = "")
        {
            _connectionString = DbConnectionHelper.GetConnectionString(_dbName);
            return new NpgsqlConnection(_connectionString);
        }

        protected IDbConnection CreateMsSqlConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }

        protected IDbConnection CreatePostgresConnection()
        {
            var conn = PostgresConnection();
            conn.Open();
            return conn;
        }

    }
}
