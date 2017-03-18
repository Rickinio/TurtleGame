using System;
using System.Collections.Generic;
using TurtleGame.Enums;
using TurtleGame.Interfaces;

namespace TurtleGame.Models
{
    public class Game : IGame
    {
        private readonly List<List<ActionType>> _sequences;
        private readonly IGameSettings _gameSettings;
        private bool _won;
        public IBoard Board { get; set; }
        public ITurtle Turtle { get; set; }

        public Game(IGameSettings gameSettings, List<List<ActionType>> sequences)
        {
            _gameSettings = gameSettings;
            _sequences = sequences;
            
            Board = new Board(gameSettings);            
        }

        public void ExecuteMovements()
        {
            var sequenceCounter = 0;
            try
            {
                foreach (var sequence in _sequences)
                {
                    //for each move sequence we reset the currentTile and also the Turtle initial position
                    Turtle = new Turtle(_gameSettings);
                    var currentTile = TileType.Safe;
                    sequenceCounter++;

                    foreach (var action in sequence)
                    {

                        switch (action)
                        {
                            case ActionType.MoveForward:
                                Turtle.Move();
                                break;
                            case ActionType.RotateToTheRight:
                                Turtle.Rotate();
                                break;
                            case ActionType.None:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        currentTile = Board.GetTileTypeForPoint(Turtle.Position);

                        if (currentTile == TileType.Safe)
                        {
                            continue;
                        }

                        if (currentTile == TileType.Mine)
                        {
                            Console.WriteLine($"Sequence {sequenceCounter}: Mine hit!");
                            break;
                        }

                        if (currentTile == TileType.Exit)
                        {
                            _won = true;
                            Console.WriteLine($"Sequence {sequenceCounter}: Success!");
                            break;
                        }
                    }

                    //if we finished all moves and didn't win and didn't hit a mine then we are still in danger!!
                    if (!_won && currentTile == TileType.Safe)
                    {
                        Console.WriteLine($"Sequence {sequenceCounter}: Still in danger!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error - Message: {ex.Message}");
            }
        }
    }
}
