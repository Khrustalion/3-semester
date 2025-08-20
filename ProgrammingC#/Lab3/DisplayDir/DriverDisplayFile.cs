using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

public class DriverDisplayFile : IDisplayDriver
{
    private readonly string _filePath;
    private Color _color;

    public DriverDisplayFile(string filePath)
    {
        _filePath = filePath;
        _color = Color.Black;
    }

    public void Clear()
    {
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void WriteMessage(string message)
    {
        using var writer = new StreamWriter(_filePath);
        writer.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message));
    }
}