using Itmo.ObjectOrientedProgramming.Lab2.Materials;
using Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public class SubjectExamBuilder : ISubjectBuilder<SubjectExamBuilder, SubjectExam>
{
    private int? _parentId;
    private int? _id;
    private string? _name;
    private IReadOnlyCollection<LaboratoryWork> _laborotoryWorks;
    private IReadOnlyCollection<LectureMaterials> _lectureMaterials;
    private User? _author;
    private int? _examPoints;

    public SubjectExamBuilder()
    {
        _parentId = null;
        _id = null;
        _name = null;
        _laborotoryWorks = new List<LaboratoryWork>();
        _lectureMaterials = new List<LectureMaterials>();
        _author = null;
    }

    public SubjectExamBuilder WithParentId(int? parentId)
    {
        _parentId = parentId;

        return this;
    }

    public SubjectExamBuilder WithId(int id)
    {
        _id = id;

        return this;
    }

    public SubjectExamBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public SubjectExamBuilder WithTasks(IReadOnlyCollection<LaboratoryWork> tasks)
    {
        _laborotoryWorks = tasks;

        return this;
    }

    public SubjectExamBuilder WithMaterials(IReadOnlyCollection<LectureMaterials> materials)
    {
        _lectureMaterials = materials;

        return this;
    }

    public SubjectExamBuilder WithAuthor(User author)
    {
        _author = author;

        return this;
    }

    public SubjectExamBuilder WithAuthor(int authorId, string authorName)
    {
        _author = new User(authorId, authorName);

        return this;
    }

    public SubjectExamBuilder WithExamPoints(int examPoints)
    {
        _examPoints = examPoints;

        return this;
    }

    public SubjectExam Build()
    {
        if (TotalPoints() is not null && TotalPoints() != 100) throw new InvalidOperationException("Total points must be 100");
        return new SubjectExam(
            _parentId,
            _id ?? throw new ArgumentException("id must be fill", nameof(_id)),
            _name ?? throw new ArgumentException("name must be fill", nameof(_name)),
            _examPoints ?? throw new ArgumentException("examPoints must be fill", nameof(_examPoints)),
            _laborotoryWorks,
            _lectureMaterials,
            _author ?? throw new ArgumentException("author must be fill", nameof(_author)));
    }

    private int? TotalPoints()
    {
        return _laborotoryWorks.Sum(l => l.NumberPoints) + _examPoints;
    }
}