using NUnit.Framework;

namespace BlockWall.Tests
{
    [TestFixture]
    public class BoardTests
    {
        #region Tests
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
                new Point(4, 0));

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
        public void CanPlaceWallAtPixelPosition_Vertical1()
        {
            var board = Board.StandardBoard;
            var wall = board.CreateWallToInsertAtPixelLocation(85, 40);

            Assert.IsNotNull(wall);
            AssertEx.AreEqual(new Point(1, 0), wall.Position);
            Assert.AreEqual(Orientation.Vertical, wall.Orientation);
        }

        [Test]
        public void CanPlaceWallAtPixelPosition_Vertical2()
        {
            var board = Board.StandardBoard;
            var wall = board.CreateWallToInsertAtPixelLocation(265, 97);

            Assert.IsNotNull(wall);
            AssertEx.AreEqual(new Point(4, 1), wall.Position);
            Assert.AreEqual(Orientation.Vertical, wall.Orientation);
        }

        [Test]
        public void CanPlaceWallAtPixelPosition_Horizontal1()
        {
            var board = Board.StandardBoard;
            var wall = board.CreateWallToInsertAtPixelLocation(162, 144);

            Assert.IsNotNull(wall);
            AssertEx.AreEqual(new Point(2, 2), wall.Position);
            Assert.AreEqual(Orientation.Horizontal, wall.Orientation);
        }

        [Test]
        public void CanPlaceWallAtPixelPosition_Horizontal2()
        {
            var board = Board.StandardBoard;
            var wall = board.CreateWallToInsertAtPixelLocation(410, 265);

            Assert.IsNotNull(wall);
            AssertEx.AreEqual(new Point(6, 4), wall.Position);
            Assert.AreEqual(Orientation.Horizontal, wall.Orientation);
        }
        #endregion

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
            var board = Board.StandardBoard;
            board.InsertWall(wall);

            return board.IsWallBetweenTiles(source, destination);
        }
    }
}