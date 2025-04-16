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

        private static ConsoleKey _direction = ConsoleKey.W;
        public static ConsoleKey Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                if (value == ConsoleKey.W || value == ConsoleKey.S || value == ConsoleKey.A || value == ConsoleKey.D)
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
            Console.Clear();

            _snakeParts.Dequeue();

            EnqueueNewSnakeUnit();

            Graphics.VisualizeList(_snakeParts);
        }
        public static void EnqueueNewSnakeUnit()
        {
            if (_direction == ConsoleKey.W)
            {
                _snakeParts.Enqueue(new SnakePart(SnakeParts[_snakeParts.Count - 1].X, SnakeParts[_snakeParts.Count - 1].Y - 1, SnakeShape));
            }
            else if (_direction == ConsoleKey.S)
            {
                _snakeParts.Enqueue(new SnakePart(SnakeParts[_snakeParts.Count - 1].X, SnakeParts[_snakeParts.Count - 1].Y + 1, SnakeShape));
            }
            else if (_direction == ConsoleKey.A)
            {
                _snakeParts.Enqueue(new SnakePart(SnakeParts[_snakeParts.Count - 1].X - 1, SnakeParts[_snakeParts.Count - 1].Y, SnakeShape));
            }
            else if (_direction == ConsoleKey.D)
            {
                _snakeParts.Enqueue(new SnakePart(SnakeParts[_snakeParts.Count - 1].X + 1, SnakeParts[_snakeParts.Count - 1].Y, SnakeShape));
            }
        }
    }
}
