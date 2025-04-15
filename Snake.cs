using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    static class Snake
    {
        private static List<SnakePart> _snakeParts { get; set; } = new List<SnakePart>();

        private static char _direction = 'w';

        static Snake()
        {
            _snakeParts.Add(new SnakePart(8, 13, '0'));
            _snakeParts.Add(new SnakePart(8, 12, '0'));
        }
        public static void Move()
        {
            _snakeParts.RemoveAt(_snakeParts.Count - 1);


            if (_direction == 'w')
            {
                _snakeParts.Add(new SnakePart(_snakeParts[_snakeParts.Count - 1].X, _snakeParts[_snakeParts.Count - 1].Y - 1, '0'));
            }
            else if (_direction == 's')
            {
                _snakeParts.Add(new SnakePart(_snakeParts[_snakeParts.Count - 1].X, _snakeParts[_snakeParts.Count - 1].Y + 1, '0'));
            }
            else if (_direction == 'a')
            {
                _snakeParts.Add(new SnakePart(_snakeParts[_snakeParts.Count - 1].X - 1, _snakeParts[_snakeParts.Count - 1].Y, '0'));
            }
            else if (_direction == 'd')
            {
                _snakeParts.Add(new SnakePart(_snakeParts[_snakeParts.Count - 1].X + 1, _snakeParts[_snakeParts.Count - 1].Y, '0'));
            }
            VisualizeList();
        }
        public static void VisualizeList()
        {
            Console.Clear();
            foreach (SnakePart snakePart in _snakeParts)
            {
                Console.SetCursorPosition(snakePart.X, snakePart.Y);

                Console.Write(snakePart.Shape);
            }
        }
    }
}
