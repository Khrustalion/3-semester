using Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramDir;

public class Program : AbstractProgram, IPrototype<Program>
{
    public override Dictionary<int, List<AbstractSubject>> Subjects { get; }

    public override int? ParentId { get; }

    public override int Id { get; }

    public override string Name { get; protected set; }

    public override User Director { get; }

    public Program(
        Dictionary<int, List<AbstractSubject>> subjects,
        int? parentId,
        int id,
        string name,
        User director)
    {
        Subjects = subjects;
        ParentId = parentId;
        Id = id;
        Name = name;
        Director = director;
        Subjects = new Dictionary<int, List<AbstractSubject>>();
    }

    public override ProgramResultTypes TryReplaceName(string newName, User user)
    {
        if (string.IsNullOrEmpty(newName)) throw new ArgumentException("New name cannot be null or empty.", nameof(newName));
        if (!CheckUserIsDirector(user)) return new ProgramResultTypes.UserIsNotDirector();

        Name = newName;
        return new ProgramResultTypes.Success();
    }

    public Program Clone(int id, User newDirector)
    {
        return new ProgramBuilder()
            .WithSubjects(Subjects)
            .WithParentId(Id)
            .WithId(id)
            .WithName(Name)
            .WithDirector(newDirector)
            .Build();
    }

    private bool CheckUserIsDirector(User user)
    {
        return user == Director;
    }
}
