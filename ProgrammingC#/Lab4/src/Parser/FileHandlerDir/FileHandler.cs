using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlerDir;

public class FileHandler : HandlerBase
{
    private const string Command = "file";
    private readonly IHandler? _nextNegativeHandler;

    public FileHandler(IHandler? nextNegativeHandler = null)
    {
        _nextNegativeHandler = nextNegativeHandler;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (!CanHandle(request))
            return _nextNegativeHandler?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        return NextHandler?.Handle(request);
    }

    private bool CanHandle(IEnumerator<string> request)
    {
        return request.Current == Command;
    }
}