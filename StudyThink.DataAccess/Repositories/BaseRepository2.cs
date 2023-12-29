using Dapper;
using System.Data.SqlClient;

namespace StudyThink.DataAccess.Repositories;

public class BaseRepository2
{
    protected readonly SqlConnection _connection;

    public BaseRepository2(string connectionString)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new SqlConnection(connectionString);
    }
}
