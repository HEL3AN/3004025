using System;

namespace _3004025
{
    public class MapDrawer
    {
        public char?[,] mapArray; // содержимое карты

        public Vector2 mapSize; // размер карты
        public Vector2 mapOffset = new Vector2(); // отступ карты для верного отображения в viewport

        public MapDrawer(string path)
        {
            StreamReader map_file = new StreamReader(path);

            mapSize = new Vector2(map_file.ReadLine().Length, 0);

            map_file.Close(); // закрытие файла

            map_file = new StreamReader(path); // перезапуск файла

            mapSize.Y = map_file.ReadToEnd().Length / mapSize.X; // нахожение размера карты по Y

            map_file.Close(); // закрытие файла

            map_file = new StreamReader(path); // перезапуск файла

            mapArray = new char?[mapSize.X, mapSize.Y]; // инициализая массива карты

            List<char[]> map_line_list = new List<char[]>(); // создание построчного листа для правильного считывания символов с файла

            for (int i = 0; i < mapSize.Y; i++)
            {
                map_line_list.Add(map_file.ReadLine().ToCharArray()); // заполнение листа
            }

            for(int i = 0; i < mapSize.Y; i++)
            {
                for (int j = 0; j < mapSize.X; j++)
                {
                    mapArray[j, i] = map_line_list[i][j]; // заполнение массива самой карты           
                }
            }

            map_line_list.Clear(); // очистка листа
        }

        public void Draw() // отрисовка карты
        {
            for (int i = mapOffset.Y; i < Display.consoleHeight + mapOffset.Y; i++)
            {
                for (int j = mapOffset.X; j < Display.consoleWidth + mapOffset.X; j++)
                {
                    Console.SetCursorPosition(j - mapOffset.X, i - mapOffset.Y);
                    if ((j <= mapSize.X - 1 && i <= mapSize.Y - 1) && (j >= 0 && i >= 0))
                        if (MapObject.OutOfMap.Any(x => x == mapArray[j, i]) == true)
                        {
                            Console.Write(Display.textColorRed + mapArray[j, i]);
                        }
                        else
                            Console.Write(Display.textColorWhite + mapArray[j, i]);
                    else
                        Console.Write(Display.textColorRed + MapObject.OutOfMap[0]); // заполнение за границами карты
                }
            }
        }

        public void Tick()
        {
            
        }                    
    }
}
