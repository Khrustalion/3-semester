namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public interface ISubjectBuilder<T, T1> where T : ISubjectBuilder<T, T1>
                                        where T1 : AbstractSubject
{
    public T WithParentId(int? parentId);

    public T WithId(int id);

    public T WithName(string name);

    public T WithAuthor(User author);

    public T WithAuthor(int authorId, string authorName);

    public T1 Build();
}