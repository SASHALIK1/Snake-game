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
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(WallSymbol, Console.BufferWidth));

            Console.SetCursorPosition(0, Console.BufferHeight - 1);
            Console.Write(new string(WallSymbol, Console.BufferWidth));

            for (int i = 0; i < Console.BufferHeight; i++)
            {
                VisualizeChar(0, i, WallSymbol);

                VisualizeChar(Console.BufferWidth - 1, i, WallSymbol);
            }
        }
        public static void ShowGameOverText()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(GameOverText);
        }
        public static void ClearVisualizedObject(GameObject gameObject)
        {
            VisualizeChar(gameObject.X, gameObject.Y, ' ');
        }
        private static void VisualizeChar(int coordinateX, int coordinateY, char symbol)
        {
            Console.SetCursorPosition(coordinateX, coordinateY);
            Console.Write(symbol);
        }
    }
}
