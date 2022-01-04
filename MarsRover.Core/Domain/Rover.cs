using MarsRover.Core.Instruction;

namespace MarsRover.Core.Domain
{
    public class Rover
    {
       // private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Position Position { get; set; }
        private readonly List<IRoverInstruction> _instructions;

        public Rover(Position position)
        {
            Position = position;
            _instructions = new List<IRoverInstruction>();
        }

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
                //_log.Error($"Executing instruction: {instruction}");

                var copyPos = (Position)Position.Clone();

                Position newPosition = instruction.Operate(copyPos);
                //_log.Error($"New position: {newPosition}");

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
