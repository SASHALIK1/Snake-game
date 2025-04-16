﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    static class Snake
    {
        private const char SnakeShape = '0';
        private static Queue<SnakePart> _snakeParts { get; set; } = new Queue<SnakePart>(new[]
{
            new SnakePart(8, 13, SnakeShape),
            new SnakePart(8, 12, SnakeShape)
        });

        private static GameKeys _currentDirection = GameKeys.Up;
        private static GameKeys _direction = _currentDirection;
        private static Fruit _currentFruit = FruitSpawner.CreateFruit(_snakeParts.ToList());
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
            }
        }
        private static void CheckCollision()
        {
            SnakePart snakeHead = _snakeParts.Last();
            if (_currentFruit != null && snakeHead.X == _currentFruit.X && snakeHead.Y == _currentFruit.Y)
            {
                _currentFruit = FruitSpawner.CreateFruit(_snakeParts.ToList());
                GameFlowController.DecreaseDelay();
            }
            else
            {
                Graphics.ClearVisualizedObject(_snakeParts.Dequeue());
            }
            EnqueueNewSnakeUnit();


            if (snakeHead.X > Console.BufferWidth - 2 || snakeHead.Y > Console.BufferHeight - 2 || snakeHead.X < 1 || snakeHead.Y < 1)
                GameFlowController.StopGame();
            else
            {
                foreach (SnakePart snakePart in _snakeParts)
                {
                    if (snakePart != snakeHead && snakePart.Equals(snakeHead))
                        GameFlowController.StopGame();
                }
            }
        }
        private static void EnqueueNewSnakeUnit()
        {
            if (_currentDirection == GameKeys.Up)
            {
                _snakeParts.Enqueue(
                    new SnakePart(GetReadOnlySnakeParts()[_snakeParts.Count - 1].X,
                    GetReadOnlySnakeParts()[_snakeParts.Count - 1].Y - 1, SnakeShape));
            }
            else if (_currentDirection == GameKeys.Down)
            {
                _snakeParts.Enqueue(
                    new SnakePart(GetReadOnlySnakeParts()[_snakeParts.Count - 1].X,
                    GetReadOnlySnakeParts()[_snakeParts.Count - 1].Y + 1, SnakeShape));
            }
            else if (_currentDirection == GameKeys.Left)
            {
                _snakeParts.Enqueue(
                    new SnakePart(GetReadOnlySnakeParts()[_snakeParts.Count - 1].X - 1,
                    GetReadOnlySnakeParts()[_snakeParts.Count - 1].Y, SnakeShape));
            }
            else if (_currentDirection == GameKeys.Right)
            {
                _snakeParts.Enqueue(
                    new SnakePart(GetReadOnlySnakeParts()[_snakeParts.Count - 1].X + 1,
                    GetReadOnlySnakeParts()[_snakeParts.Count - 1].Y, SnakeShape));
            }
        }
        private static IReadOnlyList<SnakePart> GetReadOnlySnakeParts()
        {
            return _snakeParts.ToList();
        }
    }
}
