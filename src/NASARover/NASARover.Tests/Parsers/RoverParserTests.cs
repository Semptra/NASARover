namespace NASARover.Tests.Parsers
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using NASARover.Core;
    using NASARover.Core.Parsers;
    using NASARover.Core.Models;
    using NASARover.Core.Interfaces;
    using NASARover.Core.Enums;

    [TestFixture]
    public class RoverParserTests
    {
        private RoverParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new RoverParser();
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringValidData))]
        public void ParseFromString_Valid_Tests(string input, IPlateau plateau, Rover expected)
        {
            var actual = _parser.ParseFromString(input, plateau);

            Assert.AreEqual(expected.Position, actual.Position);
            Assert.AreEqual(expected.FaceDirection, actual.FaceDirection);
            Assert.AreEqual(expected.Plateau.BottomLeftPosition, actual.Plateau.BottomLeftPosition);
            Assert.AreEqual(expected.Plateau.TopRightPoistion, actual.Plateau.TopRightPoistion);
        }

        static IEnumerable<TestCaseData> ParseFromStringValidData()
        {
            var plateau = new Plateau(new Point(10, 10));
            yield return new TestCaseData("0 0 N", plateau, new Rover(plateau, new Point(0, 0), Direction.North));
            yield return new TestCaseData("10 10 North", plateau, new Rover(plateau, new Point(10, 10), Direction.North));
            yield return new TestCaseData("1 2 E", plateau, new Rover(plateau, new Point(1, 2), Direction.East));
            yield return new TestCaseData("2 1 East", plateau, new Rover(plateau, new Point(2, 1), Direction.East));
            yield return new TestCaseData("5 5 S", plateau, new Rover(plateau, new Point(5, 5), Direction.South));
            yield return new TestCaseData("5 5 South", plateau, new Rover(plateau, new Point(5, 5), Direction.South));
            yield return new TestCaseData("9 8 W", plateau, new Rover(plateau, new Point(9, 8), Direction.West));
            yield return new TestCaseData("8 9 West", plateau, new Rover(plateau, new Point(8, 9), Direction.West));
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringInvalidPositionData))]
        public void ParseFromString_Invalid_Position_Tests(string input, IPlateau plateau)
        {
            Assert.Throws<ArgumentException>(() => _parser.ParseFromString(input, plateau));
        }

        static IEnumerable<TestCaseData> ParseFromStringInvalidPositionData()
        {
            var plateau = new Plateau(new Point(10, 10));
            yield return new TestCaseData("-1 0 N", plateau);
            yield return new TestCaseData("0 -1 North", plateau);
            yield return new TestCaseData("-1 -1 E", plateau);
            yield return new TestCaseData("11 0 East", plateau);
            yield return new TestCaseData("0 11 S", plateau);
            yield return new TestCaseData("11 11 South", plateau);
        }
    }
}
