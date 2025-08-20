using Models.Accounts;

namespace Contracts.Accounts;

public interface ICurrentAccountService
{
    Account? Account { get; }
}