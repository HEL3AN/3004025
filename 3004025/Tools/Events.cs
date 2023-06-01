using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3004025
{
    public delegate void EventDelegate();
    public static class Events
    {
        public static event EventDelegate? playerMove = null;

        public static void InvokeEvent()
        {
            playerMove?.Invoke();
        }
    }
}
