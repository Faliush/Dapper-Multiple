using System.Data;

namespace DapperMultiple;

public abstract class DbContext(IDbConnection connection)
{
    public IDbConnection Connection { get; } = connection;
}