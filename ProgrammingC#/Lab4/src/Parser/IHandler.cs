using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface IHandler
{
    public IHandler AddNext(IHandler handler);

    public ICommand? Handle(IEnumerator<string> request);
}