using Contracts.Accounts;
using Models.Accounts;
using Spectre.Console;

namespace Presentation.Scenarios.AddAccount;

public class AddAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public AddAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Add Account";

    public void Run()
    {
        int number = AnsiConsole.Ask<int>("Enter the account number: ");
        int pin = AnsiConsole.Ask<int>("Enter the account pin: ");

        OperationResult result = _accountService.AddAccount(new Account(number, 0, pin));

        string message = result switch
        {
            OperationResult.Success => "Account has been successfully added",
            OperationResult.AccountHasBeenAdded => "Account has already been added",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}