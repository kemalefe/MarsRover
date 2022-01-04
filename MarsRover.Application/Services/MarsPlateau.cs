using MarsRover.Core.Domain;
using System.Text;

namespace MarsRover.Application.Services
{
    public class MarsPlateau
    {
        private readonly Coordinate _upperRightCoordinate;
        private readonly List<Rover> _rovers;

        public MarsPlateau(Coordinate upperRightCoordinate)
        {
            _upperRightCoordinate = upperRightCoordinate;
            _rovers = new List<Rover>();
        }

        public void DeployRover(Rover roverToDeploy)
        {
            if (roverToDeploy == null)
            {
                throw new ArgumentNullException(nameof(roverToDeploy));
            }

            _rovers.Add(roverToDeploy);
        }

        public void OperateRovers()
        {
            _rovers.ForEach(rover => rover.Operate(_upperRightCoordinate));
        }

        public string GetRoversLastPositions()
        {
            StringBuilder sb = new();
            _rovers.ForEach(rover => sb.AppendLine(rover.Position.ToString()));
            return sb.ToString();
        }

        public static MarsPlateau Create(string[] lines)
        {
            int lineNum = 0;
            Coordinate upperRightCoordinate = ParseUpperRightCoordinate(lines[lineNum++]);
            MarsPlateau mars = new(upperRightCoordinate);

            while (lineNum < lines.Length)
            {
                var roverPosition = lines[lineNum++];
                var instructionLine = lines[lineNum++];
                Rover rover = RoverFactory.CreateRover(roverPosition, instructionLine);
                mars.DeployRover(rover);
            }

            return mars;
        }

        private static Coordinate ParseUpperRightCoordinate(string upperCoordinates)
        {
            if (upperCoordinates == null)
            {
                throw new ArgumentNullException(nameof(upperCoordinates));
            }

            string[] tokens = upperCoordinates.Split(' ');
            
            return new Coordinate(int.Parse(tokens[0]), int.Parse(tokens[1]));
        }
    }
}
