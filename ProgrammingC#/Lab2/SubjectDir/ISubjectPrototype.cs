namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public interface ISubjectPrototype<T> where T : ISubjectPrototype<T>
{
    public T Clone(int newId, User newAuthor);
}