using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlerDir;

public class FileDeleteHandler : HandlerBase
{
    private const string Command = "delete";

    public FileDeleteHandler() { }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (!CanHandle(request))
            return NextHandler?.Handle(request);

        if (request.MoveNext() is false)
            return NextHandler?.Handle(request);
        string path = request.Current;

        return new DeleteCommand(path);
    }

    private bool CanHandle(IEnumerator<string> request)
    {
        return request.Current == Command;
    }
}