using Contracts.Accounts;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios.DepositAccount;

public class DepositAccountScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly ICurrentAccountService _currentAccount;

    public DepositAccountScenarioProvider(
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

        scenario = new DepositAccountScenario(_service);
        return true;
    }
}