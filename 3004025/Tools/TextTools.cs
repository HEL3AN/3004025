using System;
using System.Diagnostics;

namespace _3004025
{
    public class TextTools
    {
        private static string defaultTextColor = Display.textColorWhite;

        public enum Position : byte
        {
            LeftUp = 0,
            LeftCenter,
            LeftDown,
            MiddleUp,
            MiddleCenter,
            MiddleDown,
            RightUp,
            RightCenter,
            RightDown
        }

        public static void WriteTextFixPos(string text, Position position)
        {
            if (text == null || text == "")
            {
                ErrorCather.ErrorMessage("Поле со значение text пустое!");
            }

            switch (position) {

                #region LeftUp
                case Position.LeftUp:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1);
                        Console.Write(defaultTextColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(defaultTextColor + text[i]);
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
                        Console.Write(defaultTextColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - linesCount / 2 - 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(defaultTextColor + text[i]);
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
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - 1);
                        Console.Write(defaultTextColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - linesCount - 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(defaultTextColor + text[i]);
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
                        Console.Write(defaultTextColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 4 + 1, 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(defaultTextColor + text[i]);
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
                        Console.Write(defaultTextColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 4 + 1, Display.consoleHeight / 2 - linesCount / 2 - 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(defaultTextColor + text[i]);
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
                        Console.Write(defaultTextColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 4 + 1, Display.consoleHeight - 1 - linesCount);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(defaultTextColor + text[i]);
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

                #region RightUp
                case Position.RightUp:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Display.consoleWidth - text.Length, 1);
                        Console.Write(defaultTextColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(defaultTextColor + text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - 1 && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - 1 && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth - (text.Length - i - 1), 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                #region RightCenter
                case Position.RightCenter:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Display.consoleWidth - text.Length, Display.consoleHeight / 2);
                        Console.Write(defaultTextColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - linesCount / 2);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(defaultTextColor + text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - 1 && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - linesCount / 2 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - 1 && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth - (text.Length - i - 1), Display.consoleHeight / 2 - linesCount / 2 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                #region RightDown
                case Position.RightDown:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Display.consoleWidth - text.Length, Display.consoleHeight - 1);
                        Console.Write(defaultTextColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - 1 - linesCount);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(defaultTextColor + text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - 1 && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - 1 - linesCount + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - 1 && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth - (text.Length - i - 1), Display.consoleHeight - 1 - linesCount + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                default: break;
            }
        }

        public static void WriteTextFixPosColor(string text, Position position, string textColor)
        {
            if (text == null || text == "")
            {
                ErrorCather.ErrorMessage("Поле со значение text пустое!");
            }            

            switch (position)
            {

                #region LeftUp
                case Position.LeftUp:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1);
                        Console.Write(textColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(textColor + text[i]);
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
                        Console.Write(textColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - linesCount / 2 - 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(textColor + text[i]);
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
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - 1);
                        Console.Write(textColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - linesCount - 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(textColor + text[i]);
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
                        Console.Write(textColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 4 + 1, 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(textColor + text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio) && currentLine != linesCount - 1)
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
                        Console.Write(textColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 4 + 1, Display.consoleHeight / 2 - linesCount / 2 - 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(textColor + text[i]);
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
                        Console.Write(textColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 4 + 1, Display.consoleHeight - 1 - linesCount);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(textColor + text[i]);
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

                #region RightUp
                case Position.RightUp:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Display.consoleWidth - text.Length, 1);
                        Console.Write(textColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), 1);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(textColor + text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - 1 && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - 1 && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth - (text.Length - i - 1), 1 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                #region RightCenter
                case Position.RightCenter:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Display.consoleWidth - text.Length, Display.consoleHeight / 2);
                        Console.Write(textColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - linesCount / 2);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(textColor + text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - 1 && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), Display.consoleHeight / 2 - linesCount / 2 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - 1 && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth - (text.Length - i - 1), Display.consoleHeight / 2 - linesCount / 2 + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                #region RightDown
                case Position.RightDown:
                    if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
                    {
                        Console.SetCursorPosition(Display.consoleWidth - text.Length, Display.consoleHeight - 1);
                        Console.Write(textColor + text);
                    }
                    else //  длина текста требует переноса строки
                    {
                        int linesCount = text.Length / (Display.consoleWidth / 2 - Convert.ToInt32(Display.consoleRatio)) + 1;
                        int currentLine = 1;
                        int currentChar = 1;
                        Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - 1 - linesCount);
                        for (int i = 0; i < text.Length; i++)
                        {
                            Console.Write(textColor + text[i]);
                            currentChar++;

                            if (currentChar == Display.consoleWidth / 2 - 1 && currentLine != linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth / 2 + Convert.ToInt32(Display.consoleRatio), Display.consoleHeight - 1 - linesCount + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                            else if (currentChar == Display.consoleWidth / 2 - 1 && currentLine == linesCount - 1)
                            {
                                Console.SetCursorPosition(Display.consoleWidth - (text.Length - i - 1), Display.consoleHeight - 1 - linesCount + currentLine);

                                currentLine++;
                                currentChar = 1;
                            }
                        }
                    }
                    break;
                #endregion

                default: break;
            }
        }

        public static void WriteTextCustPoz(string text, int positionX, int positionY, int positionXEnd, int positionYEnd, string textColor)
        {
            positionX--;
            positionY--;
            positionXEnd--;
            positionYEnd--;
            if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(textColor + text);
            }
            else //  длина текста требует переноса строки
            {
                int linesLength = positionXEnd - positionX + 1;
                int linesCount = text.Length / linesLength + 1;
                int currentLine = 1;
                int currentChar = 1;
                Console.SetCursorPosition(positionX, positionY);
                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(textColor + text[i]);
                    currentChar++;

                    if (currentChar == linesLength && currentLine != linesCount - 1)
                    {
                        Console.SetCursorPosition(positionX, positionY + currentLine);

                        currentLine++;
                        currentChar = 1;
                    }
                    else if (currentChar == linesLength && currentLine == linesCount - 1)
                    {
                        Console.SetCursorPosition(positionX, positionY + currentLine);

                        currentLine++;
                        currentChar = 1;
                    }
                }
            }
        } // указать конец по X и Y

        public static void WriteTextCustPoz(string text, int positionX, int positionY, int length, string textColor)
        {
            positionX--;
            positionY--;
            if (text.Length / (Display.consoleWidth / 2) < 1) //  длина текста НЕ требует переноса строки
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(textColor + text);
            }
            else //  длина текста требует переноса строки
            {
                int linesLength = length;
                int linesCount = text.Length / linesLength + 1;
                int currentLine = 1;
                int currentChar = 1;
                Console.SetCursorPosition(positionX, positionY);
                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(textColor + text[i]);
                    currentChar++;

                    if (currentChar == linesLength && currentLine != linesCount - 1)
                    {
                        Console.SetCursorPosition(positionX, positionY + currentLine);

                        currentLine++;
                        currentChar = 1;
                    }
                    else if (currentChar == linesLength && currentLine == linesCount - 1)
                    {
                        Console.SetCursorPosition(positionX, positionY + currentLine);

                        currentLine++;
                        currentChar = 1;
                    }
                }
            }
        } // указать длину строки
    }
}
