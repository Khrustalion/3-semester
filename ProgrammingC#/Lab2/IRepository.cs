namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface IRepository<T1, T2> where T2 : IRepository<T1, T2>
{
    public T2 AddItem(T1 item);

    public T1? FindItem(int id);

    public T1 GetItem(int id);
}