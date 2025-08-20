using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeFilterDecorator : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly Importance _requiredImportance;

    public AddresseeFilterDecorator(IAddressee addressee, Importance requiredImportance)
    {
        _addressee = addressee;
        _requiredImportance = requiredImportance;
    }

    public void SendMessage(Message message)
    {
        if (message.Priority >= _requiredImportance)
        {
            _addressee.SendMessage(message);
        }
    }
}