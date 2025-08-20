using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;
    private readonly Color _color;

    public Display(IDisplayDriver displayDriver, Color color)
    {
        _displayDriver = displayDriver;
        _color = color;
    }

    public void SendMessage(Message message)
    {
        _displayDriver.Clear();
        _displayDriver.SetColor(_color);
        _displayDriver.WriteMessage($"{Crayon.Output.Bold(message.Title)}\n{message.Text}");
    }
}