using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public class DisconnectCommand : ICommand, IEquatable<DisconnectCommand>
{
    public void Execute(ContextCommandBase contextCommand)
    {
        contextCommand.Disconnect();
    }

    public bool Equals(DisconnectCommand? other)
    {
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((DisconnectCommand)obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}