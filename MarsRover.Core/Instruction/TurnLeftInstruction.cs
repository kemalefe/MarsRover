using MarsRover.Core.Domain;
using MarsRover.Core.Helper;

namespace MarsRover.Core.Instruction
{
    public class TurnLeftInstruction : IRoverInstruction
    {
        public Position Operate(Position pos)
        {
            var leftDirection = LinkedCardinalDirectionHelper.FindLeft(pos.CardinalDirection);
            pos.CardinalDirection = leftDirection;
            return pos;
        }

        public override string ToString()
        {
            return "Turn Left";
        }
    }
}
