using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Component;

public interface IComponent
{
    public void SendMessage(Message message);
}