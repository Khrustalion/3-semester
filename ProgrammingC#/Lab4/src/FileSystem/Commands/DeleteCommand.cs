using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public class DeleteCommand : ICommand, IEquatable<DeleteCommand>
{
    private readonly string _path;

    public DeleteCommand(string path)
    {
        _path = path;
    }

    public void Execute(ContextCommandBase contextCommand)
    {
        if (contextCommand.FileSystem is null) throw new InvalidOperationException("File System disconnected");

        string? pathAbsolute = contextCommand.FileSystem.GetAbsolutePath(_path);
        if (pathAbsolute is null || !contextCommand.FileSystem.FileExists(pathAbsolute))
            throw new ArgumentException("Path doesn't exist");

        contextCommand.FileSystem.Delete(pathAbsolute);
    }

    public bool Equals(DeleteCommand? other)
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
        return Equals((DeleteCommand)obj);
    }

    public override int GetHashCode()
    {
        return _path.GetHashCode(System.StringComparison.Ordinal);
    }
}