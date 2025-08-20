namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramDir;

public abstract record ProgramResultTypes
{
    private ProgramResultTypes() { }

    public sealed record UserIsNotDirector : ProgramResultTypes;

    public sealed record Success : ProgramResultTypes;
}