using Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Scenarios.DepositAccount;

public class DepositAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public DepositAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Deposit Account";

    public void Run()
    {
        int deposit = AnsiConsole.Ask<int>("Enter the deposit amount: ");

        OperationResult result = _accountService.DepositAccount(deposit);

        string message = result switch
        {
            OperationResult.Success => "Deposit account has been successfully deposited",
            OperationResult.AccountNotLogin => "Account don't loggin",
            OperationResult.HaveNotEnoughMoney => "Account hasn't enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}