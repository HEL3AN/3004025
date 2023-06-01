using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3004025
{
    public class NPC : Entity
    {
        public string? civil { get; set; }
        public string? description { get; set; }

        public char sprite { get; set; }

        public Vector2 posOnScreen { get; set; }
        public Vector2 coord { get; set; }
        public int speed { get; set; }

        public NPC(int id, string? name, string? civil, string? description, char sprite, Vector2 coord, int speed)
        {
            this.id = id;
            this.name = name;
            this.civil = civil;
            this.description = description;
            this.sprite = sprite;

            this.posOnScreen = new Vector2();
            this.posOnScreen.X = coord.X + (-Game.map.mapOffset.X);
            this.posOnScreen.Y = coord.Y + (-Game.map.mapOffset.Y);

            this.coord = coord;
            this.speed = speed;

            Events.playerMove += new EventDelegate(CheckPos);
        }

        public void Draw(string color)
        {
            Console.SetCursorPosition(posOnScreen.X, posOnScreen.Y);
            Console.Write(color + sprite);
        }

        public void Tick()
        {
            
        }

        private void CheckPos()
        {
            posOnScreen.X = coord.X + (-Game.map.mapOffset.X);
            posOnScreen.Y = coord.Y + (-Game.map.mapOffset.Y);
        }
    }
}
