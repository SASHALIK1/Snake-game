using Snake_game.InputManaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game.Game
{
    static class Snake
    {
        private const int MaxGameScore = 388;
        private const char SnakeShape = '0';
        private static Queue<SnakeObject> _snakeParts { get; set; } = new Queue<SnakeObject>(new[]
        {
            new SnakeObject(8, 13, SnakeShape),
            new SnakeObject(8, 12, SnakeShape)
        });

        private static GameKeys _currentDirection = GameKeys.Up;
        private static GameKeys _direction = _currentDirection;
        private static FruitObject _currentFruit = FruitSpawner.CreateFruit(_snakeParts.ToList());
        public static int Score { get; private set; } = 0;
        public static GameKeys Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                switch (value)
                {
                    case GameKeys.Up:
                        if (_currentDirection != GameKeys.Down)
                            _direction = GameKeys.Up;
                        break;
                    case GameKeys.Down:
                        if (_currentDirection != GameKeys.Up)
                            _direction = GameKeys.Down;
                        break;
                    case GameKeys.Left:
                        if (_currentDirection != GameKeys.Right)
                            _direction = GameKeys.Left;
                        break;
                    case GameKeys.Right:
                        if (_currentDirection != GameKeys.Left)
                            _direction = GameKeys.Right;
                        break;
                }
            }
        }
        public static void Move()
        {
            _currentDirection = _direction;
            CheckCollision();
            if (GameFlowController.IsGameRunnig)
            {
                if (_currentFruit != null)
                {
                    Graphics.VisualizeObject(_currentFruit);
                }
                Graphics.VisualizeList(_snakeParts);
                Graphics.VisualizeWalls();
                Graphics.VisualizeText(0, 0, "Score: " + Score);
            }
        }
        private static void CheckCollision()
        {
            SnakeObject snakeHead = _snakeParts.Last();
            if (_currentFruit != null && snakeHead.X == _currentFruit.X && snakeHead.Y == _currentFruit.Y)
            {
                Score++;
                if (Score >= MaxGameScore)
                {
                    GameFlowController.WinGame();
                }
                _currentFruit = FruitSpawner.CreateFruit(_snakeParts.ToList());
                GameFlowController.DecreaseDelay();
            }
            else
            {
                Graphics.ClearVisualizedObject(_snakeParts.Dequeue());
            }
            EnqueueNewSnakeUnit();

            if (snakeHead.X > Console.BufferWidth - 2 || snakeHead.Y > Console.BufferHeight - 2 || snakeHead.X < 1 || snakeHead.Y < 2)
                GameFlowController.LoseGame();
            else
            {
                foreach (SnakeObject snakePart in _snakeParts)
                {
                    if (snakePart != snakeHead && snakePart.Equals(snakeHead))
                        GameFlowController.LoseGame();
                }
            }
        }
        private static void EnqueueNewSnakeUnit()
        {
            if (_currentDirection == GameKeys.Up)
            {
                _snakeParts.Enqueue(
                    new SnakeObject(GetReadOnlySnakeParts()[_snakeParts.Count - 1].X,
                    GetReadOnlySnakeParts()[_snakeParts.Count - 1].Y - 1, SnakeShape));
            }
            else if (_currentDirection == GameKeys.Down)
            {
                _snakeParts.Enqueue(
                    new SnakeObject(GetReadOnlySnakeParts()[_snakeParts.Count - 1].X,
                    GetReadOnlySnakeParts()[_snakeParts.Count - 1].Y + 1, SnakeShape));
            }
            else if (_currentDirection == GameKeys.Left)
            {
                _snakeParts.Enqueue(
                    new SnakeObject(GetReadOnlySnakeParts()[_snakeParts.Count - 1].X - 1,
                    GetReadOnlySnakeParts()[_snakeParts.Count - 1].Y, SnakeShape));
            }
            else if (_currentDirection == GameKeys.Right)
            {
                _snakeParts.Enqueue(
                    new SnakeObject(GetReadOnlySnakeParts()[_snakeParts.Count - 1].X + 1,
                    GetReadOnlySnakeParts()[_snakeParts.Count - 1].Y, SnakeShape));
            }
        }
        private static IReadOnlyList<SnakeObject> GetReadOnlySnakeParts()
        {
            return _snakeParts.ToList();
        }
    }
}
