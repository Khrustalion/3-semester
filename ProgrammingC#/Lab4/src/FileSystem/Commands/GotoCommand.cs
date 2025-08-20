using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public class GotoCommand : ICommand, IEquatable<GotoCommand>
{
    private readonly string _path;

    public GotoCommand(string path)
    {
        _path = path;
    }

    public void Execute(ContextCommandBase contextCommand)
    {
        if (contextCommand.FileSystem is null) throw new OperationCanceledException("File System disconnected");

        string absolutePath = contextCommand.FileSystem.GetAbsolutePath(_path) ?? string.Empty;

        if (!contextCommand.FileSystem.DirectoryExists(absolutePath)) throw new ArgumentException($"Directory {_path} doesn't exist");
        contextCommand.FileSystem.GotoDirectory(absolutePath);
    }

    public bool Equals(GotoCommand? other)
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
        return Equals((GotoCommand)obj);
    }

    public override int GetHashCode()
    {
        return _path.GetHashCode(System.StringComparison.Ordinal);
    }
}