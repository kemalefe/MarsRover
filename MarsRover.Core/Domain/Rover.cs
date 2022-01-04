using log4net;
using MarsRover.Core.Instruction;

namespace MarsRover.Core.Domain
{
    public class Rover
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(Rover));

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

        public void OperateInstructions(Coordinate upperRightCoordinate)
        {
            foreach (IRoverInstruction instruction in _instructions)
            {
                _log.Debug($"Executing instruction: {instruction}");

                var positionToOperate = new Position(Position.Coordinate.X, Position.Coordinate.Y, Position.CardinalDirection);

                Position newPosition = instruction.Operate(positionToOperate);
                _log.Debug($"New position: {newPosition}");

                if (newPosition.Coordinate.InBoundaries(upperRightCoordinate) && Coordinate.Zero.InBoundaries(newPosition.Coordinate))
                {
                    // Maybe an execution exception can be thrown else case in here.
                    Position = newPosition;
                }
            }
        }
    }
}
