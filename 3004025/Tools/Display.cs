﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace _3004025
{
    public class Display
    {
        #region DLLImport
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);
        #endregion

        internal static readonly int consoleHeight = 36;
        internal static readonly int consoleWidth = 74;

        internal static readonly double consoleRatio = consoleWidth / consoleHeight;

        private static DateTime time = DateTime.Now;
        private static DateTime oldTime = DateTime.Now;

        private static readonly string appVersion = "0.0.1";

        private static WindowList currentWindow = WindowList.MainMenu; //изменяет начально окно отрисовки
        private static WindowList oldWindow;

        internal static ConsoleKey key;
        internal static bool keyReaderSwitcher = false;
        
        #region ColorParam
        internal static double textColorFactor = 0.8;
        internal static string textColorRed = "\x1b[38;2;" + Convert.ToInt32(255 * textColorFactor) + ";" + 0 + ";" + 0 + "m";
        internal static string textColorGreen = "\x1b[38;2;" + 0 + ";" + Convert.ToInt32(255 * textColorFactor) + ";" + 0 + "m";
        internal static string textColorBlue = "\x1b[38;2;" + 0 + ";" + 0 + ";" + Convert.ToInt32(255 * textColorFactor) + "m";
        internal static string textColorWhite = "\x1b[38;2;" + Convert.ToInt32(255 * textColorFactor) + ";" + Convert.ToInt32(255 * textColorFactor) + ";" + Convert.ToInt32(255 * textColorFactor) + "m";
        #endregion

        public static List<string> textColor = new List<string>()
        {
            textColorRed,
            textColorGreen,
            textColorBlue,
            textColorWhite
        };

        public static void Main()
        {
            var handle = GetStdHandle(-11);
            GetConsoleMode(handle, out int mode);
            SetConsoleMode(handle, mode | 0x4);

            Thread keyReader = new (KeyReader);
            keyReader.Start();

            Initialization();

            while (true)
            {
                if (key != ConsoleKey.NoName || currentWindow != oldWindow)
                {
                    oldWindow = currentWindow;
                    DrawWindow(currentWindow);
                    oldTime = DateTime.Now;
                }
                else if (currentWindow != WindowList.Game && currentWindow != WindowList.TESTCLASS_TextTools && GetTime().Second == oldTime.Second + 1 || GetTime().Second == 0 || currentWindow != oldWindow)
                {
                    oldWindow = currentWindow;
                    DrawWindow(currentWindow);
                    oldTime = DateTime.Now;
                }
                ClearKey();
                Thread.Sleep(10);
            }
        }      

        public static void ReloadTextColors()
        {
            textColorFactor = Math.Round(textColorFactor, 1);

            textColorRed = "\x1b[38;2;" + Convert.ToInt32(255 * textColorFactor) + ";" + 0 + ";" + 0 + "m";
            textColorGreen = "\x1b[38;2;" + 0 + ";" + Convert.ToInt32(255 * textColorFactor) + ";" + 0 + "m";
            textColorBlue = "\x1b[38;2;" + 0 + ";" + 0 + ";" + Convert.ToInt32(255 * textColorFactor) + "m";
            textColorWhite = "\x1b[38;2;" + Convert.ToInt32(255 * textColorFactor) + ";" + Convert.ToInt32(255 * textColorFactor) + ";" + Convert.ToInt32(255 * textColorFactor) + "m";

            textColor = new List<string>()
            {
                textColorRed,
                textColorGreen,
                textColorBlue,
                textColorWhite
            };
        }

        public static void Initialization()
        {
#pragma warning disable CA1416 // Проверка совместимости платформы
            Console.WindowHeight = consoleHeight;
            Console.WindowWidth = consoleWidth;
            Console.BufferHeight = consoleHeight;
            Console.BufferWidth = consoleWidth;
#pragma warning restore CA1416 // Проверка совместимости платформы
            Console.CursorVisible = false;
            Console.Title = "3004025 Version:" + appVersion;
        }

        public static void ChangeWindow(WindowList window)
        {
            oldWindow = currentWindow;
            currentWindow = window;
            //Thread.Sleep(120);
        }  

        public static DateTime GetTime()
        {
            time = DateTime.Now;
            return time; 
        }

        public static void VersionInfo()
        {
            Console.SetCursorPosition(1, consoleHeight - 1);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Version:" + appVersion);
            Console.ForegroundColor = ConsoleColor.Green;
        }
        
        public static void TurnCursor(bool turn)
        {
            Console.CursorVisible = turn;
        }

        private static void DrawWindow(WindowList window)
        {
            Console.Clear();
            switch (window)
            {
                case WindowList.MainMenu:
                    MainMenu.Tick();
                    break;
                case WindowList.Introduction:
                    Introduction.Tick();
                    break;
                case WindowList.Game:
                    Game.Tick();
                    break;
                case WindowList.Setting:
                    Setting.Tick();
                    break;
                case WindowList.TESTCLASS_TextTools:
                    TESTCLASS_TextTools.Tick();
                    break;
            }
        }

        private static void ClearKey()
        {
            key = ConsoleKey.NoName;
        }

        private static void KeyReader()
        {
            while (true)
            {
                if (!keyReaderSwitcher)
                    key = Console.ReadKey(true).Key;
            }
        }
    }
}

    
