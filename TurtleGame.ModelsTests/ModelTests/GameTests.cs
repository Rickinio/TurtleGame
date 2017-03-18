using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using TurtleGame.Enums;
using TurtleGame.Interfaces;
using TurtleGame.Models;

namespace TurtleGame.Tests.ModelTests
{
    [TestFixture(Author = "Konstantinos Stamatopoulos", Category = "Game", Description = "Test Game Functionality")]
    public class GameTests
    {
        private IGameSettings _gameSettings = new GameSettings() {
            BoardXSize = 5,
            BoardYSize = 5,
            TurtleInitialHeading = Heading.North,
            TurtleInitialPosition = new Point(0, 1),
            Exit = new Point(4, 2),
            Mines = new List<Point> {
                        new Point(2,1),
                        new Point(2,2),
                        new Point(2,3)
                    }
        };


        [Test()]
        public void GameTurtleExitsTestMustSucceed() {

            var firstSequence = new List<ActionType> {
                ActionType.Move,
                ActionType.Rotate,
                ActionType.Move,
                ActionType.Move,
                ActionType.Move,
                ActionType.Rotate,
                ActionType.Move,
                ActionType.Move,
                ActionType.Rotate,
                ActionType.Rotate,
                ActionType.Rotate,
                ActionType.Move
            };

            var secondSequence = new List<ActionType> {
                ActionType.Rotate,
                ActionType.Rotate,
                ActionType.Move,
                ActionType.Move,
                ActionType.Move,
                ActionType.Rotate,
                ActionType.Rotate,
                ActionType.Rotate,
                ActionType.Move,
                ActionType.Move,
                ActionType.Move,
                ActionType.Move,
                ActionType.Rotate,
                ActionType.Rotate,
                ActionType.Rotate,
                ActionType.Move,
                ActionType.Move
            };

            var sequences = new List<List<ActionType>>() {
                firstSequence,
                secondSequence
            };

            using (StringWriter sw = new StringWriter()) {
                Console.SetOut(sw);
                var game = new Game(_gameSettings, sequences);
                game.ExecuteMovements();
                string expectedConsoleOutput = $"Sequence 1: Success!{Environment.NewLine}Sequence 2: Success!{Environment.NewLine}";
                Assert.AreEqual(expectedConsoleOutput, sw.ToString());
            }
        }

        [Test()]
        public void GameTurtleHitsMineTestMustSucceed() {

            var actions = new List<ActionType> {
                ActionType.Rotate,
                ActionType.Move,
                ActionType.Move,
                ActionType.Move,
            };

            var sequences = new List<List<ActionType>>() {
                actions
            };

            using (StringWriter sw = new StringWriter()) {
                Console.SetOut(sw);
                var game = new Game(_gameSettings, sequences);
                game.ExecuteMovements();
                string expectedConsoleOutput = $"Sequence 1: Mine hit!{Environment.NewLine}";
                Assert.AreEqual(expectedConsoleOutput, sw.ToString());
            }
        }

        [Test()]
        public void GameTurtleStillInDangerTestMustSucceed() {

            var actions = new List<ActionType> {
                ActionType.Move,
                ActionType.Rotate,
                ActionType.Move,
                ActionType.Move,
                ActionType.Move,
                ActionType.Rotate,
                ActionType.Move,
                ActionType.Move,
                ActionType.Move
            };

            var sequences = new List<List<ActionType>>() {
                actions
            };

            using (StringWriter sw = new StringWriter()) {
                Console.SetOut(sw);
                var game = new Game(_gameSettings, sequences);
                game.ExecuteMovements();
                string expectedConsoleOutput = $"Sequence 1: Still in danger!{Environment.NewLine}";
                Assert.AreEqual(expectedConsoleOutput, sw.ToString());
            }
        }

        [Test()]
        public void GameTurtlePrintExceptionTestMustSucceed() {

            var actions = new List<ActionType> {
                ActionType.Move,
                ActionType.Move,
                ActionType.Move,
                ActionType.Move,
            };

            var sequences = new List<List<ActionType>>() {
                actions
            };

            using (StringWriter sw = new StringWriter()) {
                Console.SetOut(sw);
                var game = new Game(_gameSettings, sequences);
                game.ExecuteMovements();
                Assert.That(sw.ToString().Contains("There was an error - Message:"));
            }
        }
    }
}
