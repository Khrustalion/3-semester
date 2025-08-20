using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;

public interface ICommand
{
    public void Execute(ContextCommandBase contextCommand);
}