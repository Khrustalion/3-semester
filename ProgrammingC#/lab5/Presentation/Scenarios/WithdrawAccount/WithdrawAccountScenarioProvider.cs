using Contracts.Accounts;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios.WithdrawAccount;

public class WithdrawAccountScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly ICurrentAccountService _currentAccount;

    public WithdrawAccountScenarioProvider(
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

        scenario = new WithdrawAccountScenario(_service);
        return true;
    }
}