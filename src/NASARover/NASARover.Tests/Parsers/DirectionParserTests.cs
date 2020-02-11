namespace NASARover.Tests.Parsers
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using NASARover.Core.Enums;
    using NASARover.Core.Parsers;
   
    [TestFixture]
    public class DirectionParserTests
    {
        private DirectionParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new DirectionParser();
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringValidData))]
        public void ParseFromString_Valid_Tests(string input, Direction expected)
        {
            var actual = _parser.ParseFromString(input);

            Assert.AreEqual(expected, actual);
        }

        static IEnumerable<TestCaseData> ParseFromStringValidData()
        {
            yield return new TestCaseData("North", Direction.North);
            yield return new TestCaseData("N", Direction.North);
            yield return new TestCaseData("n", Direction.North);
            yield return new TestCaseData("East", Direction.East);
            yield return new TestCaseData("E", Direction.East);
            yield return new TestCaseData("e", Direction.East);
            yield return new TestCaseData("South", Direction.South);
            yield return new TestCaseData("S", Direction.South);
            yield return new TestCaseData("s", Direction.South);
            yield return new TestCaseData("West", Direction.West);
            yield return new TestCaseData("W", Direction.West);
            yield return new TestCaseData("w", Direction.West);
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
