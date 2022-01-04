using MarsRover.Core.Domain;

namespace MarsRover.Core.Instruction
{
    public interface IRoverInstruction
    {
        public Position Operate(Position pos);
    }
}
