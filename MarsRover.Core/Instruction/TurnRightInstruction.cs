using MarsRover.Core.Domain;
using MarsRover.Core.Helper;

namespace MarsRover.Core.Instruction
{
    public class TurnRightInstruction : IRoverInstruction
    {
        public Position Operate(Position pos)
        {
            var leftDirection = LinkedCardinalDirectionHelper.FindRight(pos.CardinalDirection);
            pos.CardinalDirection = leftDirection;
            return pos;
        }

        public override string ToString()
        {
            return "Turn Right";
        }
    }
}
