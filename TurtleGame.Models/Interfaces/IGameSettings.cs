using System.Collections.Generic;
using TurtleGame.Enums;

namespace TurtleGame.Models
{
    public interface IGameSettings
    {
        int BoardXSize { get; set; }
        int BoardYSize { get; set; }
        Point Exit { get; set; }
        List<Point> Mines { get; set; }
        Heading TurtleInitialHeading { get; set; }
        Point TurtleInitialPosition { get; set; }
    }
}