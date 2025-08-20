using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public class ConnectCommand : ICommand, IEquatable<ConnectCommand>
{
    private readonly string _absolutePath;

    public ConnectCommand(string absolutePath)
    {
        _absolutePath = absolutePath;
    }

    public void Execute(ContextCommandBase contextCommand)
    {
        if (!contextCommand.Connect(_absolutePath))
            throw new ArgumentException($"Directory {_absolutePath} doesn't exist");
    }

    public bool Equals(ConnectCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _absolutePath == other._absolutePath;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ConnectCommand)obj);
    }

    public override int GetHashCode()
    {
        return _absolutePath.GetHashCode(System.StringComparison.Ordinal);
    }
}