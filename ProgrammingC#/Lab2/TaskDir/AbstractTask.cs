namespace Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

public abstract class AbstractTask
{
    public abstract int? ParentId { get; }

    public abstract int Id { get; }

    public abstract string Name { get; protected set; }

    public abstract string? Description { get; protected set; }

    public abstract string EvaluationCriteria { get; protected set; }

    public abstract int NumberPoints { get; protected set; }

    public abstract User Author { get; }

    public abstract TaskResultTypes TryReplaceName(string newName, User user);

    public abstract TaskResultTypes TryReplaceDescription(string newDescription, User user);

    public abstract TaskResultTypes TryReplaceEvaluationCriteria(string newEvaluationCriteria, User user);
}