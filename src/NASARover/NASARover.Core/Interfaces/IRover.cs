namespace NASARover.Core.Interfaces
{
    using NASARover.Core.Enums;
    using NASARover.Core.Models;

    public interface IRover
    {
        Point Position { get; }

        Direction FaceDirection { get; }

        IPlateau Plateau { get; }

        void Move();

        void Rotate(Rotation rotation);

        void ExecuteCommand(IRoverCommand command);
    }
}
