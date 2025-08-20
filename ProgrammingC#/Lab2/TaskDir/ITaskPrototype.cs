namespace Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

public interface ITaskPrototype<T> where T : ITaskPrototype<T>
{
    public T Clone(int newId, User newAuthor);
}