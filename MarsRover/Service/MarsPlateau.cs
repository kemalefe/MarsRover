using MarsRover.Domain;
using System.Text;

namespace MarsRover.Service
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

        public void AddRover(Rover roverToAdd)
        {
            if (roverToAdd == null)
            {
                throw new ArgumentNullException(nameof(roverToAdd));
            }

            _rovers.Add(roverToAdd);
        }

        public static MarsPlateau Create(string[] lines)
        {
            Coordinate upperRightCoordinate = ParseUpperRightCoordinate(lines[0]);
            MarsPlateau mars = new MarsPlateau(upperRightCoordinate);

            int lineNum = 1;
            while (lineNum < lines.Length)
            {
                var roverPosition = lines[lineNum++];
                var instructionLine = lines[lineNum++];
                Rover rover = RoverFactory.CreateRover(roverPosition, instructionLine);
                mars.AddRover(rover);
            }

            return mars;
        }

        private static Coordinate ParseUpperRightCoordinate(string upperCoordinates)
        {
            if (upperCoordinates == null)
            {
                throw new ArgumentNullException("upperCoordinates");
            }

            string[] tokens = upperCoordinates.Split(' ');
            return new Coordinate(int.Parse(tokens[0]), int.Parse(tokens[1]));
        }

        public string OperateRovers()
        {
            StringBuilder sb = new();
            foreach (var rover in _rovers)
            {
                var position = rover.Operate(_upperRightCoordinate);
                sb.AppendLine(position.ToString());
            }
            return sb.ToString();
        }
    }
}
