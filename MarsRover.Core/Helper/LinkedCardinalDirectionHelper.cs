using MarsRover.Core.Domain;

namespace MarsRover.Core.Helper
{
    public class LinkedCardinalDirectionHelper
    {
        // Dictionary<CardinalDirection, Tuple<RightCardinalDirection, LeftCardinalDirection>>
        private static readonly Dictionary<CardinalDirection, Tuple<CardinalDirection, CardinalDirection>> _directionMap;
        static LinkedCardinalDirectionHelper()
        {
            _directionMap = new Dictionary<CardinalDirection, Tuple<CardinalDirection, CardinalDirection>>();
            _directionMap.Add(CardinalDirection.NORTH, Tuple.Create(CardinalDirection.EAST, CardinalDirection.WEST));
            _directionMap.Add(CardinalDirection.EAST, Tuple.Create(CardinalDirection.SOUTH, CardinalDirection.NORTH));
            _directionMap.Add(CardinalDirection.SOUTH, Tuple.Create(CardinalDirection.WEST, CardinalDirection.EAST));
            _directionMap.Add(CardinalDirection.WEST, Tuple.Create(CardinalDirection.NORTH, CardinalDirection.SOUTH));
        }

        public static CardinalDirection FindRight(CardinalDirection direction)
        {
            Tuple<CardinalDirection, CardinalDirection>? tuple = GetTuple(direction);
            return tuple.Item1;
        }

        public static CardinalDirection FindLeft(CardinalDirection direction)
        {
            Tuple<CardinalDirection, CardinalDirection>? tuple = GetTuple(direction);
            return tuple.Item2;
        }

        private static Tuple<CardinalDirection, CardinalDirection> GetTuple(CardinalDirection direction)
        {
            var tuple = _directionMap.GetValueOrDefault(direction);
            if (tuple == null)
            {
                throw new KeyNotFoundException(nameof(direction));
            }

            return tuple;
        }
    }
}
