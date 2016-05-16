using System;
using NUnit.Framework;
using BlockWall;

namespace BlockWall.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void PlaceWallThatBlocksMove1()
        {
            var board = new Board();
            board.PlaceWall(new Wall
            {
                Position = new Point(2, 2),
                Orientation = Orientation.Horizontal
            });

            Assert.IsTrue(board.IsWallBetweenTiles(new Point(3, 2), new Point(3, 1)));
        }

        [Test]
        public void PlaceWallThatBlocksMove2()
        {
            var board = new Board();
            board.PlaceWall(new Wall
            {
                Position = new Point(2, 2),
                Orientation = Orientation.Vertical
            });

            Assert.IsFalse(board.IsWallBetweenTiles(new Point(3, 2), new Point(3, 3)));
        }

        [Test]
        public void PlaceWallThatBlocksMove3()
        {
            var board = new Board();
            board.PlaceWall(new Wall
            {
                Position = new Point(4, 3),
                Orientation = Orientation.Vertical
            });

            Assert.IsTrue(board.IsWallBetweenTiles(new Point(3, 3), new Point(4, 3)));
        }
    }
}