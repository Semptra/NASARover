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
    }
}
