namespace MarsRover.Domain
{
    public interface IRoverInstruction
    {
        public Position Operate(Position pos);
    }
}
