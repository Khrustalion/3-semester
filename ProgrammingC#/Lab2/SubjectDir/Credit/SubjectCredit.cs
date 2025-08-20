using Itmo.ObjectOrientedProgramming.Lab2.Materials;
using Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir.Credit;

public class SubjectCredit : AbstractSubject
{
    public override int? ParentId { get; }

    public override int Id { get; }

    public override string Name { get; protected set;  }

    public int MinPoints { get; protected set; }

    public IReadOnlyCollection<LaboratoryWork> Tasks { get; }

    public IReadOnlyCollection<LectureMaterials> Materials { get; }

    public override User Author { get; protected set; }

    public SubjectCredit(
        int? parentId,
        int id,
        string name,
        int minPoints,
        IReadOnlyCollection<LaboratoryWork> tasks,
        IReadOnlyCollection<LectureMaterials> materials,
        User author)
    {
        ParentId = parentId;
        Id = id;
        Name = name;
        MinPoints = minPoints;
        Tasks = tasks;
        Materials = materials;
        Author = author;
    }

    public override SubjectResultTypes TryReplaceName(string newName, User user)
    {
        if (string.IsNullOrEmpty(newName)) throw new ArgumentException("New name cannot be null or empty.", nameof(newName));
        if (!CheckUserIsAuthor(user)) return new SubjectResultTypes.UserIsNotAuthor();

        Name = newName;
        return new SubjectResultTypes.Success();
    }

    public SubjectResultTypes TryReplaceMinPoints(int newMinPoints, User user)
    {
        if (newMinPoints <= 0) throw new ArgumentException("Points cannot be negative.", nameof(newMinPoints));
        if (!CheckUserIsAuthor(user)) return new SubjectResultTypes.UserIsNotAuthor();

        MinPoints = newMinPoints;
        return new SubjectResultTypes.Success();
    }

    public SubjectCredit Clone(int newId, User newAuthor)
    {
        return new SubjectCreditBuilder()
            .WithParentId(Id)
            .WithId(newId)
            .WithName(Name)
            .WithMinPoints(MinPoints)
            .WithTasks(Tasks)
            .WithMaterials(Materials)
            .WithAuthor(newAuthor)
            .Build();
    }

    private bool CheckUserIsAuthor(User user)
    {
        return user == Author;
    }
}