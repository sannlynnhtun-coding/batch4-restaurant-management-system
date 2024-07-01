using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Batch4.Api.RestaurantManagementSystem.DA.Dapper;

public class DapperService
{
    private readonly string _connectionString;

    public DapperService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<T> Query<T>(string query, object? param = null)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        List<T> lst = db.Query<T>(query, param).ToList();
        return lst;
    }
}
