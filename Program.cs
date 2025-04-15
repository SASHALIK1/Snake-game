namespace Snake_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;
            Console.BufferHeight = 16;
            Console.BufferWidth = 32;


            Task readKeyTask = new Task(InputHandle);
            Task gameUpdaterTask = new Task(GameLoop);

            readKeyTask.Start();
            gameUpdaterTask.Start();

            gameUpdaterTask.Wait();

            Console.ReadKey();
        }
        private static void GameLoop()
        {
            while (true)
            {
                Snake.Move();

                Thread.Sleep(1000);
            }
        }
        private static void InputHandle()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                Snake.Direction = keyInfo.KeyChar;
            }
        }

    }
}
