using System;

namespace _3004025
{
    public class Entity
    {
        public int id { get; set; }
        public string? name { get; set; }

        public virtual void GetInfo()
        {
            Console.Write(id+ " " + name);
        }
    }
}
