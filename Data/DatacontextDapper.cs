using HelloWorld.Models;
using System.Data;

using Microsoft.Data.SqlClient;
using Dapper;

namespace HelloWorld.Data
{
    public class DatacontextDapper
    {
    private string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=True;";
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
