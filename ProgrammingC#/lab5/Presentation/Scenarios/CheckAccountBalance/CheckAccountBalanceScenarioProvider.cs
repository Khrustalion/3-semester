using Contracts.Accounts;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios.CheckAccountBalance;

public class CheckAccountBalanceScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly ICurrentAccountService _currentAccount;

    public CheckAccountBalanceScenarioProvider(
        IAccountService service,
        ICurrentAccountService currentAccount)
    {
        _service = service;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new CheckAccountBalanceScenario(_service);
        return true;
    }
}