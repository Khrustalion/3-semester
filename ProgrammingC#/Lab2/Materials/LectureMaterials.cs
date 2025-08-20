namespace Itmo.ObjectOrientedProgramming.Lab2.Materials;

public class LectureMaterials : AbstractMaterials, IMaterialsPrototype<LectureMaterials>
{
    public override int? ParentId { get; }

    public override int Id { get; }

    public override string Name { get; protected set; }

    public override string? ShortDescription { get; protected set; }

    public override string Content { get; protected set; }

    public override User Author { get; }

    public LectureMaterials(
        int? parentId,
        int id,
        string name,
        string? shortDescription,
        string content,
        User author)
    {
        ParentId = parentId;
        Id = id;
        Name = name;
        ShortDescription = shortDescription;
        Content = content;
        Author = author;
    }

    public override MaterialsResultTypes TryReplaceName(string newName, User user)
    {
        if (!CheckUserIsAuthor(user)) return new MaterialsResultTypes.UserIsNotAuthor();
        if (string.IsNullOrEmpty(newName)) throw new ArgumentException("New name cannot be null or empty.", nameof(newName));

        Name = newName;
        return new MaterialsResultTypes.Success();
    }

    public override MaterialsResultTypes TryReplaceShortDescription(string newShortDescription, User user)
    {
        if (string.IsNullOrEmpty(newShortDescription)) throw new ArgumentException("New short description cannot be null or empty.", nameof(newShortDescription));
        if (!CheckUserIsAuthor(user)) return new MaterialsResultTypes.UserIsNotAuthor();

        ShortDescription = newShortDescription;
        return new MaterialsResultTypes.Success();
    }

    public override MaterialsResultTypes TryReplaceContent(string newContent, User user)
    {
        if (string.IsNullOrEmpty(newContent)) throw new ArgumentException("New content cannot be null or empty.", nameof(newContent));
        if (!CheckUserIsAuthor(user)) return new MaterialsResultTypes.UserIsNotAuthor();

        return new MaterialsResultTypes.Success();
    }

    public LectureMaterials Clone(int newId, User newAuthor)
    {
        return new LectureMaterialsBuilder()
            .WithParentId(Id)
            .WithId(newId)
            .WithName(Name)
            .WithShortDescription(ShortDescription)
            .WithContent(Content)
            .WithAuthor(newAuthor)
            .Build();
    }

    private bool CheckUserIsAuthor(User user)
    {
        return user == Author;
    }
}