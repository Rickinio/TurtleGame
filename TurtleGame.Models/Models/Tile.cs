using TurtleGame.Enums;
using TurtleGame.Interfaces;

namespace TurtleGame.Models
{
    public class Tile : ITile
    {
        public  TileType TileType { get; set; }

        public Tile(TileType tileType = TileType.Safe)
        {
            TileType = tileType;
        }
    }
}
