using NUnit.Framework;
using TurtleGame.Models;
using TurtleGame.Enums;

namespace TurtleGame.Tests.ModelTests
{
    [TestFixture()]
    public class TurtleTests
    {
        [Test()]
        public void TurtleRotateOnceTestMustSucceed() {
            var turtle = new Turtle();
            turtle.Heading = Heading.North;
            turtle.Rotate();
            Assert.AreEqual(Heading.East, turtle.Heading);
        }

        [Test()]
        public void TurtleRotateTwiceTestMustSucceed() {
            var turtle = new Turtle();
            turtle.Heading = Heading.North;
            turtle.Rotate();
            turtle.Rotate();
            Assert.AreEqual(Heading.South, turtle.Heading);
        }


        [Test()]
        [TestCase(1, 1, Heading.North, 0, 1)]
        [TestCase(1, 1, Heading.East, 1, 2)]
        [TestCase(1, 1, Heading.South, 2, 1)]
        [TestCase(1, 1, Heading.West, 1, 0)]
        public void TurtleMoveNorthTestMustSucceed(int initialX, int initialY, Heading heading, int expectedX, int expectedY) {
            var turtle = new Turtle();
            turtle.Heading = heading;
            turtle.Position = new Point(initialX, initialY);
            turtle.Move();
            Assert.AreEqual(new Point(expectedX,expectedY), turtle.Position);
        }
    }
}