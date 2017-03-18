using System;
using TurtleGame.Enums;
using TurtleGame.Interfaces;

namespace TurtleGame.Models
{
    public class Turtle : ITurtle
    {
        private readonly Heading[] _headings = { Heading.North, Heading.East, Heading.South, Heading.West };
        public Point Position { get; set; }
        public Heading Heading { get; set; }

        public Turtle() {

        }

        public Turtle(IGameSettings gameSettings) {
            Position = gameSettings.TurtleInitialPosition;
            Heading = gameSettings.TurtleInitialHeading;
        }

        public void Rotate() {
            Heading = _headings[(int)Heading % _headings.Length];
        }

        public void Move() {
            switch (Heading) {
                case Heading.North:
                    Position = new Point(Position.X, Position.Y - 1);
                    break;
                case Heading.East:
                    Position = new Point(Position.X + 1, Position.Y);
                    break;
                case Heading.South:
                    Position = new Point(Position.X, Position.Y + 1);
                    break;
                case Heading.West:
                    Position = new Point(Position.X - 1, Position.Y);
                    break;
                case Heading.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
