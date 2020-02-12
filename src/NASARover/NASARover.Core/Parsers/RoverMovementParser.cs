namespace NASARover.Core.Parsers
{
    using System;
    using System.Collections.Generic;

    using NASARover.Core.Commands;
    using NASARover.Core.Enums;
    using NASARover.Core.Interfaces;

    public class RoverMovementParser
    {
        public List<IRoverCommand> ParseFromString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            var commands = new List<IRoverCommand>();

            for (int i = 0; i < input.Length; i++)
            {
                var action = input[i];

                IRoverCommand command = action switch
                {
                    'M' => new MoveRoverCommand(),
                    'L' => new RotateRoverCommand(Rotation.Left),
                    'R' => new RotateRoverCommand(Rotation.Right),
                    _ => throw new ArgumentException($"Invalid action {action} at {i}")
                };

                commands.Add(command);
            }

            return commands;
        }
    }
}
