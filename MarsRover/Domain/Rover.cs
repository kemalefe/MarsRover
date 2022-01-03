namespace MarsRover.Domain
{
    public class Rover
    {
        public Position Position { get; set; }
        private readonly List<IRoverInstruction> _instructions;

        public Rover(Position position, List<IRoverInstruction> instructions)
        {
            Position = position;
            _instructions = instructions;
        }

        public void AddInstruction(IRoverInstruction instruction)
        {
            if (instruction == null)
            {
                throw new ArgumentNullException(nameof(instruction));
            }

            _instructions.Add(instruction);
        }

        public Position Operate(Coordinate upperRightCoordinate)
        {
            foreach (IRoverInstruction instruction in _instructions)
            {
                Console.WriteLine($"Executing instruction: {instruction}"); 

                var copyPos = (Position)Position.Clone();

                Position? newPosition = instruction.Operate(copyPos);
                Console.WriteLine($"New position: {newPosition}");

                if (newPosition.Coordinate.InBoundaries(upperRightCoordinate))
                {
                    // Maybe an execution exception can be thrown else case in here.
                    Position = copyPos;
                }
            }
            return Position;
        }
    }
}
