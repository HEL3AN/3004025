using System.Threading;

namespace _3004025.Windows
{
    public class LoginPage
    {
        string l = "Admin";
        string p = "Admin";
        public static void Tick()
        {
            TextTools.WriteTextFixPosColor("Введите логин:", TextTools.Position.MiddleCenter, Display.textColorGreen);
        }
    }
}
