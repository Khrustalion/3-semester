using Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Scenarios.CheckAccountBalance;

public class CheckAccountBalanceScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CheckAccountBalanceScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Check Account Balance";

    public void Run()
    {
        Table table = new Table()
            .Border(TableBorder.Rounded)
            .AddColumn("Balance");

        table.AddRow(_accountService.GetAccountBalance().ToString());

        AnsiConsole.Write(table);

        AnsiConsole.Ask<string>("Ok");
    }
}