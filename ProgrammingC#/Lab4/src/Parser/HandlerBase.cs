using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public abstract class HandlerBase : IHandler
{
    protected IHandler? NextHandler { get; private set; } = null;

    public IHandler AddNext(IHandler handler)
    {
        if (NextHandler is null)
        {
            NextHandler = handler;
        }
        else
        {
            NextHandler.AddNext(handler);
        }

        return this;
    }

    public abstract ICommand? Handle(IEnumerator<string> request);
}