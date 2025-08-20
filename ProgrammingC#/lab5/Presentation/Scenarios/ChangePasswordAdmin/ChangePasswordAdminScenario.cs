using Contracts.Admins;
using Spectre.Console;

namespace Presentation.Scenarios.ChangePasswordAdmin;

public class ChangePasswordAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public ChangePasswordAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Change Password Admin";

    public void Run()
    {
        string adminPassword = AnsiConsole.Ask<string>("Enter new Admin password: ");

        AdminOperationResult result = _adminService.ChangePassword(adminPassword);

        string message = result switch
        {
            AdminOperationResult.Success => "Successfully changed your password.",
            AdminOperationResult.AdminNotLoggin => "Admin is not login.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}