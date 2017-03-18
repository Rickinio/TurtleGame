using TurtleGame.Enums;
using TurtleGame.Exceptions;

namespace TurtleGame.Models
{
    public class Board : IBoard
    {
        public Tile[,] Grid { get; set; }

        public Board() {

        }

        public Board(GameSettings gameSettings) {
            Grid = new Tile[gameSettings.BoardXSize, gameSettings.BoardYSize];

            //Initilize Grid
            var xLength = Grid.GetLength(0);
            var ylength = Grid.GetLength(1);

            for (int i = 1; i < xLength; i++) {
                for (int j = 1; j < ylength; j++) {
                    Grid[i, j] = new Tile();
                }
            }

            //Set Mines
            foreach (var minePoint in gameSettings.Mines) {
                Grid[minePoint.X, minePoint.Y].TileType = TileType.Mine;
            }

            //Set Exit
            Grid[gameSettings.Exit.X, gameSettings.Exit.Y].TileType = TileType.Exit;
        }

        public TileType GetTileTypeForPoint(Point turtlePosition) {
            if (turtlePosition.X >= 0 && turtlePosition.X < Grid.GetLength(0) &&
                turtlePosition.Y >= 0 && turtlePosition.Y < Grid.GetLength(1)) {
                var currentTile = Grid[turtlePosition.X, turtlePosition.Y].TileType;
                return currentTile;
            }
            else {
                throw new InvalidTurtleMoveException($"Turtle movement is invalid - Point:({turtlePosition.X},{turtlePosition.Y}) is out of the board");
            }
        }
    }
}
