using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    internal class FruitObject : GameObject
    {
        private static readonly Random _random = new Random();
        private static readonly char[] _shapes = ['*', 'o', 'a'];
        public FruitObject(int x, int y)
        {
            X = x;
            Y = y;
            Shape = _shapes[_random.Next(_shapes.Length)];
        }
    }
}
