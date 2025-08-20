namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public abstract class FileSystemBase : IFileSystem, IEquatable<FileSystemBase>
{
    public string CurrentDirectory { get; protected set; } = string.Empty;

    public abstract string? GetAbsolutePath(string path);

    public abstract void GotoDirectory(string path);

    public abstract bool DirectoryExists(string? path);

    public abstract bool FileExists(string? path);

    public abstract void Copy(string sourcePath, string destinationPath);

    public abstract void Move(string sourcePath, string destinationPath);

    public abstract void Delete(string path);

    public abstract string ReadFile(string path);

    public bool Equals(FileSystemBase? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return CurrentDirectory == other.CurrentDirectory;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((FileSystemBase)obj);
    }

    public override int GetHashCode()
    {
        return CurrentDirectory.GetHashCode(StringComparison.Ordinal);
    }
}