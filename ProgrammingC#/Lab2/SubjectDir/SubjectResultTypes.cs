namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public abstract record SubjectResultTypes
{
    private SubjectResultTypes() { }

    public sealed record UserIsNotAuthor : SubjectResultTypes;

    public sealed record Success : SubjectResultTypes;

    public sealed record TotalPointsIsNot100;
}