using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeHandlerDir;

public class TreeListHandler : HandlerBase
{
    private const string Command = "list";

    public TreeListHandler() { }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (!CanHandle(request))
            return NextHandler?.Handle(request);

        if (request.MoveNext() is not false)
            return NextHandler?.Handle(request);

        return new ListCommand(1);
    }

    private bool CanHandle(IEnumerator<string> request)
    {
        return request.Current == Command;
    }
}