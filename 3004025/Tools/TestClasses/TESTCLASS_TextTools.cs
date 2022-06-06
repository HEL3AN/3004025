using System;

namespace _3004025
{
    internal class TESTCLASS_TextTools
    {
        private static byte currentPos = 0;
        private static byte currentTextSize = 0;
        public static void Tick()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("TESTCLASS_TextTools");
            Console.ForegroundColor = ConsoleColor.White;

            switch (Display.key)
            {
                case ConsoleKey.Enter:
                    Console.Clear();
                    if (currentTextSize == 0)
                    {
                        TextTools.WriteText("Hello World!", (TextTools.Position)currentPos);
                        if (currentPos < 9)
                            currentPos++;
                        else if (currentPos == 9)
                            currentPos = 0;
                    }
                    else if (currentTextSize == 1)
                    {
                        TextTools.WriteText("Wikis are enabled by wiki software, otherwise known as wiki engines. A wiki engine, being a form of a content management system!", (TextTools.Position)currentPos);
                        if (currentPos < 9)
                            currentPos++;
                        else if (currentPos == 9)
                            currentPos = 0;
                    }
                    else if (currentTextSize == 2)
                    {
                        TextTools.WriteText("Wikis are enabled by wiki software, otherwise known as wiki engines. A wiki engine, being a form of a content management system, differs from other web-based systems such as blog software, in that the content is created without any defined owner or leader, and wikis have little inherent structure, allowing structure to emerge according to the needs of the users.[1] Wiki engines usually allow content to be written using a simplified markup language and sometimes edited with the help of a rich-text editor.[2] There are dozens of different wiki engines in use, both standalone and part of other software, such as bug tracking systems. Some wiki engines are open-source, whereas others are proprietary. Some permit control over different functions (levels of access); for example, editing rights may permit changing, adding, or removing material. Others may permit access without enforcing access control. Other rules may be imposed to organize content.", (TextTools.Position)currentPos);
                        if (currentPos < 9)
                            currentPos++;
                        else if (currentPos == 9)
                            currentPos = 0;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (currentTextSize >= 2)
                        currentTextSize = 0;
                    else
                        currentTextSize++;
                    currentPos = 0;
                    break;

                case ConsoleKey.DownArrow:
                    if (currentTextSize <= 0)
                        currentTextSize = 2;
                    else
                        currentTextSize--;
                    currentPos = 0;
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
}
