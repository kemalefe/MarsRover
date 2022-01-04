namespace MarsRover.Core.Domain
{
    public enum CardinalDirection
    {
        NORTH, EAST, SOUTH, WEST
    }

    public static class PositionDirectionExtensions
    {
        public static CardinalDirection ParseCardinalDirection(this string letter)
        {
            if (string.IsNullOrEmpty(letter))
            {
                throw new ArgumentOutOfRangeException(nameof(letter));
            }

            return letter switch
            {
                "N" => CardinalDirection.NORTH,
                "E" => CardinalDirection.EAST,
                "S" => CardinalDirection.SOUTH,
                "W" => CardinalDirection.WEST,
                _ => throw new ArgumentOutOfRangeException(nameof(letter)),
            };
        }

        public static string ToLetterString(this CardinalDirection direction)
        {
            return direction switch
            {
                CardinalDirection.NORTH => "N",
                CardinalDirection.EAST => "E",
                CardinalDirection.SOUTH => "S",
                CardinalDirection.WEST => "W",
                _ => "UNDEFINED"
            };
        }

    }

}

