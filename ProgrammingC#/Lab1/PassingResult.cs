namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record PassingResult
{
    private PassingResult() { }

    public sealed record Success : PassingResult;

    public sealed record Failure : PassingResult;
}
