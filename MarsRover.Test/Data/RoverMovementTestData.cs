using Xunit;

namespace MarsRover.Test.Data
{
    public class RoverMovementTestData : TheoryData<RoverMovementTestParameter>
    {
        public RoverMovementTestData()
        {
            Add(new RoverMovementTestParameter("1 2 N", "LMLMLMLMM", "1 3 N", 5, 5));
            Add(new RoverMovementTestParameter("3 3 E", "MMRMMRMRRM", "5 1 E", 5, 5));
        }
    }
}
