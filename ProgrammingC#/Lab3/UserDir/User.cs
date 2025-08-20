using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserDir;

public class User : IUser
{
    public IDictionary<Guid, UserMessage> Messages { get; }

    public User()
    {
        Messages = new Dictionary<Guid, UserMessage>();
    }

    public void SendMessage(Message message)
    {
        Messages.Add(message.Id, new UserMessage(message));
    }
}