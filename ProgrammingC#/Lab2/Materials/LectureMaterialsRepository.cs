namespace Itmo.ObjectOrientedProgramming.Lab2.Materials;

public class LectureMaterialsRepository : IRepository<LectureMaterials, LectureMaterialsRepository>
{
    private readonly List<LectureMaterials> _lectureMaterialsList;

    public LectureMaterialsRepository()
    {
        _lectureMaterialsList = new List<LectureMaterials>();
    }

    public LectureMaterialsRepository AddItem(LectureMaterials item)
    {
        if (FindItem(item.Id) is not null) return this;
        _lectureMaterialsList.Add(item);

        return this;
    }

    public LectureMaterials? FindItem(int id)
    {
        return _lectureMaterialsList.FirstOrDefault(l => l.Id == id);
    }

    public LectureMaterials GetItem(int id)
    {
        return _lectureMaterialsList.First(l => l.Id == id);
    }
}