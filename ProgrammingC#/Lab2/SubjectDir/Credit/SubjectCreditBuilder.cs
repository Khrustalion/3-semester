using Itmo.ObjectOrientedProgramming.Lab2.Materials;
using Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir.Credit;

public class SubjectCreditBuilder : ISubjectBuilder<SubjectCreditBuilder, SubjectCredit>
{
    private int? _parentId;
    private int? _id;
    private string? _name;
    private IReadOnlyCollection<LaboratoryWork> _laboratoryWorks;
    private IReadOnlyCollection<LectureMaterials> _lectureMaterials;
    private User? _author;
    private int? _minPoints;

    public SubjectCreditBuilder()
    {
        _parentId = null;
        _id = null;
        _name = null;
        _laboratoryWorks = new List<LaboratoryWork>();
        _lectureMaterials = new List<LectureMaterials>();
        _author = null;
    }

    public SubjectCreditBuilder WithParentId(int? parentId)
    {
        _parentId = parentId;

        return this;
    }

    public SubjectCreditBuilder WithId(int id)
    {
        _id = id;

        return this;
    }

    public SubjectCreditBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public SubjectCreditBuilder WithTasks(IReadOnlyCollection<LaboratoryWork> tasks)
    {
        _laboratoryWorks = tasks;

        return this;
    }

    public SubjectCreditBuilder WithMaterials(IReadOnlyCollection<LectureMaterials> materials)
    {
        _lectureMaterials = materials;

        return this;
    }

    public SubjectCreditBuilder WithAuthor(User author)
    {
        _author = author;

        return this;
    }

    public SubjectCreditBuilder WithAuthor(int authorId, string authorName)
    {
        _author = new User(authorId, authorName);

        return this;
    }

    public SubjectCreditBuilder WithMinPoints(int examPoints)
    {
        _minPoints = examPoints;

        return this;
    }

    public SubjectCredit Build()
    {
        if (TotalPoints() != 100) throw new InvalidOperationException("Total points must be 100");
        return new SubjectCredit(
            _parentId,
            _id ?? throw new ArgumentException("id must be fill", nameof(_id)),
            _name ?? throw new ArgumentException("name must be fill", nameof(_name)),
            _minPoints ?? throw new ArgumentException("minPoints must be fill", nameof(_minPoints)),
            _laboratoryWorks,
            _lectureMaterials,
            _author ?? throw new ArgumentException("author must be fill", nameof(_author)));
    }

    private int TotalPoints()
    {
        return _laboratoryWorks.Sum(l => l.NumberPoints);
    }
}