namespace Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

public interface ITaskBuilder<T, T1>
        where T : ITaskBuilder<T, T1>
        where T1 : AbstractTask
{
    public T WithParentId(int? parentId);

    public T WithId(int id);

    public T WithName(string name);

    public T WithDescription(string? description);

    public T WithEvaluationCriteria(string evaluationCriteria);

    public T WithNumberPoints(int numberPoints);

    public T WithAuthor(int authorId, string authorName);

    public T WithAuthor(User author);

    public T1 Build();
}