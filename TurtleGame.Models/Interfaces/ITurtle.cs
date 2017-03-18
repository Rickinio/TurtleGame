using TurtleGame.Enums;

namespace TurtleGame.Models
{
    public interface ITurtle
    {
        Heading Heading { get; set; }
        Point Position { get; set; }

        void Move();
        void Rotate();
    }
}