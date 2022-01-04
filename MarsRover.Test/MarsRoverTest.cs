using MarsRover.Application.Services;
using MarsRover.Core.Domain;
using MarsRover.Test.Data;
using Xunit;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {
        [Theory]
        [InlineData(new object[] { "2 10", 2, 10 })]
        [InlineData(new object[] { "7 8", 7, 8 })]
        public void Be_Able_To_Parse_MarsPlateau_With_Coordinates(string upperCoordinatesLine, int xCoordinate, int yCoordinate)
        {
            var mars = MarsPlateau.Parse(upperCoordinatesLine);

            Assert.NotNull(mars);
            Assert.NotNull(mars.UpperRightCoordinate);

            var upperRightCoordinate = mars.UpperRightCoordinate;
            Assert.Equal(xCoordinate, upperRightCoordinate.X);
            Assert.Equal(yCoordinate, upperRightCoordinate.Y);
        }

        [Theory, ClassData(typeof(RoverMovementTestData))]
        public void Rovers_Last_Position_Should_Match_After_Instructions(RoverMovementTestParameter parameter)
        {
            var rover = RoverParser.ParseRover(parameter.PositionLine, parameter.InstructionsLine);
            Assert.NotNull(rover);

            var upperRightCoordinate = Coordinate.Of(parameter.UpperRightXCoordinate, parameter.UpperRightYCoordinate);
            rover.OperateInstructions(upperRightCoordinate);

            Assert.Equal(parameter.ExpectedPosition, rover.Position.ToString());
        }
    }
}