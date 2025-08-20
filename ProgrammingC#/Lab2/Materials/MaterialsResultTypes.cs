namespace Itmo.ObjectOrientedProgramming.Lab2.Materials;

public abstract record MaterialsResultTypes
{
    private MaterialsResultTypes() { }

    public sealed record UserIsNotAuthor : MaterialsResultTypes;

    public sealed record Success : MaterialsResultTypes;
}