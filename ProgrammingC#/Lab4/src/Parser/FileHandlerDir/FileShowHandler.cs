using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Shower;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlerDir;

public class FileShowHandler : HandlerBase
{
    private const string Command = "show";
    private const string Flag = "-m";

    public FileShowHandler() { }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (!CanHandle(request))
            return NextHandler?.Handle(request);

        if (request.MoveNext() is false)
            return NextHandler?.Handle(request);
        string path = request.Current;

        if (request.MoveNext() is false || request.Current != Flag || request.MoveNext() is false)
            return NextHandler?.Handle(request);

        return new ShowCommand(path, new ConsoleShower());
    }

    private bool CanHandle(IEnumerator<string> request)
    {
        return request.Current == Command;
    }
}