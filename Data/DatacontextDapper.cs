using HelloWorld.Models;
using System.Data;

using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DatacontextDapper
    {
      // private IConfiguration _config;
    private string? _connectionString ;
    public DatacontextDapper(IConfiguration config)
      {
        // _config = config;
         _connectionString = config.GetConnectionString("DefaultConnection");
      }
        public IEnumerable<T> LoadData<T>(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.Query<T>(sql);
    }
    public T LoadDatasingle<T>(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.QuerySingle<T>(sql);
    }
    public bool ExecuteSql(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return( dbConnection.Execute(sql) > 0);
    }

    

    
  }
}
