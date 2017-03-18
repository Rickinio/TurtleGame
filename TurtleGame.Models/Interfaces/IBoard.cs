using TurtleGame.Enums;
using TurtleGame.Models;

namespace TurtleGame.Interfaces
{
    public interface IBoard
    {
        ITile[,] Grid { get; set; }
        TileType GetTileTypeForPoint(Point turtlePoint);
    }
}