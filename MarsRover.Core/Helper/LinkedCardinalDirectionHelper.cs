using MarsRover.Core.Domain;

namespace MarsRover.Core.Helper
{
    public class LinkedCardinalDirectionHelper
    {
        private static readonly CardinalDirection[] _directions = { CardinalDirection.NORTH, CardinalDirection.EAST, CardinalDirection.SOUTH, CardinalDirection.WEST };
        public static CardinalDirection FindRight(CardinalDirection direction)
        {
            var currentDirection = _directions.FirstOrDefault(x => x == direction);
            return direction;
        }
    }
}
