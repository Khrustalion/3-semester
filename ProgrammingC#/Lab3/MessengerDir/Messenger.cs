using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessengerDir;

public class Messenger : IMessenger
{
    private Message? _message;

    public Messenger()
    {
        _message = null;
    }

    public void SendMessage(Message message)
    {
        _message = message;
    }

    public void ShowMessage()
    {
        if (_message == null) throw new InvalidOperationException("Message cannot be null");

        Console.WriteLine($"{_message.Title}\n{_message.Text}\nMessanger");
    }
}