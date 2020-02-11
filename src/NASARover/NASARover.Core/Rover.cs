namespace NASARover.Core
{
    using System;

    using NASARover.Core.Enums;
    using NASARover.Core.Interfaces;
    using NASARover.Core.Models;

    public class Rover : IRover
    {
        public Point Position { get; private set; }

        public Direction FaceDirection { get; private set; }

        public IPlateau Plateau { get; }

        public Rover(IPlateau plateau) : this(plateau, new Point(0, 0), Direction.North) { }

        public Rover(IPlateau plateau, Point startPosition, Direction faceDirection)
        {
            Plateau = plateau;
            Position = startPosition;
            FaceDirection = faceDirection;
        }

        public void Move()
        {
            var movePoint = GetMovePoint();

            if (Plateau.IsValidPosition(movePoint))
            {
                Position = movePoint;
            }
            else
            {
                throw new ArgumentException($"Cannot move rover: point {movePoint} is invalid.");
            }

            Point GetMovePoint()
            {
                return FaceDirection switch
                {
                    Direction.North => new Point(Position.X, Position.Y + 1),
                    Direction.South => new Point(Position.X, Position.Y - 1),
                    Direction.East => new Point(Position.X + 1, Position.Y),
                    Direction.West => new Point(Position.X - 1, Position.Y),
                    _ => throw new ArgumentException($"Invalid direction: {FaceDirection}"),
                };
            }
        }

        public void Rotate(Rotation rotation)
        {
            if (rotation == Rotation.Left)
            {
                FaceDirection = FaceDirection == Direction.North ? Direction.West : FaceDirection - 1;
            }
            else
            {
                FaceDirection = FaceDirection == Direction.West ? Direction.North : FaceDirection + 1;
            }
        }
    }
}
