namespace NASARover.Core.Commands
{
    using NASARover.Core.Enums;
    using NASARover.Core.Interfaces;

    public class RotateRoverCommand : IRoverCommand
    {
        public RotateRoverCommand(Rotation rotation)
        {
            Rotation = rotation;
        }

        public Rotation Rotation { get; }
    }
}
