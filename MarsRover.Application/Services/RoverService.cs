using log4net;
using System.Reflection;

namespace MarsRover.Application.Services
{
    public class RoverService : IRoverService
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void Run()
        {
            _log.Warn("KEMAL EFE1");
            var inputLines = ReadInput();

            MarsPlateau mars = MarsPlateau.Create(inputLines.ToArray());
            mars.OperateRovers();

            var roverPositions = mars.GetRoversLastPositions();
            Console.WriteLine(roverPositions);
            _log.Warn("KEMAL EFE2");
        }

        private static List<string> ReadInput()
        {
            var lines = new List<string>();
            string? line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                lines.Add(line);
                line = Console.ReadLine();
            }

            return lines;
        }
    }
}
