using System;
using NUnit.Framework;

namespace BlockWall.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void WallIsBlocking1()
        {
            AssertWallIsBlocking(
                new Wall { Position = new Point(1, 1), Orientation = Orientation.Horizontal },
                new Point(1, 1),
                new Point(1, 0));

            AssertWallIsBlocking(
                new Wall { Position = new Point(1, 1), Orientation = Orientation.Vertical },
                new Point(1, 1),
                new Point(0, 1));

            AssertWallIsBlocking(
                new Wall { Position = new Point(1, 2), Orientation = Orientation.Horizontal },
                new Point(1, 1),
                new Point(1, 2));

            AssertWallIsBlocking(
                new Wall { Position = new Point(2, 1), Orientation = Orientation.Vertical },
                new Point(1, 1),
                new Point(2, 1));
        }

        [Test]
        public void WallIsBlocking2()
        {
            AssertWallIsBlocking(
                new Wall { Position = new Point(3, 4), Orientation = Orientation.Horizontal },
                new Point(4, 4),
                new Point(4, 3));

            AssertWallIsBlocking(
                new Wall { Position = new Point(4, 3), Orientation = Orientation.Vertical },
                new Point(4, 4),
                new Point(0, 4));

            AssertWallIsBlocking(
                new Wall { Position = new Point(3, 5), Orientation = Orientation.Horizontal },
                new Point(4, 4),
                new Point(4, 5));

            AssertWallIsBlocking(
                new Wall { Position = new Point(5, 3), Orientation = Orientation.Vertical },
                new Point(4, 4),
                new Point(5, 4));
        }

        [Test]
        public void WallIsNotBlockingHorizontal()
        {
            AssertWallIsNotBlocking(
                new Wall { Position = new Point(0, 4), Orientation = Orientation.Horizontal },
                new Point(2, 4),
                new Point(2, 3));

            AssertWallIsNotBlocking(
                new Wall { Position = new Point(3, 4), Orientation = Orientation.Horizontal },
                new Point(2, 4),
                new Point(2, 3));

            AssertWallIsNotBlocking(
                new Wall { Position = new Point(0, 5), Orientation = Orientation.Horizontal },
                new Point(2, 4),
                new Point(2, 5));

            AssertWallIsNotBlocking(
                new Wall { Position = new Point(3, 5), Orientation = Orientation.Horizontal },
                new Point(2, 4),
                new Point(2, 5));
        }

        private void AssertWallIsBlocking(Wall wall, Point source, Point destination)
        {
            Assert.IsTrue(IsWallBlocking(wall, source, destination));
        }

        private void AssertWallIsNotBlocking(Wall wall, Point source, Point destination)
        {
            Assert.IsFalse(IsWallBlocking(wall, source, destination));
        }

        private bool IsWallBlocking(Wall wall, Point source, Point destination)
        {
            var board = new Board();
            board.PlaceWall(wall);

            return board.IsWallBetweenTiles(source, destination);
        }
    }
}