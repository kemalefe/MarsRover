// See https://aka.ms/new-console-template for more information
using MarsRover.Service;


var inputLines = ReadInput();

MarsPlateau mars = MarsPlateau.Create(inputLines.ToArray());
var output = mars.OperateRovers();

Console.WriteLine(output);

static List<string> ReadInput()
{
    var lines = new List<string>();
    string? line;
    do
    {
        line = Console.ReadLine();
        try
        {
            if (!string.IsNullOrEmpty(line))
            {
                lines.Add(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }

    } while (!string.IsNullOrEmpty(line));
    return lines;
}
