using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramDir;

public abstract class AbstractProgram
{
    public abstract Dictionary<int, List<AbstractSubject>> Subjects { get; }

    public abstract int? ParentId { get; }

    public abstract int Id { get; }

    public abstract string Name { get; protected set; }

    public abstract User Director { get; }

    public abstract ProgramResultTypes TryReplaceName(string newName, User user);
}