namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public abstract class AbstractSubject
{
    public abstract int? ParentId { get; }

    public abstract int Id { get; }

    public abstract string Name { get; protected set; }

    public abstract User Author { get; protected set; }

    public abstract SubjectResultTypes TryReplaceName(string newName, User user);
}