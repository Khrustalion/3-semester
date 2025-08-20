using Models.Tracnsactions;

namespace Abstractions.Repositories;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetAllTransactionsByAccountNumber(long accountNumber);

    void AddTransaction(Transaction transaction);
}