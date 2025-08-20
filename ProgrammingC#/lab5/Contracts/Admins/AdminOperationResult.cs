namespace Contracts.Admins;

public abstract record AdminOperationResult
{
    private AdminOperationResult() { }

    public sealed record Success() : AdminOperationResult();

    public sealed record WrongPassword() : AdminOperationResult();

    public sealed record AdminNotLoggin() : AdminOperationResult();
}