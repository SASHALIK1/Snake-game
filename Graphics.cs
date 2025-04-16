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
        public static void VisualizeList(IEnumerable<GameObject> visualizableObjects)
        {
            foreach (var visualizableObject in visualizableObjects)
            {
                VisualizeObject(visualizableObject);
            }
        }
        public static void VisualizeObject(GameObject visualizableObject)
        {
            Console.SetCursorPosition(visualizableObject.X, visualizableObject.Y);
            Console.Write(visualizableObject.Shape);
        }
        public static void ShowGameOverText()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(GameOverText);
        }
        public static void ClearVisualizedObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.X, gameObject.Y);
            Console.Write(' ');
        }
    }
}
