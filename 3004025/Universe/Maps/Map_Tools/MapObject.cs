using System;
using System.Collections;

namespace _3004025
{
    public class MapObject
    {
        public static char[] Empty = new char[] { ' ' };
        public static char[] Wall = new char[] { '#', '-', '|' };
        public static char[] Decor = new char[] { '.' };
        public static char[] OutOfMap = new char[] { '?' };
        public static char[] Active = new char[] { };
    }
}
