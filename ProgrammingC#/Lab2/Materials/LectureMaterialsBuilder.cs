namespace Itmo.ObjectOrientedProgramming.Lab2.Materials;

public class LectureMaterialsBuilder : IMaterialsBuilder<LectureMaterialsBuilder, LectureMaterials>
{
    private int? _parentId;
    private int? _id;
    private string? _name;
    private string? _shortDescription;
    private string? _content;
    private User? _author;

    public LectureMaterialsBuilder()
    {
        _parentId = null;
        _id = null;
        _name = null;
        _shortDescription = null;
        _content = null;
    }

    public LectureMaterialsBuilder WithParentId(int? parentId)
    {
        _parentId = parentId;

        return this;
    }

    public LectureMaterialsBuilder WithId(int id)
    {
        _id = id;

        return this;
    }

    public LectureMaterialsBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public LectureMaterialsBuilder WithAuthor(int authorId, string authorName)
    {
        _author = new User(authorId, authorName);

        return this;
    }

    public LectureMaterialsBuilder WithShortDescription(string? shortDescription)
    {
        _shortDescription = shortDescription;

        return this;
    }

    public LectureMaterialsBuilder WithContent(string content)
    {
        _content = content;

        return this;
    }

    public LectureMaterialsBuilder WithAuthor(User user)
    {
        _author = user;

        return this;
    }

    public LectureMaterials Build()
    {
        return new LectureMaterials(
            _parentId,
            _id ?? throw new ArgumentException("id must be fill", nameof(_id)),
            _name ?? throw new ArgumentException("name cannot be null", nameof(_name)),
            _shortDescription,
            _content ?? throw new ArgumentException("content cannot be null", nameof(_content)),
            _author ?? throw new ArgumentException("author cannot be null", nameof(_author)));
    }
}