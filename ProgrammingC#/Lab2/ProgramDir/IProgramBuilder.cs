using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramDir;

public interface IProgramBuilder<T, T1> where T : IProgramBuilder<T, T1>
                                        where T1 : AbstractProgram
{
    public T WithParentId(int? parentId);

    public T WithId(int id);

    public T WithName(string name);

    public T WithSubjects(Dictionary<int, List<AbstractSubject>> subjects);

    public T1 Build();
}