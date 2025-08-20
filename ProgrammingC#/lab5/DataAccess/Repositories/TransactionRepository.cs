using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Tracnsactions;
using Npgsql;

namespace DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Transaction> GetAllTransactionsByAccountNumber(long accountNumber)
    {
        long? accountId = GetAccountId(accountNumber);

        const string sql = """
                           select type
                           from transactions
                           where account_id = :accountId;
                           """;

        NpgsqlConnection connection = _connectionProvider.GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountId", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Transaction(
                AccountNumber: accountNumber,
                Type: reader.GetFieldValue<TransactionType>(0));
        }
    }

    public void AddTransaction(Transaction transaction)
    {
        long? account = GetAccountId(transaction.AccountNumber);

        const string sql = """
                           insert into transactions(account_id, type)
                           values
                           (:account_id, :transaction_type)
                           """;

        NpgsqlConnection connection = _connectionProvider.GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("account_id", account)
            .AddParameter("transaction_type", transaction.Type);

        command.ExecuteNonQuery();
    }

    private long? GetAccountId(long accountNumber)
    {
        const string sql = """
                                   select account_id
                                   from accounts
                                   where account_number = :accountNumber
                                   """;

        NpgsqlConnection connection = _connectionProvider.GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountNumber", accountNumber);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return reader.GetInt32(0);
    }
}