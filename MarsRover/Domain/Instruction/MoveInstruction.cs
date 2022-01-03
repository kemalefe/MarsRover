namespace MarsRover.Domain
{
    public class MoveInstruction : IRoverInstruction
    {
        public Position Operate(Position pos)
        {
            CardinalDirection direction = pos.CardinalDirection;
            switch (direction)
            {
                case CardinalDirection.NORTH:
                    pos.Coordinate.Y++;
                    break;
                case CardinalDirection.EAST:
                    pos.Coordinate.X++;
                    break;
                case CardinalDirection.SOUTH:
                    pos.Coordinate.Y--;
                    break;
                case CardinalDirection.WEST:
                    pos.Coordinate.X--;
                    break;
                default:
                    break;
            }

            return pos;
        }

        public override string ToString()
        {
            return "Move";
        }
    }
}
