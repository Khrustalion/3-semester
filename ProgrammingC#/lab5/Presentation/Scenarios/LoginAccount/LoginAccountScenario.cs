using Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Scenarios.LoginAccount;

public class LoginAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public LoginAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Login Account";

    public void Run()
    {
        int accountNumber = AnsiConsole.Ask<int>("Enter your Account number: ");
        int accountPin = AnsiConsole.Ask<int>("Enter your Account pin: ");

        LoginResult result = _accountService.Login(accountNumber, accountPin);

        string message = result switch
        {
            LoginResult.Success => "Successfully loggin",
            LoginResult.NotFound => "Account not found",
            LoginResult.WrongPassword => "Wrong pin",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}