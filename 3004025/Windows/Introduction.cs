using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3004025
{
    public class Introduction
    {
        public static void Tick()
        {
            TextTools.WriteTextFixPos("Этот раздел ещё не готов!", TextTools.Position.MiddleCenter);

            Thread.Sleep(2000);

            Display.ChangeWindow(WindowList.MainMenu);
        }
    }
}
