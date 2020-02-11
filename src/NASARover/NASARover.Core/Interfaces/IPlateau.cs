namespace NASARover.Core.Interfaces
{
    using NASARover.Core.Models;

    public interface IPlateau
    {
        Point BottomLeftPosition { get; }

        Point TopRightPoistion { get; }

        bool IsValidPosition(Point position);
    }
}
