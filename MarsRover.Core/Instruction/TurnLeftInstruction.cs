using MarsRover.Core.Domain;
using MarsRover.Core.Helper;

namespace MarsRover.Core.Instruction
{
    public class TurnLeftInstruction : IRoverInstruction
    {
        public Position Operate(Position pos)
        {
            CardinalDirection cardinalDirection = pos.CardinalDirection;
            var linkedCardinalDirection = LinkedCardinalDirectionHelper.FindByDirection(cardinalDirection);
            if (linkedCardinalDirection != null)
            {
                pos.CardinalDirection = linkedCardinalDirection.Left;
            }

            return pos;
        }

        public override string ToString()
        {
            return "Turn Left";
        }
    }
}
