using System.Data;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using Npgsql;

namespace DapperMultiple;

public sealed class DbContextOptionBuilder : IDisposable
{
    private bool _disposed = false;
    internal IDbConnection? Connection { get; private set; }
    
    public void UseNpgSql(string connectionString)
    {
        Connection = new NpgsqlConnection(connectionString);
    }

    public void UseSqlServer(string connectionString)
    {
        Connection = new SqlConnection(connectionString);
    }

    public void UseMySql(string connectionString)
    {
        Connection = new MySqlConnection(connectionString);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Connection?.Dispose();
            }
        }

        _disposed = true;
    }
}