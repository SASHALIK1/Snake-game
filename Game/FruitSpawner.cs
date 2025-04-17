using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game.Game
{
    internal static class FruitSpawner
    {
        private readonly static Random _random = new Random();

        public static FruitObject CreateFruit(List<SnakeObject> snakeParts)
        {
            int randomX, randomY;

            do
            {
                randomX = _random.Next(1, Console.WindowWidth - 1);
                randomY = _random.Next(1, Console.WindowHeight - 1);
            }
            while (snakeParts.Contains(new SnakeObject(randomX, randomY)));

            return new FruitObject(randomX, randomY);
        }
    }
}
