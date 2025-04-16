namespace Snake_game
{
    internal class Program
    {
        public static bool IsGameRunnig { get; set; } = true;
        static void Main(string[] args)
        {
            if (OperatingSystem.IsWindows())
            {
                SetConsoleConfigurations();


                Task readKeyTask = new Task(InputHandle);
                Task gameUpdaterTask = new Task(GameLoop);

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
        private static void GameLoop()
        {
            while (IsGameRunnig)
            {
                Snake.Move();

                Thread.Sleep(500);
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
        private static void InputHandle()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                Snake.Direction = keyInfo.Key;
            }
        }

    }
}
