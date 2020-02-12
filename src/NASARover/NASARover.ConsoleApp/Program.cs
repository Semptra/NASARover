namespace NASARover.ConsoleApp
{
    using System;

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
                var roverEndPosition = GetRoverEndPosition(roverNumber, rover);
                Console.WriteLine($"Rover {roverNumber} end position: {roverEndPosition}");
            }
        }

        private static string GetRoverEndPosition(int roverNumber, IRover rover)
        {
            var movementPlanParser = new RoverMovementParser();

            while (true)
            {
                Console.Write($"Enter rover {roverNumber} movement plan: ");
                var movementPlan = Console.ReadLine();

                try
                {
                    return movementPlanParser.ParseFromString(movementPlan, rover);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error moving the rover: {ex.Message}. Please try again.");
                }
            }
        }

        static Plateau GetPlateau()
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

        static int GetNumberOfRovers()
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

        static Rover GetRover(IPlateau plateau)
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
    }
}
