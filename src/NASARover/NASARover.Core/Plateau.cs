namespace NASARover.Core
{
    using System;
    using NASARover.Core.Models;

    public class Plateau
    {
        public Point BottomLeftPosition { get; }

        public Point TopRightPoistion { get; }

        public Plateau(Point topRightPosition) : this(new Point(0, 0), topRightPosition) { }

        public Plateau(Point bottomLeftPosition, Point topRightPosition)
        {
            if (bottomLeftPosition.X > topRightPosition.X)
            {
                throw new ArgumentException($"Bottom left X ({bottomLeftPosition.X}) is greater than top right X ({topRightPosition.X})");
            }

            if (bottomLeftPosition.Y > topRightPosition.Y)
            {
                throw new ArgumentException($"Bottom left Y ({bottomLeftPosition.Y}) is greater than top right Y ({topRightPosition.Y})");
            }

            BottomLeftPosition = bottomLeftPosition;
            TopRightPoistion = topRightPosition;
        }

        public bool IsValidPosition(Point position)
        {
            return IsPointInsidePlateau(position);
        }

        private bool IsPointInsidePlateau(Point point)
        {
            return point.X >= BottomLeftPosition.X &&
                   point.Y >= BottomLeftPosition.Y &&
                   point.X <= TopRightPoistion.X &&
                   point.Y <= TopRightPoistion.Y;
        }
    }
}
