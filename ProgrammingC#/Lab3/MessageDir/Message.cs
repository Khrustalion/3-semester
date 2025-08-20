namespace Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

public class Message
{
    public Guid Id { get; private set; }

    public string Title { get; }

    public string Text { get; }

    public Importance Priority { get; }

    public Message(string title, string text, Importance priority)
    {
        Id = Guid.NewGuid();
        Title = title;
        Text = text;
        Priority = priority;
    }
}