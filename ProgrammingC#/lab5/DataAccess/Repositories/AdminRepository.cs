using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public int? GetPassword()
    {
        const string sql = """
                           select admin_password
                           from admins;
                           """;

        NpgsqlConnection connection = _connectionProvider.GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return reader.GetInt32(0);
    }

    public void ChangePassword(int newPassword)
    {
        const string sql = """
                           update admins
                           set
                           admin_password = :newPassword;
                           """;

        NpgsqlConnection connection = _connectionProvider.GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("newpassword", newPassword);

        command.ExecuteNonQuery();
    }

    public void SetDefaultPassword(int defaultPassword)
    {
        const string sql = """
                           insert into admins
                           values 
                           (:admin_password);
                           """;

        NpgsqlConnection connection = _connectionProvider.GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("admin_password", defaultPassword);

        command.ExecuteNonQuery();
    }
}