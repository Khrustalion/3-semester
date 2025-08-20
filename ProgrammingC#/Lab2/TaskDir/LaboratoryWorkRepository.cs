namespace Itmo.ObjectOrientedProgramming.Lab2.TaskDir;

public class LaboratoryWorkRepository : IRepository<LaboratoryWork, LaboratoryWorkRepository>
{
    private readonly List<LaboratoryWork> _laboratoryWorks;

    public LaboratoryWorkRepository()
    {
        _laboratoryWorks = new List<LaboratoryWork>();
    }

    public LaboratoryWorkRepository AddItem(LaboratoryWork item)
    {
        if (FindItem(item.Id) is not null) return this;
        _laboratoryWorks.Add(item);
        return this;
    }

    public LaboratoryWork? FindItem(int id)
    {
        return _laboratoryWorks.FirstOrDefault(l => l.Id == id);
    }

    public LaboratoryWork GetItem(int id)
    {
        return _laboratoryWorks.First(l => l.Id == id);
    }
}