using Models.Accounts;
using Models.Tracnsactions;

namespace Contracts.Accounts;

public interface IAccountService
{
    LoginResult Login(long number, int pin);

    void Logout();

    OperationResult AddAccount(Account account);

    OperationResult DepositAccount(decimal amount);

    OperationResult WithdrawAccount(decimal amount);

    decimal GetAccountBalance();

    IEnumerable<Transaction> GetTransaction();
}