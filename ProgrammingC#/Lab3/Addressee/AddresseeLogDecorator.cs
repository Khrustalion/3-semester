using Itmo.ObjectOrientedProgramming.Lab3.LoggerDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeLogDecorator : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public AddresseeLogDecorator(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void SendMessage(Message message)
    {
        _logger.Log(message.Text);
        _addressee.SendMessage(message);
    }
}