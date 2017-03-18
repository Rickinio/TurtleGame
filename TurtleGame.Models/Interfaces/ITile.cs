using TurtleGame.Enums;

namespace TurtleGame.Models
{
    public interface ITile
    {
        TileType TileType { get; set; }
    }
}