using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlerDir;

public class FileRenameHandler : HandlerBase
{
    private const string Command = "rename";

    public FileRenameHandler() { }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (!CanHandle(request))
            return NextHandler?.Handle(request);

        if (request.MoveNext() is false)
            return NextHandler?.Handle(request);
        string path = request.Current;

        if (request.MoveNext() is false)
            return NextHandler?.Handle(request);

        string name = request.Current;

        return new RenameCommand(path, name);
    }

    private bool CanHandle(IEnumerator<string> request)
    {
        return request.Current == Command;
    }
}