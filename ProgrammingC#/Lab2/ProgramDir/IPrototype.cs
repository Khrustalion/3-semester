namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramDir;

public interface IPrototype<T> where T : IPrototype<T>
{
    public T Clone(int id, User newDirector);
}