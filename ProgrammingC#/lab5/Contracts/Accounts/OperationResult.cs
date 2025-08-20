namespace Contracts.Accounts;

public abstract record OperationResult
{
    private OperationResult() { }

    public sealed record Success : OperationResult;

    public sealed record HaveNotEnoughMoney : OperationResult;

    public sealed record AccountNotLogin : OperationResult;

    public sealed record AccountHasBeenAdded : OperationResult;
}