namespace Itmo.ObjectOrientedProgramming.Lab3.LoggerDir;

public class Logger : ILogger
{
    private readonly string _filePath;

    public Logger(string filePath)
    {
        _filePath = filePath;
    }

    public void Log(string message)
    {
        string logMessage = $"[{DateTime.Now:HH:mm:ss}] {message}";
        using var writer = new StreamWriter(_filePath, append: true);
        writer.WriteLine(logMessage);
    }
}