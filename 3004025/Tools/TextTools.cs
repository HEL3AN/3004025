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

                #region LeftUp
                case Position.LeftUp:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1);
                        Console.WriteLine(text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                #region LeftCenter
                case Position.LeftCenter:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - 1);
                        Console.WriteLine(text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - linesCount / 2 - 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - linesCount / 2 + currentLine - 1);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - linesCount / 2 + currentLine - 1);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                #region LeftDown
                case Position.LeftDown:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2);
                        Console.WriteLine(text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - linesCount - 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - linesCount + currentLine - 1);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - linesCount + currentLine - 1);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                #region MiddleUp
                case Position.MiddleUp:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Display.consoleWidth / 2 - text.Length / 2, 1);
                        Console.WriteLine(text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 4 + 1, 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(text[i]);
                            currentChar++;

                            if(currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 4 + 1, 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 2 - (text.Length - i) / 2 - 1, 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                #region MiddleCenter
                case Position.MiddleCenter:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Display.consoleWidth / 2 - text.Length / 2, Display.consoleHeight / 2 - 1);
                        Console.WriteLine(text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 4 + 1, Display.consoleHeight / 2 - linesCount / 2 - 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 4 + 1, Display.consoleHeight / 2 - linesCount / 2 - 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 2 - (text.Length - i) / 2 - 1, Display.consoleHeight / 2 - linesCount / 2 - 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                #region MiddleDown
                case Position.MiddleDown:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Display.consoleWidth / 2 - text.Length / 2, Display.consoleHeight - 1);
                        Console.WriteLine(text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 4 + 1, Display.consoleHeight - 1 - linesCount);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 4 + 1, Display.consoleHeight - 1 - linesCount + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 2 - (text.Length - i) / 2 - 1, Display.consoleHeight - 1 - linesCount + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;

                    #endregion

            }
            //Console.WriteLine(text);

        }
    }
}
