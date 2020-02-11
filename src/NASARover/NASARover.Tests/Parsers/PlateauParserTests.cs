namespace NASARover.Tests.Parsers
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using NASARover.Core;
    using NASARover.Core.Parsers;
    using NASARover.Core.Models;
    
    [TestFixture]
    public class PlateauParserTests
    {
        private PlateauParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new PlateauParser();
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringValidData))]
        public void ParseFromString_Valid_Tests(string input, Plateau expected)
        {
            var actual = _parser.ParseFromString(input);

            Assert.AreEqual(expected.BottomLeftPosition, actual.BottomLeftPosition);
            Assert.AreEqual(expected.TopRightPoistion, actual.TopRightPoistion);
        }

        static IEnumerable<TestCaseData> ParseFromStringValidData()
        {
            yield return new TestCaseData("0 0", new Plateau(new Point(0, 0)));
            yield return new TestCaseData("5 10", new Plateau(new Point(5, 10)));
            yield return new TestCaseData("2147483647 2147483647", new Plateau(new Point(int.MaxValue, int.MaxValue)));
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringInalidEmptyInputData))]
        public void ParseFromString_Inalid_Empty_Input_Tests(string input)
        {
            Assert.Throws<ArgumentNullException>(() => _parser.ParseFromString(input));
        }

        static IEnumerable<TestCaseData> ParseFromStringInalidEmptyInputData()
        {
            yield return new TestCaseData(null);
            yield return new TestCaseData(string.Empty);
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringInalidNumberOfCoordinatesData))]
        public void ParseFromString_Inalid_Number_Of_Coordinates_Tests(string input)
        {
            Assert.Throws<ArgumentException>(() => _parser.ParseFromString(input));
        }

        static IEnumerable<TestCaseData> ParseFromStringInalidNumberOfCoordinatesData()
        {
            yield return new TestCaseData("1 2 3");
            yield return new TestCaseData("0");
            yield return new TestCaseData("0 X Y");
            yield return new TestCaseData("0 10 20 40");
        }

        [Test]
        [TestCaseSource(nameof(ParseFromStringInalidCoordinatesData))]
        public void ParseFromString_Inalid_Coordinates_Tests(string input)
        {
            Assert.Throws<ArgumentException>(() => _parser.ParseFromString(input));
        }

        static IEnumerable<TestCaseData> ParseFromStringInalidCoordinatesData()
        {
            yield return new TestCaseData("0 -1");
            yield return new TestCaseData("-1 0");
            yield return new TestCaseData("-1 -1");
            yield return new TestCaseData("-2147483648 -2147483648");
            yield return new TestCaseData("1 Y");
            yield return new TestCaseData("X 1");
            yield return new TestCaseData("X Y");
        }
    }
}
