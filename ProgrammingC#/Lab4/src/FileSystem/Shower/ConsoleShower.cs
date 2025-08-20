namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Shower;

public class ConsoleShower : IShower
{
    public void Show(string fileText)
    {
        Console.Write(fileText);
    }
}