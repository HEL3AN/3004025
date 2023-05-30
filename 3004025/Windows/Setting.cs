namespace _3004025
{
    public class Setting
    {
        private static List<string> settingCommands = new(capacity: 1) { "Яркость" };
        private static int currentCommand = 0;
        private static bool commandIsUse = false;
        public static void Tick()
        {
            Input();

            Draw();
        }

        private static void Draw()
        {
            Console.SetCursorPosition(Display.consoleWidth / 2 - 4, 1);
            Console.WriteLine(Display.textColorGreen + "Настройки");

            Display.VersionInfo();

            for (int i = 0; i < settingCommands.Count; i++)
            {
                switch (currentCommand)
                {
                    case 0:
                        if (!commandIsUse)
                        {
                            Console.SetCursorPosition(Display.consoleWidth / 2 - settingCommands[i].Length / 2 - 1, Display.consoleHeight / 2 - settingCommands.Count / 2);
                            Console.Write(Display.textColorGreen + $">{settingCommands[i]}<");
                            Console.SetCursorPosition(Display.consoleWidth / 2 - Display.textColorFactor.ToString().Length / 2, Console.CursorTop + 1);
                            Console.Write(Display.textColorGreen + Display.textColorFactor);
                        }
                        else if (commandIsUse)
                        {
                            Console.SetCursorPosition(Display.consoleWidth / 2 - settingCommands[i].Length / 2, Display.consoleHeight / 2 - settingCommands.Count / 2);
                            Console.Write(Display.textColorWhite + settingCommands[i]);
                            Console.SetCursorPosition(Display.consoleWidth / 2 - Display.textColorFactor.ToString().Length / 2, Console.CursorTop + 1);
                            Console.Write(Display.textColorWhite + Display.textColorFactor);
                        }
                        break;
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
                    if (!commandIsUse)
                    {
                        if (currentCommand - 1 < 0)
                            currentCommand = settingCommands.Count - 1;
                        else
                            currentCommand--;
                    }
                    else if (commandIsUse)
                    {
                        switch (currentCommand)
                        {
                            case 0:
                                if (Display.textColorFactor < 1)
                                    Display.textColorFactor += 0.1;
                                Display.ReloadTextColors();
                                break;
                        }
                        Display.ReloadTextColors();
                    }
                    Console.Clear();
                    break;

                case ConsoleKey.DownArrow or ConsoleKey.S:
                    if (!commandIsUse)
                    {
                        if (currentCommand + 1 > settingCommands.Count - 1)
                            currentCommand = 0;
                        else
                            currentCommand++;
                        break;
                    }
                    else if (commandIsUse)
                    {
                        switch (currentCommand)
                        {
                            case 0:
                                if (Display.textColorFactor > 0.1)
                                    Display.textColorFactor -= 0.1;
                                Display.ReloadTextColors();
                                break;
                        }
                    }
                    break;

                case ConsoleKey.Enter or ConsoleKey.Spacebar:
                    commandIsUse = !commandIsUse;
                    Console.Clear();
                    break;
                case ConsoleKey.Escape or ConsoleKey.Backspace:
                    if (!commandIsUse)
                    {
                        Display.ChangeWindow(WindowList.MainMenu);
                        currentCommand = 0;
                    }
                    else if (commandIsUse)
                        commandIsUse = !commandIsUse;
                    break;
            }
        }
    }
}
