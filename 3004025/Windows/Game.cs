using System.Drawing;

namespace _3004025
{
    public class Game
    {       
        public static Vector2 vievPortCenter =  new Vector2(Display.consoleWidth / 2, Display.consoleHeight / 2);
               
        public static MapDrawer map = new MapDrawer(@"..\..\..\Universe\Maps\Map_Test2.txt");

        static Person person1 = new Person(0, "Dude", "Homies", "NULL", '@', vievPortCenter, new Vector2(1, 8), 1);

        public static void Tick()
        {
            Console.Clear();

            Input();
            person1.Tick();

            map.Draw();
            person1.Draw(Display.textColorGreen);
            
            TextTools.WriteTextFixPos("X = " + (person1.coord.X) + " Y = " + (person1.coord.Y), TextTools.Position.MiddleCenter);
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
