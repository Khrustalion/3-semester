using Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Scenarios.WithdrawAccount;

public class WithdrawAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw Account";

    public void Run()
    {
        int withdraw = AnsiConsole.Ask<int>("Enter the deposit amount: ");

        OperationResult result = _accountService.WithdrawAccount(withdraw);

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