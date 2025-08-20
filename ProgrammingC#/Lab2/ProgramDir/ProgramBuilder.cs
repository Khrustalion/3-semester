using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramDir;

public class ProgramBuilder : IProgramBuilder<ProgramBuilder, Program>
{
    private Dictionary<int, List<AbstractSubject>> _subjects;
    private int? _parentId;
    private int? _id;
    private string? _name;
    private User? _director;

    public ProgramBuilder()
    {
        _subjects = new Dictionary<int, List<AbstractSubject>>();
        _parentId = null;
        _id = null;
        _name = null;
        _director = null;
    }

    public ProgramBuilder WithSubjects(Dictionary<int, List<AbstractSubject>> subjects)
    {
        _subjects = subjects;

        return this;
    }

    public ProgramBuilder WithParentId(int? parentId)
    {
        _parentId = parentId;

        return this;
    }

    public ProgramBuilder WithId(int id)
    {
        _id = id;

        return this;
    }

    public ProgramBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public ProgramBuilder WithDirector(User director)
    {
        _director = director;

        return this;
    }

    public Program Build()
    {
        return new Program(
            _subjects,
            _parentId,
            _id ?? throw new ArgumentException("id must be fill", nameof(_id)),
            _name ?? throw new ArgumentException("name must be fill", nameof(_name)),
            _director ?? throw new ArgumentException("director must be fill", nameof(_director)));
    }
}