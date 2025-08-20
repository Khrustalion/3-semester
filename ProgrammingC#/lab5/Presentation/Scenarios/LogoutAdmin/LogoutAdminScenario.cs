using Contracts.Admins;
using Spectre.Console;

namespace Presentation.Scenarios.LogoutAdmin;

public class LogoutAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LogoutAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Logout Admin";

    public void Run()
    {
        _adminService.Logout();

        AnsiConsole.Ask<string>("Ok");
    }
}