using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3004025
{
    public class Inventoty
    {
        private static List<Thing> thingList = new List<Thing>()
        {
            new Thing ("Apple", ThingCategory.None, 0),
            new Thing ("Sword", ThingCategory.Object, 0)
        };

        public static void Tick()
        {
            thingList[0].GetInfo();
        }
    }
}
