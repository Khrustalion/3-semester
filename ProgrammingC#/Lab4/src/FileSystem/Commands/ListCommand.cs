using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public class ListCommand : ICommand, IEquatable<ListCommand>
{
    private readonly int _maxDepth;

    public ListCommand(int maxDepth)
    {
        _maxDepth = maxDepth;
    }

    public void Execute(ContextCommandBase contextCommand)
    {
        if (contextCommand.FileSystem is null) throw new InvalidOperationException("File System disconnected");

        var visitor = new ConsoleVisitor(_maxDepth);
        new FileSystemComponentFactory().Create(contextCommand.FileSystem.CurrentDirectory).Accept(visitor);
    }

    public bool Equals(ListCommand? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _maxDepth == other._maxDepth;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ListCommand)obj);
    }

    public override int GetHashCode()
    {
        return _maxDepth + 1;
    }
}