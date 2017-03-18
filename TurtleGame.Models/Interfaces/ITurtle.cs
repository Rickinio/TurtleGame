using TurtleGame.Enums;
using TurtleGame.Models;

namespace TurtleGame.Interfaces
{
    public interface ITurtle
    {
        Heading Heading { get; set; }
        Point Position { get; set; }
        void Move();
        void Rotate();
    }
}