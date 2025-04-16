﻿using System;
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
        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;

            GameObject other = (GameObject)obj;
            return other.X == X && other.Y == Y;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
