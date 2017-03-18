using System.Collections.Generic;
using TurtleGame.Enums;

namespace TurtleGame.Models
{
    public class GameSettings : IGameSettings
    {
        public int BoardXSize { get; set; }
        public int BoardYSize { get; set; }
        public List<Point> Mines { get; set; }
        public Point Exit { get; set; }
        public Point TurtleInitialPosition { get; set; }
        public Heading TurtleInitialHeading { get; set; }
    }
}
