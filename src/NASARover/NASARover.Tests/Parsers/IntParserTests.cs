namespace NASARover.Tests.Parsers
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using NASARover.Core.Parsers;

    [TestFixture]
    public class IntParserTests
    {
        private IntParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new IntParser();
        }

        [Test]
        [TestCaseSource(nameof(ParsePositiveFromStringValidData))]
        public void ParsePositiveFromString_Valid_Tests(string input, int expected)
        {
            var actual = _parser.ParsePositiveFromString(input);

            Assert.AreEqual(expected, actual);
        }

        static IEnumerable<TestCaseData> ParsePositiveFromStringValidData()
        {
            yield return new TestCaseData("1", 1);
            yield return new TestCaseData("42", 42);
            yield return new TestCaseData("2147483647", int.MaxValue);
        }

        [Test]
        [TestCaseSource(nameof(ParsePositiveFromStringInvalidEmptyInputData))]
        public void ParsePositiveFromString_Invalid_Empty_Input_Tests(string input)
        {
            Assert.Throws<ArgumentNullException>(() => _parser.ParsePositiveFromString(input));
        }

        static IEnumerable<TestCaseData> ParsePositiveFromStringInvalidEmptyInputData()
        {
            yield return new TestCaseData(null);
            yield return new TestCaseData(string.Empty);
        }

        [Test]
        [TestCaseSource(nameof(ParsePositiveFromStringInvalidIntData))]
        public void ParsePositiveFromString_Invalid_Int_Tests(string input)
        {
            Assert.Throws<ArgumentException>(() => _parser.ParsePositiveFromString(input));
        }

        static IEnumerable<TestCaseData> ParsePositiveFromStringInvalidIntData()
        {
            yield return new TestCaseData("0");
            yield return new TestCaseData("-1");
            yield return new TestCaseData("-2147483648");
            yield return new TestCaseData("1O"); // this is O, not 0
            yield return new TestCaseData("Hello");
        }
    }
}
