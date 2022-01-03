namespace MarsRover.Domain
{
    public class TurnLeftInstruction : IRoverInstruction
    {
        public Position Operate(Position pos)
        {
            CardinalDirection cardinalDirection = pos.CardinalDirection;
            switch (cardinalDirection)
            {
                case CardinalDirection.NORTH:
                    pos.CardinalDirection = CardinalDirection.WEST;
                    break;
                case CardinalDirection.EAST:
                    pos.CardinalDirection = CardinalDirection.NORTH;
                    break;
                case CardinalDirection.SOUTH:
                    pos.CardinalDirection = CardinalDirection.EAST;
                    break;
                case CardinalDirection.WEST:
                    pos.CardinalDirection = CardinalDirection.SOUTH;
                    break;
            }
            return pos;
        }

        public override string ToString()
        {
            return "Turn Left";
        }
    }
}
