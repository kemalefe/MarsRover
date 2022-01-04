namespace MarsRover.Core.Domain
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool InBoundaries(Coordinate boundary)
        {
            return X <= boundary.X && Y <= boundary.Y;
        }
    }
}