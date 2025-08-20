using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeGroup : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addresses;

    public AddresseeGroup(IReadOnlyCollection<IAddressee> addresses)
    {
        _addresses = addresses;
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee address in _addresses)
        {
            address.SendMessage(message);
        }
    }
}