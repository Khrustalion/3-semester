using Contracts.Accounts;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios.AddAccount;

public class AddAccountScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;

    public AddAccountScenarioProvider(
        IAccountService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new AddAccountScenario(_service);
        return true;
    }
}