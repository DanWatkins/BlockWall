using NUnit.Framework;

namespace BlockWall.Tests
{
    internal class AssertEx
    {
        public static void AreEqual(Point expected, Point actual)
        {
            if (expected.X != actual.X || expected.Y != actual.Y)
            {
                Assert.Fail(
                    "Expected (" + expected.X + "," + expected.Y
                    + ")\nBut was (" + actual.X + "," + actual.Y + ")");
            }
        }
    }
}
