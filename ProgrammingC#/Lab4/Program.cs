using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.DirectorFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the commands (push the  Ctrl+Z to complete):");

        string? input;

        IHandler handler = new LocalFileSystemHandlerDirector().BuildHandler();

        var context = new ContextLocalFileSystemCommandBase();

        while ((input = Console.ReadLine()) is not null)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("An empty line, try again.");
                continue;
            }

            IEnumerator<string> request = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .GetEnumerator();

            request.MoveNext();

            ICommand? command = handler.Handle(request);

            if (command is null)
            {
                Console.WriteLine("Invalid command. Try again.");
            }
            else
            {
                try
                {
                    command.Execute(context);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        Console.WriteLine("The application is completed.");
    }
}