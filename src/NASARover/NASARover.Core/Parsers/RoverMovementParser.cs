namespace NASARover.Core.Parsers
{
    using System;

    using NASARover.Core.Enums;
    using NASARover.Core.Interfaces;

    public class RoverMovementParser
    {
        public string ParseFromString(string input, IRover rover)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            for (int i = 0; i < input.Length; i++)
            {
                var action = input[i];

                switch(action)
                {
                    case 'M':
                        rover.Move();
                        break;
                    case 'L':
                        rover.Rotate(Rotation.Left);
                        break;
                    case 'R':
                        rover.Rotate(Rotation.Right);
                        break;
                    default:
                        throw new ArgumentException($"Invalid action {action} at {i}");
                }
            }

            return $"[Position: ({rover.Position}), Direction: {rover.FaceDirection}]";
        }
    }
}
