using Bookify.Application.Abstractions.Data;
using Npgsql;
using System.Data;

namespace Bookify.Infrastructure.Data;
internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var conn = new NpgsqlConnection(_connectionString);
        conn.Open();

        return conn;

    }
}
