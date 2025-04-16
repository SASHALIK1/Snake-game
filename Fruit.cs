using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    internal class Fruit : GameObject
    {
        private static readonly Random _random = new Random();
        private readonly char[] _shapes = ['*', 'o', 'a'];
        public Fruit(int x, int y)
        {
            X = x;
            Y = y;
            Shape = _shapes[_random.Next(_shapes.Length)];
        }
    }
}
