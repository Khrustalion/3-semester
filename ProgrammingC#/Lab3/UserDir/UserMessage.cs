using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserDir;

public class UserMessage
{
    public Message Message { get; }

    public bool Read { get; private set; }

    public UserMessage(Message message)
    {
        Message = message;
        Read = false;
    }

    public void ReadMessage()
    {
        if (Read) throw new InvalidOperationException("Message is already read.");

        Read = true;
    }
}