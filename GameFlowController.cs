using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    class GameFlowController
    {
        private const int MinGameDelay = 190;
        private const int DelayChangeStep = 5;
        public static bool IsGameRunnig { get; private set; } = true;
        public static int CurrentGameDeleay { get; private set; } = 400;
        private static bool _isUpdaterTaskRetrieved = false;
        public static void DecreaseDelay()
        {
            if (CurrentGameDeleay > MinGameDelay)
            {
                CurrentGameDeleay -= DelayChangeStep;
            }
        }
        public static void StopGame()
        {
            IsGameRunnig = false;
            Graphics.ShowGameOverText();
        }
        public static Task GetGameUpdaterTask()
        {
            _isUpdaterTaskRetrieved = true;
            return !_isUpdaterTaskRetrieved ?
                new Task(GameUpdater) :
                throw new InvalidOperationException("Game flow task has already been retrieved.");
        }
        private static void GameUpdater()
        {
            while (IsGameRunnig)
            {
                Thread.Sleep(GameFlowController.CurrentGameDeleay);
                Snake.Move();
            }
        }
    }
}
