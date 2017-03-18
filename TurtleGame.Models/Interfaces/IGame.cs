namespace TurtleGame.Models
{
    public interface IGame
    {
        IBoard Board { get; set; }
        ITurtle Turtle { get; set; }

        void ExecuteMovements();
    }
}