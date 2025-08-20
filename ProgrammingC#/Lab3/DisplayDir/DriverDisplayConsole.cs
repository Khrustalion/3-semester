using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

public class DriverDisplayConsole : IDisplayDriver
{
    private Color _color;

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void WriteMessage(string message)
    {
        Console.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message));
    }
}