using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    static class Snake
    {
        private const char SnakeShape = '0';
        public static IReadOnlyList<SnakePart> SnakeParts { get { return (IReadOnlyList<SnakePart>)_snakeParts.ToList(); } }
        private static Queue<SnakePart> _snakeParts { get; set; } = new Queue<SnakePart>();

        private static char _direction = 'w';
        public static char Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                if (value == 'w' || value == 's' || value == 'a' || value == 'd')
                {
                    _direction = value;
                }
            }
        }

        static Snake()
        {
            _snakeParts.Enqueue(new SnakePart(8, 13, SnakeShape));
            _snakeParts.Enqueue(new SnakePart(8, 12, SnakeShape));
        }
        public static void Move()
        {
            _snakeParts.Dequeue();

            if (_direction == 'w')
            {
                _snakeParts.Enqueue(new SnakePart(SnakeParts[_snakeParts.Count - 1].X, SnakeParts[_snakeParts.Count - 1].Y - 1, SnakeShape));
            }
            else if (_direction == 's')
            {
                _snakeParts.Enqueue(new SnakePart(SnakeParts[_snakeParts.Count - 1].X, SnakeParts[_snakeParts.Count - 1].Y + 1, SnakeShape));
            }
            else if (_direction == 'a')
            {
                _snakeParts.Enqueue(new SnakePart(SnakeParts[_snakeParts.Count - 1].X - 1, SnakeParts[_snakeParts.Count - 1].Y, SnakeShape));
            }
            else if (_direction == 'd')
            {
                _snakeParts.Enqueue(new SnakePart(SnakeParts[_snakeParts.Count - 1].X + 1, SnakeParts[_snakeParts.Count - 1].Y, SnakeShape));
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
