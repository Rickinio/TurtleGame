using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleGame.Enums;
using TurtleGame.Models;

namespace TurtleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var t =
                new Turtle(new GameSettings()
                {
                    TurtleInitialPosition = new Point(0, 0),
                    TurtleInitialHeading = Heading.North
                });
            t.Rotate();
            t.Rotate();
            t.Rotate();
            t.Rotate();
            t.Rotate();
            t.Rotate();
        }
    }
}
