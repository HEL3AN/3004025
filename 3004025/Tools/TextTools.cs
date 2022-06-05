using System;

namespace _3004025
{
    public class TextTools
    {
        public enum Position : byte
        {
            LeftUp,
            LeftCenter,
            LeftDown,
            MiddleUp,
            MiddleCenter,
            MiddleDown,
            RightUp,
            RightCenter,
            RightDown
        }

        public static void WriteText(string text, Position position)
        {
            if (text == null || text == "")
            {
                ErrorCather.ErrorMessage("Поле со значение text пустое!");
            }

            switch (position){
                case Position.LeftUp:
                    Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1);
                    Console.WriteLine(text);
                    break;
                case Position.LeftCenter:
                    Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - (text.Length / Display.consoleWidth) - 1);
                    Console.WriteLine(text);
                    break;
                case Position.LeftDown:
                    Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - 1);
                    Console.WriteLine(text);
                    break;
                case Position.MiddleUp:
                    if (text.Length / Display.consoleWidth < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Display.consoleWidth / 2 - text.Length / 2, 1);
                        Console.WriteLine(text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / Display.consoleWidth + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(text[i]);
                            currentChar++;

                            if(currentChar == Display.consoleWidth - Convert.ToInt32(Display.consoleRatio) && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth - Convert.ToInt32(Display.consoleRatio) && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 2 - (text.Length - i) / 2, 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
            }
            //Console.WriteLine(text);

        }
    }
}
