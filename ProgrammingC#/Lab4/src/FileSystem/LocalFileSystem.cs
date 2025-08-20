namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalFileSystem : FileSystemBase
{
    private readonly string _absoluteDirectory;

    public LocalFileSystem(string absoluteDirectory)
    {
        _absoluteDirectory = absoluteDirectory;
        CurrentDirectory = absoluteDirectory;
    }

    public override string? GetAbsolutePath(string path)
    {
        if (PathExistAbsolute(path))
            return Path.Combine(_absoluteDirectory, path);

        if (PathExist(path))
            return Path.Combine(_absoluteDirectory, CurrentDirectory, path);

        return null;
    }

    public override void GotoDirectory(string path)
    {
        string? absolutePath = GetAbsolutePath(path);

        if (!Directory.Exists(absolutePath))
            throw new ArgumentException($"Directory {path} does not exist.");

        CurrentDirectory = absolutePath;
    }

    public override bool DirectoryExists(string? path)
    {
        return Directory.Exists(path);
    }

    public override bool FileExists(string? path)
    {
        return File.Exists(path);
    }

    public override void Copy(string sourcePath, string destinationPath)
    {
        if (FileExists(destinationPath))
            Copy(sourcePath, CreateCopyPath(destinationPath));
        else
            File.Copy(sourcePath, destinationPath);
    }

    public override void Move(string sourcePath, string destinationPath)
    {
        if (FileExists(destinationPath))
            Move(sourcePath, CreateCopyPath(destinationPath));
        else
            File.Move(sourcePath, destinationPath);
    }

    public override void Delete(string path)
    {
        File.Delete(path);
    }

    public override string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }

    private string CreateCopyPath(string path)
    {
        string directory = Path.GetDirectoryName(path) ?? string.Empty; // Получаем директорию
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path); // Имя файла без расширения
        string extension = Path.GetExtension(path); // Расширение файла

        return Path.Combine(directory, $"{fileNameWithoutExtension} - copy{extension}");
    }

    private bool PathExistAbsolute(string path)
    {
        string absolutePath = Path.Combine(_absoluteDirectory, path);
        return File.Exists(absolutePath) || Directory.Exists(absolutePath);
    }

    private bool PathExist(string path)
    {
        string absolutePath = Path.Combine(_absoluteDirectory, CurrentDirectory, path);
        return File.Exists(absolutePath) || Directory.Exists(absolutePath);
    }
}