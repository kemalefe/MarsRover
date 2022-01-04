namespace MarsRover.Test.Data
{
    public class RoverMovementTestParameter
    {
        public string PositionLine { get; set; }
        public string InstructionsLine { get; set; }
        public string ExpectedPosition { get; set; }
        public int UpperRightXCoordinate { get; set; }
        public int UpperRightYCoordinate { get; set; }

        public RoverMovementTestParameter(string positionLine, string instructionsLine, string expectedPosition, int upperRightXCoordinate, int upperRightYCoordinate)
        {
            PositionLine = positionLine;
            InstructionsLine = instructionsLine;
            ExpectedPosition = expectedPosition;
            UpperRightXCoordinate = upperRightXCoordinate;
            UpperRightYCoordinate = upperRightYCoordinate;
        }
    }
}
