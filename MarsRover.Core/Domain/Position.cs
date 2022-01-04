using System.Text;

namespace MarsRover.Core.Domain
{
    public class Position
    {
        private const char SPACE = ' ';

        public Coordinate Coordinate { get; set; }
        public CardinalDirection CardinalDirection { get; set; }

        public Position(Coordinate coordinate, CardinalDirection cardinalDirection)
        {
            Coordinate = coordinate;
            CardinalDirection = cardinalDirection;
        }

        public Position(int x, int y, CardinalDirection cardinalDirection)
        {
            Coordinate = Coordinate.Of(x, y);
            CardinalDirection = cardinalDirection;
        }

        public override string ToString()
        {
            return new StringBuilder().Append(Coordinate.X).Append(SPACE).Append(Coordinate.Y).Append(SPACE).Append(CardinalDirection.ToLetterString()).ToString();
        }

    }
}
