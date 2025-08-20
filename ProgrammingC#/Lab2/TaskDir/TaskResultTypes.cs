namespace Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

public abstract record TaskResultTypes
{
    private TaskResultTypes() { }

    public sealed record UserIsNotAuthor : TaskResultTypes;

    public sealed record Success : TaskResultTypes;
}