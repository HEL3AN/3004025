using System.Drawing;

namespace _3004025
{
    
    public class Game
    {
        public static Vector2 vievPortCenter =  new Vector2(Display.consoleWidth / 2, Display.consoleHeight / 2);
               
        public static Map_Test_Class map = new Map_Test_Class(@"..\..\..\Universe\Maps\Maps_txt\Map_Test2.txt");

        static Person person1 = new Person(0, "Dude", "Homies", "NULL", '@', vievPortCenter, new Vector2(1, 8), 1);

        public static void Tick()
        {
            Console.Clear();

            Input();

            person1.Tick();
            map.Tick();

            map.Draw();
            person1.Draw(Display.textColorGreen);

            TextTools.ShowDialog("");
            
            //TextTools.WriteTextFixPos("X = " + map.mapOffset.X + " Y = " + map.mapOffset.Y, TextTools.Position.MiddleCenter);
        }

        private static void Input()
        {
            switch (Display.key)
            {
                case ConsoleKey.Backspace or ConsoleKey.Escape:
                    Display.ChangeWindow(WindowList.MainMenu);
                    break;
                default:
                    break;
            }
        }
    }            
}
