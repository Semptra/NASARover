namespace NASARover.Core.Parsers
{
    using System;

    using NASARover.Core.Models;

    public class PlateauParser
    {
        private readonly IntParser _intParser = new IntParser();

        public Plateau ParseFromString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            var coordinates = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            if (coordinates.Length != 2)
            {
                throw new ArgumentException($"Expected 2 coordinates separated by space, but got {coordinates.Length}.");
            }

            var x = _intParser.ParsePositiveFromString(coordinates[0]);
            var y = _intParser.ParsePositiveFromString(coordinates[1]);

            return new Plateau(new Point(x, y));
        }
    }
}
