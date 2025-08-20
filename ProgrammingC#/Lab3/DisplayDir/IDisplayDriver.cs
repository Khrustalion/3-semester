using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

public interface IDisplayDriver
{
    public void Clear();

    public void SetColor(Color color);

    public void WriteMessage(string message);
}