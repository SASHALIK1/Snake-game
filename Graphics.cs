using Snake_game.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    internal static class Graphics
    {
        private const string GameOverText = "\r\n" +
            "████████████████████████████████\r\n" +
            "█┼┼┼█████┼┼┼██┼┼┼┼┼┼██┼┼█████┼┼█\r\n" +
            "█┼┼┼█████┼┼┼█┼┼┼██┼┼┼█┼┼█████┼┼█\r\n" +
            "██┼┼┼███┼┼┼██┼┼████┼┼█┼┼█████┼┼█\r\n" +
            "███┼┼┼┼┼┼┼███┼┼████┼┼█┼┼█████┼┼█\r\n" +
            "█████┼┼┼█████┼┼████┼┼█┼┼█████┼┼█\r\n" +
            "█████┼┼┼█████┼┼┼██┼┼┼█┼┼┼███┼┼┼█\r\n" +
            "█████┼┼┼██████┼┼┼┼┼┼███┼┼┼┼┼┼┼██\r\n" +
            "████████████████████████████████\r\n" +
            "█┼┼█████┼┼┼┼┼┼┼█┼┼┼┼┼┼█┼┼┼┼┼┼┼┼█\r\n" +
            "█┼┼█████┼┼███┼┼█┼┼█████┼┼███████\r\n" +
            "█┼┼█████┼┼███┼┼█┼┼┼┼┼┼█┼┼┼┼┼┼███\r\n" +
            "█┼┼█████┼┼███┼┼█████┼┼█┼┼███████\r\n" +
            "█┼┼█████┼┼███┼┼█████┼┼█┼┼███████\r\n" +
            "█┼┼┼┼┼┼█┼┼┼┼┼┼┼█┼┼┼┼┼┼█┼┼┼┼┼┼┼┼█";
        private const char WallSymbol = '█';
        public static void VisualizeList(IEnumerable<GameObject> visualizableObjects)
        {
            foreach (var visualizableObject in visualizableObjects)
            {
                VisualizeObject(visualizableObject);
            }
        }
        public static void VisualizeObject(GameObject visualizableObject)
        {
            VisualizeChar(visualizableObject.X, visualizableObject.Y, visualizableObject.Shape);
        }
        public static void VisualizeWalls()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write(new string(WallSymbol, Console.BufferWidth));

            Console.SetCursorPosition(0, Console.BufferHeight - 1);
            Console.Write(new string(WallSymbol, Console.BufferWidth));

            for (int i = 1; i < Console.BufferHeight; i++)
            {
                VisualizeChar(0, i, WallSymbol);

                VisualizeChar(Console.BufferWidth - 1, i, WallSymbol);
            }
        }
        public static void ShowGameOverText(int currentScore, int highScore)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            
            if (highScore < currentScore)
            {
                Console.Write(GameOverText + $"\r\nNew high score!: {currentScore}");
            }
            else
            {
                Console.Write(GameOverText + 
                    $"\r\nYour final score: {currentScore}" +
                    $"\r\nHigh score: {highScore}");
            }
            
        }
        public static void ClearVisualizedObject(GameObject gameObject)
        {
            VisualizeChar(gameObject.X, gameObject.Y, ' ');
        }
        public static void VisualizeText(int coordinateX, int coordinateY, string text)
        {
            Console.SetCursorPosition(coordinateX, coordinateY);
            Console.WriteLine(text);
        }
        private static void VisualizeChar(int coordinateX, int coordinateY, char symbol)
        {
            Console.SetCursorPosition(coordinateX, coordinateY);
            Console.Write(symbol);
        }
    }
}
