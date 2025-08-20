using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Accounts;
using Models.Tracnsactions;
using Npgsql;

namespace DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;
    private readonly ITransactionRepository _transactionRepository;

    public AccountRepository(IPostgresConnectionProvider connectionProvider, ITransactionRepository transactionRepository)
    {
        _connectionProvider = connectionProvider;
        _transactionRepository = transactionRepository;
    }

    public Account? FindAccountByNumber(long number)
    {
        const string sql = """
                           select account_number, balance, pin
                           from accounts
                           where account_number = :number;
                           """;

        NpgsqlConnection connection = _connectionProvider.GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("number", number);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Account(
            Number: reader.GetInt32(0),
            Balance: reader.GetDecimal(1),
            Pin: reader.GetInt32(2));
    }

    public void AddAccount(Account account)
    {
        const string sql = """
                           insert into accounts (account_number, balance, pin)
                           values
                           (:account_number, :balance, :pin);
                           """;

        NpgsqlConnection connection = _connectionProvider.GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("account_number", account.Number)
            .AddParameter("balance", account.Balance)
            .AddParameter("pin", account.Pin);

        command.ExecuteNonQuery();

        _transactionRepository.AddTransaction(new Transaction(account.Number, TransactionType.Create));
    }

    public void WithdrawAccount(Account account)
    {
        const string sql = """
                           update accounts
                           set
                           balance = :balance
                           where account_number = :number;
                           """;

        NpgsqlConnection connection = _connectionProvider.GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("balance", account.Balance)
            .AddParameter("number", account.Number);

        command.ExecuteNonQuery();

        _transactionRepository.AddTransaction(new Transaction(account.Number, TransactionType.Withdraw));
    }

    public void DepositAccount(Account account)
    {
        const string sql = """
                           update accounts
                           set
                           balance = :balance
                           where account_number = :number;
                           """;

        NpgsqlConnection connection = _connectionProvider.GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("balance", account.Balance)
            .AddParameter("number", account.Number);

        command.ExecuteNonQuery();

        _transactionRepository.AddTransaction(new Transaction(account.Number, TransactionType.Deposit));
    }
}