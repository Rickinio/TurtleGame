using System;
using TurtleGame.Models;
using TurtleGame.Extension;

namespace TurtleGame
{
    class Program
    {
        static void Main(string[] args) {
            try {
                var parsedArguments = args.ParseArguments();
                if (parsedArguments != null) {

                    var gameSettings = parsedArguments.Item1;
                    var moves = parsedArguments.Item2;

                    var game = new Game(gameSettings, moves);
                    game.ExecuteMovements();                    
                }
            }
            catch( Exception ex) {
                Console.WriteLine($"There was a problem: Exception: {ex.Message} - InnerException: {ex?.InnerException?.Message}");
            }

            Console.ReadKey();
        }
    }
}
