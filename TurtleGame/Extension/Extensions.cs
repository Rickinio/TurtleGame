using System;
using System.Collections.Generic;
using TurtleGame.Enums;
using TurtleGame.Interfaces;
using TurtleGame.Helpers;

namespace TurtleGame.Extension
{
    public static class Extensions
    {
        public static Tuple<IGameSettings, List<List<ActionType>>> ParseArguments(this String[] args) {
            return Utils.ParseArguments(args);
        }
    }
}
