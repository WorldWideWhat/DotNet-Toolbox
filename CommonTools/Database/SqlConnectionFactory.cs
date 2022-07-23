using System.Data;
using System.Data.SqlClient;

namespace worldwidewhat.CommonTools.Database;
/// <summary>
/// Sql conenction factory
/// </summary>
public class SqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Create sql connection
    /// </summary>
    /// <returns>IDbConnection</returns>
    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}