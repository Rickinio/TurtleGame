using NUnit.Framework;
using TurtleGame.Models;
using TurtleGame.Enums;

namespace TurtleGame.Tests.ModelTests
{
    [TestFixture(Author = "Konstantinos Stamatopoulos", Category = "Turtle", Description = "Test Turtle Functionality")]
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
        [TestCase(1, 1, Heading.North, 1, 0)]
        [TestCase(1, 1, Heading.East, 2, 1)]
        [TestCase(1, 1, Heading.South, 1, 2)]
        [TestCase(1, 1, Heading.West, 0, 1)]
        public void TurtleMoveNorthTestMustSucceed(int initialX, int initialY, Heading heading, int expectedX, int expectedY) {
            var turtle = new Turtle();
            turtle.Heading = heading;
            turtle.Position = new Point(initialX, initialY);
            turtle.Move();
            Assert.AreEqual(new Point(expectedX,expectedY), turtle.Position);
        }
    }
}