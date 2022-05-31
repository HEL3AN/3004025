using System;

namespace _3004025
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual void Tick()
        {
            throw new NotImplementedException();
        }
    }
}
