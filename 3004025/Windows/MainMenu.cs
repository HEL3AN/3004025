﻿using System.Threading;

namespace _3004025
{
    public class MainMenu
    {
        private static List<string> mainMenuCommands = new(capacity: 3) { "Войти", "Настройки", "Выход" };        
        private static int currentCommand = 0;

        public static void Tick()
        {
            Input();

            Draw();
        }

        private static void Draw()
        {
            Display.VersionInfo();

            for (int i = 0; i < mainMenuCommands.Count; i++)
            {
                if (currentCommand == i)
                {
                    Console.CursorTop = Display.consoleHeight / 2 + 1 - mainMenuCommands.Count + i;
                    Console.CursorLeft = Display.consoleWidth / 2 - (mainMenuCommands[i].Length + 2) / 2;
                    Console.Write(Display.textColorWhite + $">{mainMenuCommands[i]}<");
                }
                else
                {
                    Console.CursorTop = Display.consoleHeight / 2 + 1 - mainMenuCommands.Count + i;
                    Console.CursorLeft = Display.consoleWidth / 2 - mainMenuCommands[i].Length / 2;
                    Console.Write(Display.textColorGreen + mainMenuCommands[i]);
                }
            }

            Console.SetCursorPosition(Display.consoleWidth / 2 - 4, Display.consoleHeight - 1);
            Console.Write(Display.textColorGreen + Display.GetTime().ToLongTimeString());
        }

        private static void Input()
        {
            switch (Display.key)
            {
                case ConsoleKey.UpArrow or ConsoleKey.W:
                    if (currentCommand - 1 < 0)
                        currentCommand = mainMenuCommands.Count - 1;
                    else
                        currentCommand--;
                    Console.Clear();
                    break;

                case ConsoleKey.DownArrow or ConsoleKey.S:
                    if (currentCommand + 1 > mainMenuCommands.Count - 1)
                        currentCommand = 0;
                    else
                        currentCommand++;
                    Console.Clear();
                    break;

                case ConsoleKey.Enter or ConsoleKey.Spacebar:
                    if (currentCommand == 0)
                        Display.ChangeWindow(WindowList.Game);
                    else if (currentCommand == 1)
                        Display.ChangeWindow(WindowList.Setting);
                    else if (currentCommand == 2)
                    {
                        Console.Clear();
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                    break;

                case ConsoleKey.Escape:
                    Console.Clear();
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    break;

                case ConsoleKey.F1:
                    Display.ChangeWindow(WindowList.TESTCLASS_TextTools);
                    break;

                default:
                    break;
            }
        }
    }
}
