using System.Data;

namespace worldwidewhat.CommonTools.Database;

public interface IDbConnectionFactory
{
    /// <summary>
    /// Create connection
    /// </summary>
    /// <returns>IDbConnection</returns>
    public Task<IDbConnection> CreateConnectionAsync();
}
