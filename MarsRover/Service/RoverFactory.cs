using MarsRover.Domain;

namespace MarsRover.Service
{
    public class RoverFactory
    {
        public static Rover CreateRover(string positionLine, string instructionLine)
        {
            var roverPosition = CreateRoverPosition(positionLine);
            var roverInstructions = CreateRoverInstructions(instructionLine);
            return new Rover(roverPosition, roverInstructions);
        }

        private static Position CreateRoverPosition(string positionLine)
        {
            if (positionLine == null)
            {
                throw new ArgumentNullException("Invalid rover position input:" + positionLine);
            }

            string[] tokens = positionLine.Split(' ');
            Position roverPosition = new(new Coordinate(int.Parse(tokens[0]), int.Parse(tokens[1])), tokens[2].ParseCardinalDirection());
            return roverPosition;
        }

        private static List<IRoverInstruction> CreateRoverInstructions(string instructionLine)
        {
            if (instructionLine == null)
            {
                throw new ArgumentNullException("Invalid rover instruction input:" + instructionLine);
            }

            var instructionChars = instructionLine.ToCharArray();
            var instructions = new List<IRoverInstruction>();
            foreach (var ch in instructionChars)
            {
                instructions.Add(CreateInstructionFromLetter(ch));
            }

            return instructions;
        }

        private static IRoverInstruction CreateInstructionFromLetter(char ch)
        {
            return ch switch
            {
                'M' => new MoveInstruction(),
                'R' => new TurnRightInstruction(),
                'L' => new TurnLeftInstruction(),
                _ => throw new ArgumentException("Invalid instruction: " + ch),
            };
        }
    }
}
