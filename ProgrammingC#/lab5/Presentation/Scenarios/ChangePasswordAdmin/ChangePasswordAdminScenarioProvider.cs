using Contracts.Admins;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Scenarios.ChangePasswordAdmin;

public class ChangePasswordAdminScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentAdminService _currentAdmin;

    public ChangePasswordAdminScenarioProvider(
        IAdminService service,
        ICurrentAdminService currentAdmin)
    {
        _service = service;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ChangePasswordAdminScenario(_service);
        return true;
    }
}