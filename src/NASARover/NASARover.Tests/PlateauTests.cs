namespace NASARover.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using NASARover.Core;
    using NASARover.Core.Models;

    [TestFixture]
    public class PlateauTests
    {
        [Test]
        [TestCaseSource(nameof(CtorValidData))]
        public void Ctor_Valid_Test(Point bottomLeftPosition, Point topRightPosition)
        {
            var plateau = new Plateau(bottomLeftPosition, topRightPosition);

            Assert.AreEqual(bottomLeftPosition, plateau.BottomLeftPosition);
            Assert.AreEqual(topRightPosition, plateau.TopRightPoistion);
        }

        static IEnumerable<TestCaseData> CtorValidData()
        {
            yield return new TestCaseData(new Point(0, 0), new Point(0, 0));
            yield return new TestCaseData(new Point(0, 0), new Point(1, 1));
            yield return new TestCaseData(new Point(-1, -2), new Point(0, -1));
            yield return new TestCaseData(new Point(-1, -2), new Point(1, 2));
            yield return new TestCaseData(new Point(int.MinValue, int.MinValue), new Point(int.MaxValue, int.MaxValue));
        }

        [Test]
        [TestCaseSource(nameof(CtorInvalidData))]
        public void Ctor_Invalid_Test(Point bottomLeftPosition, Point topRightPosition)
        {
            Assert.Throws<ArgumentException>(() => new Plateau(bottomLeftPosition, topRightPosition));
        }

        static IEnumerable<TestCaseData> CtorInvalidData()
        {
            yield return new TestCaseData(new Point(1, 0), new Point(0, 0));
            yield return new TestCaseData(new Point(0, 1), new Point(0, 0));
            yield return new TestCaseData(new Point(-1, -2), new Point(-2, -3));
            yield return new TestCaseData(new Point(-1, 2), new Point(-2, 1));
            yield return new TestCaseData(new Point(int.MaxValue, int.MaxValue), new Point(int.MinValue, int.MinValue));
        }

        [Test]
        [TestCaseSource(nameof(IsValidPointValidData))]
        public void IsValidPosition_Valid_Test(Point bottomLeftPosition, Point topRightPosition, Point testPosition)
        {
            var plateau = new Plateau(bottomLeftPosition, topRightPosition);

            var result = plateau.IsValidPosition(testPosition);

            Assert.IsTrue(result);
        }

        static IEnumerable<TestCaseData> IsValidPointValidData()
        {
            yield return new TestCaseData(new Point(0, 0), new Point(0, 0), new Point(0, 0));
            yield return new TestCaseData(new Point(0, 0), new Point(10, 10), new Point(5, 5));
            yield return new TestCaseData(new Point(-2, -3), new Point(0, 0), new Point(-1, -2));
            yield return new TestCaseData(new Point(-5, 5), new Point(0, 10), new Point(0, 5));
            yield return new TestCaseData(new Point(int.MinValue, int.MinValue), new Point(int.MinValue, int.MinValue), new Point(int.MinValue, int.MinValue));
        }

        [Test]
        [TestCaseSource(nameof(IsValidPointInvalidData))]
        public void IsValidPosition_Invalid_Test(Point bottomLeftPosition, Point topRightPosition, Point testPosition)
        {
            var plateau = new Plateau(bottomLeftPosition, topRightPosition);

            var result = plateau.IsValidPosition(testPosition);

            Assert.IsFalse(result);
        }

        static IEnumerable<TestCaseData> IsValidPointInvalidData()
        {
            yield return new TestCaseData(new Point(0, 0), new Point(0, 0), new Point(-1, 1));
            yield return new TestCaseData(new Point(0, 0), new Point(10, 10), new Point(0, -1));
            yield return new TestCaseData(new Point(-2, -3), new Point(0, 0), new Point(-3, -3));
            yield return new TestCaseData(new Point(-5, 5), new Point(0, 10), new Point(-6, 11));
            yield return new TestCaseData(new Point(int.MinValue, int.MinValue), new Point(int.MinValue, int.MinValue), new Point(int.MaxValue, int.MaxValue));
        }
    }
}
