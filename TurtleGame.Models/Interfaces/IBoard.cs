using TurtleGame.Enums;

namespace TurtleGame.Models
{
    public interface IBoard
    {
        Tile[,] Grid { get; set; }

        TileType GetTileTypeForPoint(Point turtlePoint);
    }
}