namespace NASARover.Core.Parsers
{
    using System;

    using NASARover.Core.Enums;
    
    public class DirectionParser
    {
        public Direction ParseFromString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (Enum.TryParse<Direction>(input, true, out var direction))
            {
                return direction;
            }

            return input.ToUpperInvariant() switch
            {
                "N" => Direction.North,
                "E" => Direction.East,
                "S" => Direction.South,
                "W" => Direction.West,
                _ => throw new ArgumentException($"Cannot parse input ({input}) to Direction")
            };
        }
    }
}
