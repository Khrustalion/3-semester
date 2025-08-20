using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class DisconnectHandler : HandlerBase
{
    private const string Command = "disconnect";

    public DisconnectHandler() { }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (!CanHandle(request))
            return NextHandler?.Handle(request);

        if (request.MoveNext() is not false)
            return NextHandler?.Handle(request);

        return new DisconnectCommand();
    }

    private bool CanHandle(IEnumerator<string> request)
    {
        return request.Current == Command;
    }
}