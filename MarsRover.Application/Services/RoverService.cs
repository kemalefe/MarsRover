using MarsRover.Core.Domain;
using System.Text;

namespace MarsRover.Application.Services
{
    public class RoverService
    {
        public void Run()
        {
            Console.InputEncoding = Encoding.UTF8;
            using StreamReader reader = new(Console.OpenStandardInput(), Console.InputEncoding);

            string? stdin = reader.ReadLine();
            if (string.IsNullOrEmpty(stdin))
            {
                Console.WriteLine("No input entered. Exiting...");
                return;
            }

            MarsPlateau mars = MarsPlateau.Parse(stdin);
            string? positionLine, instructionLine;
            do
            {
                positionLine = reader.ReadLine();
                instructionLine = reader.ReadLine();
                if (string.IsNullOrEmpty(instructionLine) || string.IsNullOrEmpty(positionLine))
                {
                    break;
                }

                try
                {
                    Rover rover = RoverParser.ParseRover(positionLine, instructionLine);
                    mars.DeployRover(rover);
                    rover.OperateInstructions(mars.UpperRightCoordinate);
                    Console.WriteLine(rover.Position.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error occurred:{ e.Message }");
                }

            } while (!string.IsNullOrEmpty(positionLine) && !string.IsNullOrEmpty(instructionLine));
        }
    }
}
