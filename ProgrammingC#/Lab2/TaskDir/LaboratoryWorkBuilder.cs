namespace Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

public class LaboratoryWorkBuilder : ITaskBuilder<LaboratoryWorkBuilder, LaboratoryWork>
{
    private int? _parentId;
    private int? _id;
    private string? _name;
    private string? _description;
    private string? _evaluationCriteria;
    private int? _numberPoints;
    private User? _author;

    public LaboratoryWorkBuilder()
    {
        _parentId = null;
        _id = null;
        _name = null;
        _description = null;
        _evaluationCriteria = null;
        _numberPoints = null;
        _author = null;
    }

    public LaboratoryWorkBuilder WithParentId(int? parentId)
    {
        _parentId = parentId;
        return this;
    }

    public LaboratoryWorkBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public LaboratoryWorkBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public LaboratoryWorkBuilder WithDescription(string? description)
    {
        _description = description;
        return this;
    }

    public LaboratoryWorkBuilder WithEvaluationCriteria(string evaluationCriteria)
    {
        _evaluationCriteria = evaluationCriteria;
        return this;
    }

    public LaboratoryWorkBuilder WithNumberPoints(int numberPoints)
    {
        _numberPoints = numberPoints;
        return this;
    }

    public LaboratoryWorkBuilder WithAuthor(int authorId, string authorName)
    {
        _author = new User(authorId, authorName);
        return this;
    }

    public LaboratoryWorkBuilder WithAuthor(User author)
    {
        _author = author;
        return this;
    }

    public LaboratoryWork Build()
    {
        return new LaboratoryWork(
            _parentId,
            _id ?? throw new ArgumentException("id must be fill", nameof(_id)),
            _name ?? throw new ArgumentException("name must be fill", nameof(_name)),
            _description,
            _evaluationCriteria ?? throw new ArgumentException("evaluationCriteria must be fill", nameof(_evaluationCriteria)),
            _numberPoints ?? throw new ArgumentException("numberPoints must be fill", nameof(_numberPoints)),
            _author ?? throw new ArgumentException("author must be fill", nameof(_author)));
    }
}