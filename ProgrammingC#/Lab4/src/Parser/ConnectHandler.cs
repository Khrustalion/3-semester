using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class ConnectHandler : HandlerBase
{
    private const string Command = "connect";
    private const string Flag = "-m";
    private const string Mode = "local";

    public ConnectHandler() { }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (!CanHandle(request))
            return NextHandler?.Handle(request);

        if (request.MoveNext() is false)
            return NextHandler?.Handle(request);
        string filePath = request.Current;

        if (request.MoveNext() is false || request.Current != Flag || request.MoveNext() is false || request.Current != Mode)
            return NextHandler?.Handle(request);

        return new ConnectCommand(filePath);
    }

    private bool CanHandle(IEnumerator<string> request)
    {
        return request.Current == Command;
    }
}