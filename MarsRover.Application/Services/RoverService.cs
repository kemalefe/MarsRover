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

            Console.WriteLine("Enter plateau surface upper coordinates:");
            string? stdin = Console.ReadLine();
            if (string.IsNullOrEmpty(stdin))
            {
                Console.WriteLine("No input entered. Exiting...");
                return;
            }

            MarsPlateau mars = MarsPlateau.Parse(stdin);
            string? positionLine, instructionLine;
            do
            {
                Console.WriteLine("Enter rover position:");
                positionLine = reader.ReadLine();
                Console.WriteLine("Enter rover instructions:");
                instructionLine = reader.ReadLine();
                if (string.IsNullOrEmpty(instructionLine) || string.IsNullOrEmpty(positionLine))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                Rover rover = RoverParser.ParseRover(positionLine, instructionLine);
                mars.DeployRover(rover);
                // rover.OperateInstructions(mars.UpperRightCoordinate);
                // Console.WriteLine(rover.Position.ToString());

                Console.WriteLine("Do you want to add rover? (y/n)");
                var answer = reader.ReadLine();
                if (!string.Equals(answer, "y", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

            } while (!string.IsNullOrEmpty(positionLine) && !string.IsNullOrEmpty(instructionLine));

            mars.OperateRovers();
            Console.WriteLine(mars.GetRoversLastPositions());
        }
    }
}
