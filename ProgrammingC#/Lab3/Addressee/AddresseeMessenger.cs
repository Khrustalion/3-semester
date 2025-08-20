using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessengerDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeMessenger : IAddressee
{
    private readonly IMessenger _messenger;

    public AddresseeMessenger(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendMessage(Message message)
    {
        try
        {
            _messenger.SendMessage(message);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e);
        }
    }
}