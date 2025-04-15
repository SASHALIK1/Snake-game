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

            while (true)
            {
                Snake.Move();

                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }
    }
}
