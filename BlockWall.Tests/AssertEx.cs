using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockWall.Tests
{
    class AssertEx
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
