using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlerDir;

public class FileCopyHandler : HandlerBase
{
    private const string Command = "copy";

    public FileCopyHandler() { }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (!CanHandle(request))
            return NextHandler?.Handle(request);

        if (request.MoveNext() is false)
            return NextHandler?.Handle(request);
        string sourcePath = request.Current;

        if (request.MoveNext() is false)
            return NextHandler?.Handle(request);
        string destinationPath = request.Current;

        return new CopyCommand(sourcePath, destinationPath);
    }

    private bool CanHandle(IEnumerator<string> request)
    {
        return request.Current == Command;
    }
}