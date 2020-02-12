namespace NASARover.Tests.Parsers
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using NASARover.Core;
    using NASARover.Core.Enums;
    using NASARover.Core.Parsers;
    using NASARover.Core.Models;

    [TestFixture]
    public class RoverMovementParserTests
    {
        private RoverMovementParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new RoverMovementParser();
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringValidData))]
        public void ParseFromString_Valid_Tests(string input, Rover rover, Rover expected)
        {
            var commands = _parser.ParseFromString(input);

            foreach(var command in commands)
            {
                rover.ExecuteCommand(command);
            }

            Assert.AreEqual(rover.Position, expected.Position);
            Assert.AreEqual(rover.FaceDirection, expected.FaceDirection);
        }

        static IEnumerable<TestCaseData> ParseFromStringValidData()
        {
            var plateau = new Plateau(new Point(5, 5));
            yield return new TestCaseData("LMLMLMLMM", new Rover(plateau, new Point(1, 2), Direction.North), new Rover(plateau, new Point(1, 3), Direction.North));
            yield return new TestCaseData("MMRMMRMRRM", new Rover(plateau, new Point(3, 3), Direction.East), new Rover(plateau, new Point(5, 1), Direction.East));
            yield return new TestCaseData("MLMRRMLM", new Rover(plateau, new Point(2, 1), Direction.West), new Rover(plateau, new Point(0, 1), Direction.West));
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringInvalidEmptyInputData))]
        public void ParseFromString_Invalid_Empty_Input_Tests(string input)
        {
            Assert.Throws<ArgumentNullException>(() => _parser.ParseFromString(input));
        }

        static IEnumerable<TestCaseData> ParseFromStringInvalidEmptyInputData()
        {
            yield return new TestCaseData(null);
            yield return new TestCaseData(string.Empty);
        }
    }
}
