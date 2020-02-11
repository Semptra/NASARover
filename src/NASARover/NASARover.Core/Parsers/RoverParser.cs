namespace NASARover.Core.Parsers
{
    using System;

    using NASARover.Core.Interfaces;
    using NASARover.Core.Models;

    public class RoverParser
    {
        private readonly IntParser _intParser = new IntParser();

        private readonly DirectionParser _directionParser = new DirectionParser();

        public Rover ParseFromString(string input, IPlateau plateau)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            var arguments = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (arguments.Length != 3)
            {
                throw new ArgumentException($"Expected 2 coordinates and direction separated by space, but got {arguments.Length}");
            }

            var x = _intParser.ParsePositiveFromString(arguments[0]);
            var y = _intParser.ParsePositiveFromString(arguments[1]);

            var position = new Point(x, y);

            if (!plateau.IsValidPosition(position))
            {
                throw new ArgumentException($"Position {position} is not valid for given plateau");
            }

            var direction = _directionParser.ParseFromString(arguments[2]);

            return new Rover(plateau, position, direction);
        }
    }
}
