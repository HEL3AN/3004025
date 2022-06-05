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

        internal static readonly int consoleHeight = 30;
        internal static readonly int consoleWidth = 105;

        internal static readonly double consoleRatio = consoleWidth / consoleHeight;

        private static DateTime time = DateTime.Now;

        private static readonly string appVersion = "0.0.1";

        private static WindowList currentWindow = WindowList.MainMenu;

        internal static ConsoleKey key;
        
        #region ColorParam
        internal static double textColorFactor = 0.8;
        internal static string textColorGreen = "\x1b[38;2;" + 0 + ";" + Convert.ToInt32(255 * textColorFactor) + ";" + 0 + "m";
        internal static string textColorWhite = "\x1b[38;2;" + Convert.ToInt32(255 * textColorFactor) + ";" + Convert.ToInt32(255 * textColorFactor) + ";" + Convert.ToInt32(255 * textColorFactor) + "m";
        #endregion

        public static void Main()
        {
            var handle = GetStdHandle(-11);
            GetConsoleMode(handle, out int mode);
            SetConsoleMode(handle, mode | 0x4);

            Thread keyReader = new(KeyReader);
            keyReader.Start();

            Initialization();

            while (true)
            {
                DrawWindow(currentWindow);
                ClearKey();
                Thread.Sleep(10);                               
            }
        }      

        public static void ReloadTextColors()
        {
            textColorFactor = Math.Round(textColorFactor, 1);
            textColorGreen = "\x1b[38;2;" + 0 + ";" + Convert.ToInt32(255 * textColorFactor) + ";" + 0 + "m";
            textColorWhite = "\x1b[38;2;" + Convert.ToInt32(255 * textColorFactor) + ";" + Convert.ToInt32(255 * textColorFactor) + ";" + Convert.ToInt32(255 * textColorFactor) + "m";
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
            //Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void ChangeWindow(WindowList window)
        {
            currentWindow = window;
            Console.Clear();
            Thread.Sleep(120);
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
            switch(window)
            {
                case WindowList.MainMenu:
                    MainMenu.Tick();
                    break;
                case WindowList.Introduction: //добавить запуск introduction
                    Console.Clear();
                    ErrorCather.ErrorMessageWithOutClosed("Этот раздел еще не готов!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    currentWindow = WindowList.MainMenu;
                    break;
                case WindowList.Setting:
                    Setting.Tick();
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
                key = Console.ReadKey(true).Key;
            }
        }
    }
}

    
