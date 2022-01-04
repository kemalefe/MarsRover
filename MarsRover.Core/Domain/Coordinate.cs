namespace MarsRover.Core.Domain
{
    public class Coordinate
    {
        public static readonly Coordinate Zero = new(0, 0);
        public int X { get; set; }
        public int Y { get; set; }

        private Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate Of(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException($"Invalid coordinates:{ nameof(x)} {nameof(y)}");
            }
            return new(x, y);
        }

        public bool InBoundaries(Coordinate boundary)
        {
            return X <= boundary.X && Y <= boundary.Y;
        }
    }
}