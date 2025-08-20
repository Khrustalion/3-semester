namespace Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

public class LaboratoryWork : AbstractTask, ITaskPrototype<LaboratoryWork>
{
    public override int? ParentId { get; }

    public override int Id { get; }

    public override string Name { get; protected set; }

    public override string? Description { get; protected set; }

    public override string EvaluationCriteria { get; protected set; }

    public override int NumberPoints { get; protected set; }

    public override User Author { get; }

    public LaboratoryWork(
        int? parentId,
        int id,
        string name,
        string? description,
        string evaluationCriteria,
        int numberPoints,
        User author)
    {
        ParentId = parentId;
        Id = id;
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        NumberPoints = numberPoints;
        Author = author;
    }

    public override TaskResultTypes TryReplaceName(string newName, User user)
    {
        if (string.IsNullOrEmpty(newName)) throw new ArgumentException("New name cannot be null or empty.", nameof(newName));
        if (!CheckUserIsAuthor(user)) return new TaskResultTypes.UserIsNotAuthor();

        Name = newName;

        return new TaskResultTypes.Success();
    }

    public override TaskResultTypes TryReplaceDescription(string newDescription, User user)
    {
        if (string.IsNullOrEmpty(newDescription)) throw new ArgumentException("New description cannot be null or empty.", nameof(newDescription));
        if (!CheckUserIsAuthor(user)) return new TaskResultTypes.UserIsNotAuthor();

        Description = newDescription;

        return new TaskResultTypes.Success();
    }

    public override TaskResultTypes TryReplaceEvaluationCriteria(string newEvaluationCriteria, User user)
    {
        if (string.IsNullOrEmpty(newEvaluationCriteria)) throw new ArgumentException("New evaluation criteria cannot be null or empty.", nameof(newEvaluationCriteria));
        if (!CheckUserIsAuthor(user)) return new TaskResultTypes.UserIsNotAuthor();

        EvaluationCriteria = newEvaluationCriteria;

        return new TaskResultTypes.Success();
    }

    public LaboratoryWork Clone(int newId, User newAuthor)
    {
        return new LaboratoryWorkBuilder()
            .WithParentId(Id)
            .WithId(newId)
            .WithName(Name)
            .WithDescription(Description)
            .WithEvaluationCriteria(EvaluationCriteria)
            .WithNumberPoints(NumberPoints)
            .WithAuthor(newAuthor)
            .Build();
    }

    private bool CheckUserIsAuthor(User user)
    {
        return user == Author;
    }
}