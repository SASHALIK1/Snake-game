using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    internal abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public char Shape { get; protected set; }
    }
}
