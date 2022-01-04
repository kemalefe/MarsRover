using MarsRover.Core.Domain;
using MarsRover.Core.Instruction;

namespace MarsRover.Application.Services
{
    public class RoverParser
    {
        public static Rover ParseRover(string positionLine, string instructionLine)
        {
            var roverPosition = ParseRoverPosition(positionLine);
            var roverInstructions = ParseRoverInstructions(instructionLine);
            return new Rover(roverPosition, roverInstructions);
        }

        private static Position ParseRoverPosition(string positionLine)
        {
            if (positionLine == null)
            {
                throw new ArgumentNullException("Invalid rover position input:" + positionLine);
            }

            string[] tokens = positionLine.Split(' ');
            if (tokens.Length != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(positionLine));
            }
            Position roverPosition = new(Coordinate.Of(int.Parse(tokens[0]), int.Parse(tokens[1])), tokens[2].ParseCardinalDirection());
            return roverPosition;
        }

        private static List<IRoverInstruction> ParseRoverInstructions(string instructionLine)
        {
            if (instructionLine == null)
            {
                throw new ArgumentNullException("Invalid rover instruction input:" + instructionLine);
            }

            var instructionChars = instructionLine.ToCharArray();
            var instructions = new List<IRoverInstruction>();
            foreach (var ch in instructionChars)
            {
                instructions.Add(ParseInstructionFromLetter(ch));
            }

            return instructions;
        }

        private static IRoverInstruction ParseInstructionFromLetter(char ch)
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
