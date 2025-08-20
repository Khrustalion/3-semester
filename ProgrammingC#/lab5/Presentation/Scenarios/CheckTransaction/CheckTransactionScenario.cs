using Contracts.Accounts;
using Models.Tracnsactions;
using Spectre.Console;

namespace Presentation.Scenarios.CheckTransaction;

public class CheckTransactionScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CheckTransactionScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Check Transactions";

    public void Run()
    {
        IEnumerable<Transaction> transactions = _accountService.GetTransaction();

        Table table = new Table()
            .Border(TableBorder.Rounded)
            .AddColumn("Account Number")
            .AddColumn("Transaction Type");

        foreach (Transaction transaction in transactions)
        {
            table.AddRow(transaction.AccountNumber.ToString(), transaction.Type.ToString());
        }

        AnsiConsole.Write(table);

        AnsiConsole.Ask<string>("Ok");
    }
}