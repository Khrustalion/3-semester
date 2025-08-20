namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public class SubjectRepository : IRepository<AbstractSubject, SubjectRepository>
{
    private readonly List<AbstractSubject> _subjects;

    public SubjectRepository()
    {
        _subjects = new List<AbstractSubject>();
    }

    public SubjectRepository AddItem(AbstractSubject item)
    {
        if (FindItem(item.Id) is not null) return this;
        _subjects.Add(item);

        return this;
    }

    public AbstractSubject? FindItem(int id)
    {
        return _subjects.FirstOrDefault(subject => subject.Id == id);
    }

    public AbstractSubject GetItem(int id)
    {
        return _subjects.First(subject => subject.Id == id);
    }
}