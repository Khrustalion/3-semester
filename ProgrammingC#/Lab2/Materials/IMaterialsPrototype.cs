namespace Itmo.ObjectOrientedProgramming.Lab2.Materials;

public interface IMaterialsPrototype<T> where T : IMaterialsPrototype<T>
{
    public T Clone(int newId, User newAuthor);
}