namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    public string? GetAbsolutePath(string path);

    public void GotoDirectory(string path);

    public bool DirectoryExists(string? path);

    public bool FileExists(string? path);

    public void Copy(string sourcePath, string destinationPath);

    public void Move(string sourcePath, string destinationPath);

    public void Delete(string path);

    public string ReadFile(string path);
}