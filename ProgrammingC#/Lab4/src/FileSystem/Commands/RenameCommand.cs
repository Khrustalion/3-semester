using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public class RenameCommand : ICommand, IEquatable<RenameCommand>
{
    private readonly string _path;
    private readonly string _newName;

    public RenameCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public void Execute(ContextCommandBase contextCommand)
    {
        if (contextCommand.FileSystem is null) throw new InvalidOperationException("File System disconnected");

        string? sourcePathAbsolute = contextCommand.FileSystem.GetAbsolutePath(_path);
        if (sourcePathAbsolute is null || !contextCommand.FileSystem.FileExists(sourcePathAbsolute))
            throw new ArgumentException("Source path doesn't exist");

        string destinationPathAbsolute = Path.Combine(Path.GetDirectoryName(sourcePathAbsolute) ?? string.Empty, _newName);

        contextCommand.FileSystem.Move(sourcePathAbsolute, destinationPathAbsolute);
    }

    public bool Equals(RenameCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _path == other._path && _newName == other._newName;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((RenameCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path, _newName);
    }
}