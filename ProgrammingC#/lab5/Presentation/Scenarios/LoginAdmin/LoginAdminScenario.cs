using Contracts.Admins;
using Spectre.Console;

namespace Presentation.Scenarios.LoginAdmin;

public class LoginAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LoginAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login Admin";

    public void Run()
    {
        string adminPassword = AnsiConsole.Ask<string>("Enter Admin password: ");

        AdminOperationResult result = _adminService.Login(adminPassword);

        string message = result switch
        {
            AdminOperationResult.Success => "Successfully loggin",
            AdminOperationResult.WrongPassword => "Wrong password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}