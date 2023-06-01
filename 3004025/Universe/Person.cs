using System;
using System.Diagnostics;

namespace _3004025
{
    public class Person : Entity
    {
        public string? civil { get; set; }
        public string? description { get; set; }

        public char sprite { get; set; }

        public Vector2 posOnScreen { get; set; }
        public Vector2 coord { get; set; }
        public int speed { get; set; }

        public Person(int id, string? name, string? civil, string? description, char sprite, Vector2 posOnScreen, Vector2 coord, int speed)
        {
            base.id = id;
            base.name = name;
            this.civil = civil;
            this.description = description;
            this.sprite = sprite;
            this.posOnScreen = posOnScreen;
            this.coord = coord;
            this.speed = speed;

            if (coord.X >= Game.map.mapSize.X - 1) ErrorCather.ErrorMessage("Координаты по X выходят за границы карты");
            if (coord.Y >= Game.map.mapSize.Y - 1) ErrorCather.ErrorMessage("Координаты по Y выходят за границы карты");
            if (coord.X <= 0) ErrorCather.ErrorMessage("Координаты по X выходят за границы карты");
            if (coord.Y <= 0) ErrorCather.ErrorMessage("Координаты по Y выходят за границы карты");
            if (MapObject.OutOfMap.Any(x => x == Game.map.mapArray[this.coord.X, this.coord.Y]) == true || MapObject.Wall.Any(x => x == Game.map.mapArray[this.coord.X, this.coord.Y]) == true) ErrorCather.ErrorMessage("Игрок находится вне зоны карты");

            
            if (this.coord.X > Display.consoleWidth / 2)
            {
                Game.map.mapOffset.X = coord.X - Display.consoleWidth / 2;
            }
            else
                Game.map.mapOffset.X = coord.X - Display.consoleWidth / 2;
            if (this.coord.Y > Display.consoleHeight / 2)
            {
                Game.map.mapOffset.Y = coord.Y - Display.consoleHeight / 2;
            }
            else
                Game.map.mapOffset.Y = coord.Y - Display.consoleHeight / 2;
            this.speed = speed;
        }

        public void Draw(string color)
        {
            Console.SetCursorPosition(posOnScreen.X, posOnScreen.Y);
            Console.Write(color + sprite);
        }

        public void Tick()
        {
            Input();
        }

        private void Input()
        {
            switch (Display.key)
            {
                case ConsoleKey.UpArrow or ConsoleKey.W:
                    if (coord.Y > 0) 
                    {
                        if (Game.map.mapArray[coord.X, coord.Y - speed] == ' ')
                        {
                            coord.Y -= speed;
                            Game.map.mapOffset.Y -= speed;
                        }
                    }                   
                    break;
                case ConsoleKey.DownArrow or ConsoleKey.S:
                    if (coord.Y < Game.map.mapSize.Y - speed)
                    {
                        if (Game.map.mapArray[coord.X, coord.Y + speed] == ' ')
                        {
                            coord.Y += speed;
                            Game.map.mapOffset.Y += speed;
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow or ConsoleKey.A:
                    if (coord.X > 0)
                    {
                        if (Game.map.mapArray[coord.X - speed, coord.Y] == ' ')
                        {
                            coord.X -= speed;
                            Game.map.mapOffset.X -= speed;
                        }
                    }                       
                    break;
                case ConsoleKey.RightArrow or ConsoleKey.D:
                    if (coord.X < Game.map.mapSize.X - speed)
                    {
                        if (Game.map.mapArray[coord.X + speed, coord.Y] == ' ')
                        {
                            coord.X += speed;
                            Game.map.mapOffset.X += speed;
                        }
                    }                   
                    break;
            }
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write(" " + civil + " " + description);
        }
    }
}
