using MarsRover.Core.Domain;

namespace MarsRover.Core.Helper
{
    public class LinkedCardinalDirectionHelper
    {
        private static readonly CardinalDirection[] _directions = { CardinalDirection.NORTH, CardinalDirection.EAST, CardinalDirection.SOUTH, CardinalDirection.WEST };
        public static CardinalDirection FindRight(CardinalDirection direction)
        {
            int index = Array.IndexOf(_directions, direction);
            int rightIndex = index + 1;
            if (rightIndex == _directions.Length)
            {
                rightIndex = 0;
            }
            return _directions[rightIndex];
        }

        public static CardinalDirection FindLeft(CardinalDirection direction)
        {
            int index = Array.IndexOf(_directions, direction);
            int rightIndex = index - 1;
            if (rightIndex == -1)
            {
                rightIndex = _directions.Length - 1;
            }
            return _directions[rightIndex];
        }
    }
}
