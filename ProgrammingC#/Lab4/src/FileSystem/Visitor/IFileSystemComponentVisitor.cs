namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitor;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component);

    void Visit(DirectoryFileSystemComponent component);
}