using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TurtleGame.Enums;
using TurtleGame.Interfaces;
using TurtleGame.Models;

namespace TurtleGame.Helpers
{
    public static class Utils
    {
        public static Tuple<IGameSettings, List<List<ActionType>>> ParseArguments(string[] args) {
            try {

                Tuple<IGameSettings, List<List<ActionType>>> argsTuple = null;

                if (args.Length < 2) {
                    Console.WriteLine(@"Number of arguments is wrong, please enter ""game-settings"" ""and moves"" file");
                }

                var gameSettingsFile = Directory.GetFiles(Directory.GetCurrentDirectory(), $"{args[0]}.*", SearchOption.TopDirectoryOnly);
                var movesFile = Directory.GetFiles(Directory.GetCurrentDirectory(), $"{args[1]}.*", SearchOption.TopDirectoryOnly);

                #region check arguments validity

                if (gameSettingsFile.Length == 0) {
                    Console.WriteLine(@"""game-settings"" file not found");
                }
                if (movesFile.Length == 0) {
                    Console.WriteLine(@"""moves"" file not found");
                }
                if (gameSettingsFile.Length > 1) {
                    Console.WriteLine(@"More than one ""game-settings"" file found");
                }
                if (movesFile.Length > 1) {
                    Console.WriteLine(@"More than one ""moves"" file found");
                }

                #endregion

                if (gameSettingsFile.Length == 1 && movesFile.Length == 1) {
                    var gameSettings = JsonConvert.DeserializeObject<GameSettings>(File.ReadAllText(gameSettingsFile[0]));
                    var moves = JsonConvert.DeserializeObject<List<List<ActionType>>>(File.ReadAllText(movesFile[0]));

                    argsTuple = new Tuple<IGameSettings, List<List<ActionType>>>(gameSettings, moves);
                }

                return argsTuple;
            }
            catch {
                throw;
            }
        }
    }
}
