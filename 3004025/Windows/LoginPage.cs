using System.Threading;

namespace _3004025.Windows
{
    public class LoginPage
    {
        string l = "Admin";
        string p = "Admin";

        static private string userLogin = "";

        public static void Tick()
        {

            TextTools.WriteTextFixPosColor("Введите логин:", TextTools.Position.MiddleCenter, Display.textColorGreen);

            if(Display.key != ConsoleKey.NoName)
                userLogin += Display.key.ToString();

            Console.SetCursorPosition(Console.BufferWidth / 2 - userLogin.Length / 2, Console.CursorTop + 1);

            Console.Write(userLogin);
        }
    }
}
