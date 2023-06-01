using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3004025
{
    public class Map_Test_Class : MapDrawer
    {
        public static NPC person = new NPC(13, "niko", "human", null, '@', new Vector2(13, 3), 0);

        public Map_Test_Class(string path) : base(path)
        {
            
        }

        public override void Draw()
        {
            base.Draw();
            person.Draw(Display.textColorGreen);
        }

        public override void Tick()
        {
            base.Tick();
            person.Tick();
        }
    }
}
