namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitor;

public class ConsoleVisitor : IFileSystemComponentVisitor
{
    private readonly int _maxDepth;
    private int _depth;

    public ConsoleVisitor(int maxDepth = 1)
    {
        _maxDepth = maxDepth;
    }

    public void Visit(FileFileSystemComponent component)
    {
        WriteIndented(component.Name, "| ");
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        WriteIndented(component.Name, "|-> ");

        _depth += 1;

        if (_depth <= _maxDepth)
        {
            foreach (IFileSystemComponent innerComponent in component.Components)
            {
                innerComponent.Accept(this);
            }
        }

        _depth -= 1;
    }

    private void WriteIndented(string value, string separator)
    {
        if (_depth is not 0)
        {
            Console.Write(string.Concat(Enumerable.Repeat("   ", _depth)));
            Console.Write(separator);
        }

        Console.WriteLine(value);
    }
}