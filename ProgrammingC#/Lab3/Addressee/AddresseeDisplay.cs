using Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeDisplay : IAddressee
{
    private readonly IDisplay _display;

    public AddresseeDisplay(IDisplay display)
    {
        _display = display;
    }

    public void SendMessage(Message message)
    {
        _display.SendMessage(message);
    }
}