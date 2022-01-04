using System.Text;

namespace MarsRover.Core.Domain
{
    public class Position : ICloneable
    {
        private const char SPACE = ' ';

        public Coordinate Coordinate { get; set; }
        public CardinalDirection CardinalDirection { get; set; }

        public Position(Coordinate coordinate, CardinalDirection cardinalDirection)
        {
            Coordinate = coordinate;
            CardinalDirection = cardinalDirection;
        }

        public object Clone()
        {
            return new Position(new Coordinate(Coordinate.X, Coordinate.Y), CardinalDirection);
        }

        public override string ToString()
        {
            return new StringBuilder().Append(Coordinate.X).Append(SPACE).Append(Coordinate.Y).Append(SPACE).Append(CardinalDirection.ToLetterString()).ToString();
        }

    }
}
