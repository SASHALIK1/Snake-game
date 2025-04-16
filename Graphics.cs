using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    internal static class Graphics
    {
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
    }
}
