using Snake_game.Data;
using Snake_game.Game;
using Snake_game.InputManaging;

namespace Snake_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (OperatingSystem.IsWindows())
            {
                SetConsoleConfigurations();

                GameStatsManager.LoadData();

                Task readKeyTask = InputHandler.GetCheckKeyTask();
                Task gameUpdaterTask = GameFlowController.GetGameUpdaterTask();

                readKeyTask.Start();
                gameUpdaterTask.Start();

                gameUpdaterTask.Wait();

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Only windows supported");
            }
        }
        private static void SetConsoleConfigurations()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;
            Console.BufferHeight = 16;
            Console.BufferWidth = 32;
        }
    }
}
