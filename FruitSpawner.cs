using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    internal static class FruitSpawner
    {
        private readonly static Random _random = new Random();

        public static Fruit CreateFruit(List<SnakePart> snakeParts)
        {
            int randomX, randomY;
            SnakePart newFruitPosition;

            do
            {
                randomX = _random.Next(1, Console.WindowWidth - 1);
                randomY = _random.Next(1, Console.WindowHeight - 1);
                newFruitPosition = new SnakePart(randomX, randomY);
            }
            while (snakeParts.Contains(newFruitPosition));

            return new Fruit(randomX, randomY);
        }
    }
}
