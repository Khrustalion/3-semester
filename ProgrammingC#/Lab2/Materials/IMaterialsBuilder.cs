namespace Itmo.ObjectOrientedProgramming.Lab2.Materials;

public interface IMaterialsBuilder<T, T1> where T : IMaterialsBuilder<T, T1>
                                            where T1 : AbstractMaterials
{
    public T WithParentId(int? parentId);

    public T WithId(int id);

    public T WithName(string name);

    public T WithShortDescription(string? shortDescription);

    public T WithContent(string content);

    public T WithAuthor(User user);

    public T WithAuthor(int authorId, string authorName);

    public T1 Build();
}