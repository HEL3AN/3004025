using System;

namespace _3004025
{
    internal class TESTCLASS_TextTools
    {
        private static byte currentPos = 0;
        private static byte currentTextSize = 0;
        private static bool useColor = false;
        private static byte currentTextColor = 0;

        private static bool isFirstTick = true;

        public static void Tick()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(Display.textColorRed + "TESTCLASS_TextTools" + "   " + "useColor = " + useColor.ToString());
            if (isFirstTick)
            {
                if (!useColor)
                    ShowTextWOColor();
                else
                    ShowTextWithColor();

                isFirstTick = false;
            }

            if (!useColor)
            {
                switch (Display.key)
                {
                    case ConsoleKey.Enter:
                        if (currentPos < 9)
                            currentPos++;
                        else if (currentPos == 9)
                            currentPos = 0;
                        ShowTextWOColor();
                        break;

                    case ConsoleKey.UpArrow:
                        if (currentTextSize >= 2)
                            currentTextSize = 0;
                        else
                            currentTextSize++;
                        ShowTextWOColor();
                        break;

                    case ConsoleKey.DownArrow:
                        if (currentTextSize <= 0)
                            currentTextSize = 2;
                        else
                            currentTextSize--;
                        ShowTextWOColor();
                        break;

                    case ConsoleKey.F2:
                        Console.Clear();
                        useColor = !useColor;
                        currentPos = 0;
                        isFirstTick = true;
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        break;

                    case ConsoleKey.F1:
                        Display.ChangeWindow(WindowList.MainMenu);
                        break;
                }
            }

            else if (useColor)
            {
                switch (Display.key)
                {
                    case ConsoleKey.Enter:
                        if (currentPos < 9)
                            currentPos++;
                        else if (currentPos == 9)
                            currentPos = 0;
                        ShowTextWithColor();                      
                        break;

                    case ConsoleKey.UpArrow:
                        if (currentTextSize >= 2)
                            currentTextSize = 0;
                        else
                            currentTextSize++;
                        ShowTextWithColor();
                        break;

                    case ConsoleKey.DownArrow:
                        if (currentTextSize <= 0)
                            currentTextSize = 2;
                        else
                            currentTextSize--;
                        ShowTextWithColor();
                        break;

                    case ConsoleKey.RightArrow:
                        if (currentTextColor >= Display.textColor.Count - 1)
                            currentTextColor = 0;
                        else
                            currentTextColor++;
                        ShowTextWithColor();
                        break;

                    case ConsoleKey.LeftArrow:
                        if (currentTextColor <= 0)
                            currentTextColor = Convert.ToByte(Display.textColor.Count - 1);
                        else
                            currentTextColor--;
                        ShowTextWithColor();
                        break;

                    case ConsoleKey.F2:
                        Console.Clear();
                        useColor = !useColor;
                        currentPos = 0;
                        isFirstTick = true;
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        break;

                    case ConsoleKey.F1:
                        Display.ChangeWindow(WindowList.MainMenu);
                        break;
                }
            }
        }

        private static void ShowTextWithColor()
        {
            Console.Clear();
            if (currentTextSize == 0)
            {
                TextTools.WriteTextFixPosColor("Hello World!", (TextTools.Position)currentPos, Display.textColor[currentTextColor]);             
            }
            else if (currentTextSize == 1)
            {
                TextTools.WriteTextFixPosColor("Wikis are enabled by wiki software, otherwise known as wiki engines. A wiki engine, being a form of a content management system!", (TextTools.Position)currentPos, Display.textColor[currentTextColor]);
            }
            else if (currentTextSize == 2)
            {
                TextTools.WriteTextFixPosColor("Wikis are enabled by wiki software, otherwise known as wiki engines. A wiki engine, being a form of a content management system, differs from other web-based systems such as blog software, in that the content is created without any defined owner or leader, and wikis have little inherent structure, allowing structure to emerge according to the needs of the users.[1] Wiki engines usually allow content to be written using a simplified markup language and sometimes edited with the help of a rich-text editor.[2] There are dozens of different wiki engines in use, both standalone and part of other software, such as bug tracking systems. Some wiki engines are open-source, whereas others are proprietary. Some permit control over different functions (levels of access); for example, editing rights may permit changing, adding, or removing material. Others may permit access without enforcing access control. Other rules may be imposed to organize content.", (TextTools.Position)currentPos, Display.textColor[currentTextColor]);
            }
        }

        private static void ShowTextWOColor()
        {
            Console.Clear();
            if (currentTextSize == 0)
            {
                TextTools.WriteTextFixPos("Hello World!", (TextTools.Position)currentPos);
            }
            else if (currentTextSize == 1)
            {
                TextTools.WriteTextFixPos("Wikis are enabled by wiki software, otherwise known as wiki engines. A wiki engine, being a form of a content management system!", (TextTools.Position)currentPos);
            }
            else if (currentTextSize == 2)
            {
                TextTools.WriteTextFixPos("Wikis are enabled by wiki software, otherwise known as wiki engines. A wiki engine, being a form of a content management system, differs from other web-based systems such as blog software, in that the content is created without any defined owner or leader, and wikis have little inherent structure, allowing structure to emerge according to the needs of the users.[1] Wiki engines usually allow content to be written using a simplified markup language and sometimes edited with the help of a rich-text editor.[2] There are dozens of different wiki engines in use, both standalone and part of other software, such as bug tracking systems. Some wiki engines are open-source, whereas others are proprietary. Some permit control over different functions (levels of access); for example, editing rights may permit changing, adding, or removing material. Others may permit access without enforcing access control. Other rules may be imposed to organize content.", (TextTools.Position)currentPos);
            }
        }
    }
}
