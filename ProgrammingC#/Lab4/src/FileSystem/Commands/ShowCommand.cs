using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Shower;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public class ShowCommand : ICommand, IEquatable<ShowCommand>
{
    private readonly string _path;
    private readonly IShower _shower;

    public ShowCommand(string path, IShower shower)
    {
        _path = path;
        _shower = shower;
    }

    public void Execute(ContextCommandBase contextCommand)
    {
        if (contextCommand.FileSystem is null) throw new InvalidOperationException("File System disconnected");

        string? pathAbsolute = contextCommand.FileSystem.GetAbsolutePath(_path);
        if (pathAbsolute is null || !contextCommand.FileSystem.FileExists(pathAbsolute))
            throw new ArgumentException("Path doesn't exist");

        _shower.Show(contextCommand.FileSystem.ReadFile(pathAbsolute));
    }

    public bool Equals(ShowCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _path == other._path;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ShowCommand)obj);
    }

    public override int GetHashCode()
    {
        return _path.GetHashCode(System.StringComparison.Ordinal);
    }
}