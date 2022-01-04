using MarsRover.Core.Domain;
using System.Text;

namespace MarsRover.Application.Services
{
    public class MarsPlateau
    {
        public Coordinate UpperRightCoordinate { get; set; }
        public List<Rover> Rovers { get; set; }

        public MarsPlateau(Coordinate upperRightCoordinate)
        {
            UpperRightCoordinate = upperRightCoordinate;
            Rovers = new List<Rover>();
        }

        public void DeployRover(Rover roverToDeploy)
        {
            if (roverToDeploy == null)
            {
                throw new ArgumentNullException(nameof(roverToDeploy));
            }

            Rovers.Add(roverToDeploy);
        }

        public void OperateRovers()
        {
            Rovers.ForEach(rover => rover.OperateInstructions(UpperRightCoordinate));
        }

        public string GetRoversLastPositions()
        {
            StringBuilder sb = new();
            Rovers.ForEach(rover => sb.AppendLine(rover.Position.ToString()));
            return sb.ToString();
        }

        public static MarsPlateau Parse(string uppperRightCoordinate)
        {
            var upperRightCoordinate = ParseUpperRightCoordinate(uppperRightCoordinate);
            return new(upperRightCoordinate);
        }

        private static Coordinate ParseUpperRightCoordinate(string upperCoordinates)
        {
            if (upperCoordinates == null)
            {
                throw new ArgumentNullException(nameof(upperCoordinates));
            }

            string[] tokens = upperCoordinates.Split(' ');
            if (tokens.Length != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(upperCoordinates));
            }

            return Coordinate.Of(int.Parse(tokens[0]), int.Parse(tokens[1]));
        }
    }
}
