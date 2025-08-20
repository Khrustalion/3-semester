using Microsoft.Extensions.DependencyInjection;
using Presentation.Scenarios.AddAccount;
using Presentation.Scenarios.ChangePasswordAdmin;
using Presentation.Scenarios.CheckAccountBalance;
using Presentation.Scenarios.CheckTransaction;
using Presentation.Scenarios.DepositAccount;
using Presentation.Scenarios.LoginAccount;
using Presentation.Scenarios.LoginAdmin;
using Presentation.Scenarios.LogoutAccount;
using Presentation.Scenarios.LogoutAdmin;
using Presentation.Scenarios.WithdrawAccount;

namespace Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckAccountBalanceScenarioProvider>();

        collection.AddScoped<IScenarioProvider, CheckTransactionScenarioProvider>();

        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ChangePasswordAdminScenarioProvider>();

        return collection;
    }
}