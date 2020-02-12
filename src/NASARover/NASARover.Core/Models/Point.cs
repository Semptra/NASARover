namespace NASARover.Core.Models
{
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Point point))
            {
                return false;
            }

            return this.X == point.X && this.Y == point.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString()
        {
            return $"(X: {X}, Y: {Y})";
        }
    }
}
