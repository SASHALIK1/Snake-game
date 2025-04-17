using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    internal class SnakeObject : GameObject
    {
        public SnakeObject(int x, int y, char shape)
        {
            X = x;
            Y = y;
            Shape = shape;
        }
        public SnakeObject(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
