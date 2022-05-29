using System;

namespace _3004025
{
    public abstract class Entity
    {
        public abstract string Id { get; }
        public abstract string Name { get; }

        public virtual void Tick()
        {
            throw new NotImplementedException();
        }
    }
}
