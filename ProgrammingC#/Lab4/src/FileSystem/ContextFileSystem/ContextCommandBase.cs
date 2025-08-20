namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;

public abstract class ContextCommandBase
{
    public FileSystemBase? FileSystem { get; protected set; }

    public abstract bool Connect(string path);

    public void Disconnect()
    {
        FileSystem = null;
    }
}