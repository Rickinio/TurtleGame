using NUnit.Framework;
using System.Collections.Generic;
using TurtleGame.Enums;
using TurtleGame.Exceptions;
using TurtleGame.Interfaces;
using TurtleGame.Models;

namespace TurtleGame.Tests.ModelTests
{
    [TestFixture(Author ="Konstantinos Stamatopoulos",Category ="Board",Description ="Test Board Functionality")]
    public class BoardTests
    {
        private IBoard _board = new Board(new GameSettings() {
            BoardXSize = 5,
            BoardYSize = 5,
            TurtleInitialHeading = Heading.East,
            TurtleInitialPosition = new Point(1, 1),
            Exit = new Point(4, 4),
            Mines = new List<Point> {
                    new Point(2,2),
                    new Point(3,3)
                }
        });

        [Test()]
        [TestCase(2, 2, TileType.Mine)]
        [TestCase(3, 3, TileType.Mine)]
        [TestCase(4, 4, TileType.Exit)]
        [TestCase(1, 3, TileType.Safe)]
        public void BoardGetTileTypeForPointTestMustSucceed(int x, int y, TileType tileTypeExpected) {
            var tileTypeResult = _board.GetTileTypeForPoint(new Point(x, y));
            Assert.AreEqual(tileTypeExpected, tileTypeResult);
        }

        [Test()]
        [TestCase(5, 5, TileType.Mine)]
        [TestCase(1, 5, TileType.Mine)]
        [TestCase(6, 2, TileType.Exit)]
        public void BoardGetTileTypeForPointTestMustFail(int x, int y, TileType tileTypeExpected) {
            Assert.Throws<InvalidTurtleMoveException>(() => _board.GetTileTypeForPoint(new Point(x, y)));
        }
    }
}
