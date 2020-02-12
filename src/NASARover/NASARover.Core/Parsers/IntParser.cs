namespace NASARover.Core.Parsers
{
    using System;

    public class IntParser
    {
        public int ParsePositiveFromString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (!int.TryParse(input, out var result))
            {
                throw new ArgumentException($"Cannot parse input {input} to int.");
            }

            if (result < 0)
            {
                throw new ArgumentException($"Input {result} must be greater than zero.");
            }

            return result;
        }

        public int ParseGreaterThanZeroFromString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (!int.TryParse(input, out var result))
            {
                throw new ArgumentException($"Cannot parse input {input} to int.");
            }

            if (result <= 0)
            {
                throw new ArgumentException($"Input {result} must be greater or equals to zero.");
            }

            return result;
        }
    }
}
