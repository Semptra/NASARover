namespace NASARover.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using NASARover.Core;
    using NASARover.Core.Models;
    using NASARover.Core.Enums;

    [TestFixture]
    public class RoverTests
    {
        [Test]
        [TestCaseSource(nameof(MoveValidData))]
        public void Move_Valid_Test(Rover rover, Point expected)
        {
            rover.Move();

            Assert.AreEqual(expected, rover.Position);
        }

        static IEnumerable<TestCaseData> MoveValidData()
        {
            var plateau = new Plateau(new Point(10, 10));
            yield return new TestCaseData(new Rover(plateau, new Point(1, 1), Direction.North), new Point(1, 2));
            yield return new TestCaseData(new Rover(plateau, new Point(1, 1), Direction.East), new Point(2, 1));
            yield return new TestCaseData(new Rover(plateau, new Point(1, 1), Direction.South), new Point(1, 0));
            yield return new TestCaseData(new Rover(plateau, new Point(1, 1), Direction.West), new Point(0, 1));
        }

        [Test]
        [TestCaseSource(nameof(MoveInvalidData))]
        public void Move_Invalid_Test(Rover rover)
        {
            Assert.Throws<ArgumentException>(() => rover.Move());
        }

        static IEnumerable<TestCaseData> MoveInvalidData()
        {
            var plateau = new Plateau(new Point(10, 10));
            yield return new TestCaseData(new Rover(plateau, new Point(1, 10), Direction.North));
            yield return new TestCaseData(new Rover(plateau, new Point(10, 1), Direction.East));
            yield return new TestCaseData(new Rover(plateau, new Point(1, 0), Direction.South));
            yield return new TestCaseData(new Rover(plateau, new Point(0, 1), Direction.West));
        }

        [Test]
        [TestCaseSource(nameof(RotateValidData))]
        public void Rotate_Valid_Test(Rover rover, Rotation rotation, Direction expected)
        {
            rover.Rotate(rotation);

            Assert.AreEqual(expected, rover.FaceDirection);
        }

        static IEnumerable<TestCaseData> RotateValidData()
        {
            var plateau = new Plateau(new Point(10, 10));
            var position = new Point(0, 0);
            yield return new TestCaseData(new Rover(plateau, position, Direction.North), Rotation.Left, Direction.West);
            yield return new TestCaseData(new Rover(plateau, position, Direction.North), Rotation.Right, Direction.East);

            yield return new TestCaseData(new Rover(plateau, position, Direction.East), Rotation.Left, Direction.North);
            yield return new TestCaseData(new Rover(plateau, position, Direction.East), Rotation.Right, Direction.South);

            yield return new TestCaseData(new Rover(plateau, position, Direction.South), Rotation.Left, Direction.East);
            yield return new TestCaseData(new Rover(plateau, position, Direction.South), Rotation.Right, Direction.West);

            yield return new TestCaseData(new Rover(plateau, position, Direction.West), Rotation.Left, Direction.South);
            yield return new TestCaseData(new Rover(plateau, position, Direction.West), Rotation.Right, Direction.North);
        }
    }
}
