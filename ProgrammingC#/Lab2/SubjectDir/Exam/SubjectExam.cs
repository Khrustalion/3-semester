using Itmo.ObjectOrientedProgramming.Lab2.Materials;
using Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public class SubjectExam : AbstractSubject, ISubjectPrototype<SubjectExam>
{
    public override int? ParentId { get; }

    public override int Id { get; }

    public override string Name { get; protected set;  }

    public int ExamPoints { get; protected set; }

    public IReadOnlyCollection<LaboratoryWork> Tasks { get; }

    public IReadOnlyCollection<LectureMaterials> Materials { get; }

    public override User Author { get; protected set; }

    public SubjectExam(
        int? parentId,
        int id,
        string name,
        int examPoints,
        IReadOnlyCollection<LaboratoryWork> tasks,
        IReadOnlyCollection<LectureMaterials> materials,
        User author)
    {
        ParentId = parentId;
        Id = id;
        Name = name;
        ExamPoints = examPoints;
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

    public SubjectResultTypes TryReplaceExamPoints(int newPoints, User user)
    {
        if (newPoints <= 0) throw new ArgumentException("Points cannot be negative.", nameof(newPoints));
        if (!CheckUserIsAuthor(user)) return new SubjectResultTypes.UserIsNotAuthor();

        ExamPoints = newPoints;
        return new SubjectResultTypes.Success();
    }

    public SubjectExam Clone(int newId, User newAuthor)
    {
        return new SubjectExamBuilder()
            .WithParentId(Id)
            .WithId(newId)
            .WithName(Name)
            .WithExamPoints(ExamPoints)
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