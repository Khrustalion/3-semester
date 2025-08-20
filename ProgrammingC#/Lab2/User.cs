namespace Itmo.ObjectOrientedProgramming.Lab2;

public record User
{
    public int Id { get; private set;  }

    public string Name { get; private set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }
}