namespace MarsRover.Domain
{
    public class TurnRightInstruction : IRoverInstruction
    {
        public Position Operate(Position pos)
        {
            CardinalDirection cardinalDirection = pos.CardinalDirection;
            switch (cardinalDirection)
            {
                case CardinalDirection.NORTH:
                    pos.CardinalDirection = CardinalDirection.EAST;
                    break;
                case CardinalDirection.EAST:
                    pos.CardinalDirection = CardinalDirection.SOUTH;
                    break;
                case CardinalDirection.SOUTH:
                    pos.CardinalDirection = CardinalDirection.WEST;
                    break;
                case CardinalDirection.WEST:
                    pos.CardinalDirection = CardinalDirection.NORTH;
                    break;
            }
            return pos;
        }

        public override string ToString()
        {
            return "Turn Right";
        }
    }
}
