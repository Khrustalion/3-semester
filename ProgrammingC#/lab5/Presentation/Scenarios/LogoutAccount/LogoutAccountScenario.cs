using Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Scenarios.LogoutAccount;

public class LogoutAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public LogoutAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Logout Account";

    public void Run()
    {
        _accountService.Logout();
        AnsiConsole.Ask<string>("Ok");
    }
}