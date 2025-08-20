using Models.Tracnsactions;

namespace Contracts.Transactions;

public interface ITransactionService
{
    IEnumerable<Transaction> GetAllTransactionsByAccountNumber(long accountNumber);

    void AddTransaction(Transaction transaction);
}