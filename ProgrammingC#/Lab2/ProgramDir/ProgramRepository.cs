namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramDir;

public class ProgramRepository : IRepository<Program, ProgramRepository>
{
    private readonly List<Program> _programs;

    public ProgramRepository()
    {
        _programs = new List<Program>();
    }

    public ProgramRepository AddItem(Program item)
    {
        if (FindItem(item.Id) is not null) return this;

        _programs.Add(item);
        return this;
    }

    public Program? FindItem(int id)
    {
        return _programs.FirstOrDefault(program => program.Id == id);
    }

    public Program GetItem(int id)
    {
        return _programs.First(program => program.Id == id);
    }
}