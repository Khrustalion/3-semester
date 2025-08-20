namespace Itmo.ObjectOrientedProgramming.Lab2.Materials;

public abstract class AbstractMaterials
{
    public abstract int? ParentId { get; }

    public abstract int Id { get; }

    public abstract string Name { get; protected set; }

    public abstract string? ShortDescription { get; protected set; }

    public abstract string Content { get; protected set; }

    public abstract User Author { get; }

    public abstract MaterialsResultTypes TryReplaceName(string newName, User user);

    public abstract MaterialsResultTypes TryReplaceShortDescription(string newShortDescription, User user);

    public abstract MaterialsResultTypes TryReplaceContent(string newContent, User user);
}