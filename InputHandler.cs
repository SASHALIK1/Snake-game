﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    internal static class InputHandler
    {
        private static bool _isCheckKeyTaskRetrieved = false;
        public static Task GetCheckKeyTask()
        {
            if (!_isCheckKeyTaskRetrieved)
            {
                _isCheckKeyTaskRetrieved = true;
                return new Task(CheckKey);
            }
            throw new InvalidOperationException("Check key task has already been retrieved.");
        }
        private static void CheckKey()
        {
            while (GameFlowController.IsGameRunnig)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                Snake.Direction = keyInfo.Key;
            }
        }
    }
}
