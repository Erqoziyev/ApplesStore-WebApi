using Npgsql;

namespace AppleStore.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection(
            "Host = localhost; " +
            "Port = 5432;" +
            "Database = apples-store-db;" +
            "User Id = postgres;" +
            "Password = 0809");
    } 
}
