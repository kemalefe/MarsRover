using MarsRover.Core.Domain;

namespace MarsRover.Core.Instruction
{
    public class MoveInstruction : IRoverInstruction
    {
        public Position Operate(Position pos)
        {
            Coordinate coordinate = pos.Coordinate;
            switch (pos.CardinalDirection)
            {
                case CardinalDirection.NORTH:
                    coordinate.Y++;
                    break;
                case CardinalDirection.EAST:
                    coordinate.X++;
                    break;
                case CardinalDirection.SOUTH:
                    coordinate.Y--;
                    break;
                case CardinalDirection.WEST:
                    coordinate.X--;
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
