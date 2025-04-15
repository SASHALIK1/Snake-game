using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    internal class SnakePart
    {
        public int X;
        public int Y;
        public char Shape;
        public SnakePart(int x, int y, char shape)
        {
            X = x;
            Y = y;
            Shape = shape;
        }
        public SnakePart(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
