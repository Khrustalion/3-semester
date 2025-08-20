using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Component;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicDir;

public class Topic : IComponent
{
    private readonly IReadOnlyCollection<IAddressee> _addresses;

    public Topic(IReadOnlyCollection<IAddressee> addresses)
    {
        _addresses = addresses;
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee addressee in _addresses)
        {
            addressee.SendMessage(message);
        }
    }
}