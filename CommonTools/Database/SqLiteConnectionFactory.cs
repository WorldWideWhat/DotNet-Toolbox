using System.Data;
using Microsoft.Data.Sqlite;

namespace worldwidewhat.CommonTools.Database;

/// <summary>
/// SqLite conenction factory
/// </summary>
public class SqLiteConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public SqLiteConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Create sql connection
    /// </summary>
    /// <returns>IDbConnection</returns>
    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}
