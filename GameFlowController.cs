using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    class GameFlowController
    {
        public static bool IsGameRunnig { get; private set; } = true;
        public static int CurrentGameDeleay { get; private set; } = 400;
        private static bool isGameUpdaterTaskGotten = false;

        public static void StopGame()
        {
            IsGameRunnig = false;
            Graphics.ShowGameOverText();
        }
        public static Task GetGameUpdaterTask()
        {
            return !isGameUpdaterTaskGotten ?
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
