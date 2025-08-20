using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeHandlerDir;

public class TreeListWithDepthHandler : HandlerBase
{
    private const string Flag = "-d";

    public TreeListWithDepthHandler() { }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (!CanHandle(request))
            return NextHandler?.Handle(request);

        if (request.MoveNext() is false)
            return NextHandler?.Handle(request);

        if (!int.TryParse(request.Current, out int depth))
            return NextHandler?.Handle(request);

        return new ListCommand(depth);
    }

    private bool CanHandle(IEnumerator<string> request)
    {
        return request.Current == Flag;
    }
}