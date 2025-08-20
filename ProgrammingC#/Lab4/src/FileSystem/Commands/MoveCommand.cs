using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public class MoveCommand : ICommand, IEquatable<MoveCommand>
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public MoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute(ContextCommandBase contextCommand)
    {
        if (contextCommand.FileSystem is null) throw new InvalidOperationException("File System disconnected");

        string? sourcePathAbsolute = contextCommand.FileSystem.GetAbsolutePath(_sourcePath);
        if (sourcePathAbsolute is null || !contextCommand.FileSystem.FileExists(sourcePathAbsolute))
            throw new ArgumentException("Source path doesn't exist");

        string? destPathAbsolute = contextCommand.FileSystem.GetAbsolutePath(_destinationPath);
        if (destPathAbsolute is null || !contextCommand.FileSystem.DirectoryExists(destPathAbsolute))
            throw new ArgumentException("Destination path doesn't exist");

        destPathAbsolute = Path.Combine(destPathAbsolute, Path.GetFileName(_sourcePath));
        contextCommand.FileSystem.Move(sourcePathAbsolute, destPathAbsolute);
    }

    public bool Equals(MoveCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _sourcePath == other._sourcePath && _destinationPath == other._destinationPath;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((MoveCommand)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_sourcePath, _destinationPath);
    }
}