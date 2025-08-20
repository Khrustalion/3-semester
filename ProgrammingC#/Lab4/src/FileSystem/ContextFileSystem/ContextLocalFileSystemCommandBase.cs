using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.ContextFileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.DirectorFileSystem;

public class ContextLocalFileSystemCommandBase : ContextCommandBase
{
    public override bool Connect(string path)
    {
        FileSystemBase fileSystemBase = new LocalFileSystem(string.Empty);

        if (fileSystemBase.GetAbsolutePath(path) is null || !fileSystemBase.DirectoryExists(path))
            return false;

        FileSystem = new LocalFileSystem(path);

        return true;
    }
}