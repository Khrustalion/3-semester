namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitor;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}