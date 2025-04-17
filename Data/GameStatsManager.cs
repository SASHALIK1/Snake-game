using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Snake_game.Data
{
    internal static class GameStatsManager
    {
        public static readonly GameStats gameStats = LoadData();

        public static void SaveData()
        {
            File.WriteAllText("score.json", JsonSerializer.Serialize(gameStats));
        }
        public static GameStats LoadData()
        {
            if (File.Exists("score.json"))
            {
                return JsonSerializer.Deserialize<GameStats>(File.ReadAllText("score.json")) ?? new GameStats();
            }
            else
            {
                return new GameStats();
            }
        }
    }
}
