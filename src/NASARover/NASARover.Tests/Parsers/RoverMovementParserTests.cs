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
        public void ParseFromString_Valid_Tests(string input, Rover rover, string expected)
        {
            var actual = _parser.ParseFromString(input, rover);

            Assert.AreEqual(expected, actual);
        }

        static IEnumerable<TestCaseData> ParseFromStringValidData()
        {
            var plateau = new Plateau(new Point(5, 5));
            yield return new TestCaseData("LMLMLMLMM", new Rover(plateau, new Point(1, 2), Direction.North), "[Position: (X: 1, Y: 3), Direction: North]");
            yield return new TestCaseData("MMRMMRMRRM", new Rover(plateau, new Point(3, 3), Direction.East), "[Position: (X: 5, Y: 1), Direction: East]");
            yield return new TestCaseData("MLMRRMLM", new Rover(plateau, new Point(2, 1), Direction.West), "[Position: (X: 0, Y: 1), Direction: West]");
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringInvalidEmptyInputData))]
        public void ParseFromString_Invalid_Empty_Input_Tests(string input, Rover rover)
        {
            Assert.Throws<ArgumentNullException>(() => _parser.ParseFromString(input, rover));
        }

        static IEnumerable<TestCaseData> ParseFromStringInvalidEmptyInputData()
        {
            var plateau = new Plateau(new Point(5, 5));
            var position = new Point(0, 0);
            yield return new TestCaseData(null, new Rover(plateau, position, Direction.North));
            yield return new TestCaseData(string.Empty, new Rover(plateau, position, Direction.East));
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringInvalidData))]
        public void ParseFromString_Invalid_Tests(string input, Rover rover)
        {
            Assert.Throws<ArgumentException>(() => _parser.ParseFromString(input, rover));
        }

        static IEnumerable<TestCaseData> ParseFromStringInvalidData()
        {
            var plateau = new Plateau(new Point(5, 5));
            yield return new TestCaseData("MMLMMMM", new Rover(plateau, new Point(0, 0), Direction.North));
            yield return new TestCaseData("RMM", new Rover(plateau, new Point(5, 0), Direction.East));
            yield return new TestCaseData("MM", new Rover(plateau, new Point(0, 0), Direction.South));
        }
    }
}
