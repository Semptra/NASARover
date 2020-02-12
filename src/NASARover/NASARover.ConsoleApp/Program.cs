namespace NASARover.ConsoleApp
{
    using System;
    using System.Collections.Generic;

    using NASARover.Core;
    using NASARover.Core.Interfaces;
    using NASARover.Core.Parsers;

    class Program
    {
        static void Main()
        {
            Console.Title = "NASA Rover simulator";
            Console.WriteLine("Welcome to NASA Rover simulator!");

            var plateau = GetPlateau();
            var numberOfRovers = GetNumberOfRovers();

            for (int i = 0; i < numberOfRovers; i++)
            {
                var rover = GetRover(plateau);
                var roverNumber = i + 1;
                var roverCommands = GetRoverCommands(roverNumber);
                ExecuteRoverCommands(roverCommands, rover, roverNumber);
            }
        }

        private static Plateau GetPlateau()
        {
            var plateauParser = new PlateauParser();

            while(true)
            {
                Console.Write("Enter plateau upper right coordinate: ");
                var coordinates = Console.ReadLine();

                try
                {
                    return plateauParser.ParseFromString(coordinates);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating plateau: {ex.Message}. Please try again.");
                }
            }
        }

        private static int GetNumberOfRovers()
        {
            var intParser = new IntParser();

            while (true)
            {
                Console.Write("Enter number of rovers: ");
                var numberOfRovers = Console.ReadLine();

                try
                {
                    return intParser.ParseGreaterThanZeroFromString(numberOfRovers);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting number of rovers: {ex.Message}. Please try again.");
                }
            }
        }

        private static Rover GetRover(IPlateau plateau)
        {
            var roverParser = new RoverParser();

            while (true)
            {
                Console.Write("Enter rover configuration (position and direction): ");
                var roverConfiguratuion = Console.ReadLine();

                try
                {
                    return roverParser.ParseFromString(roverConfiguratuion, plateau);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating rover: {ex.Message}. Please try again.");
                }
            }
        }

        private static List<IRoverCommand> GetRoverCommands(int roverNumber)
        {
            var movementPlanParser = new RoverMovementParser();

            while (true)
            {
                Console.Write($"Enter rover {roverNumber} movement plan: ");
                var movementPlan = Console.ReadLine();

                try
                {
                    return movementPlanParser.ParseFromString(movementPlan);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error moving the rover: {ex.Message}. Please try again.");
                }
            }
        }

        private static void ExecuteRoverCommands(IEnumerable<IRoverCommand> commands, IRover rover, int roverNumber)
        {
            try
            {
                foreach (var command in commands)
                {
                    rover.ExecuteCommand(command);
                }

                Console.WriteLine($"Rover {roverNumber} end position: [X: {rover.Position.X}, Y: {rover.Position.Y}, Direction: {rover.FaceDirection}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing rover commands: {ex.Message}.");
            }
        }
    }
}
