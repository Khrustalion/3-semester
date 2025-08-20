using Models.Accounts;

namespace Abstractions.Repositories;

public interface IAccountRepository
{
    Account? FindAccountByNumber(long number);

    void AddAccount(Account account);

    void WithdrawAccount(Account account);

    void DepositAccount(Account account);
}