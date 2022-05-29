namespace _3004025
{
    class Thing
    {
        public Thing(string Name, ThingCategory Category, bool UseHitPoints, int HitPoints)
        {
            if (!UseHitPoints)
                ErrorCather.ErrorMessage($"Объект {Name} имеет значение HitPoints, но UseHitPoints = false");

            name = Name;
            category = Category;    
            useHitPoints = UseHitPoints;
            hitPoints = HitPoints;
        }
        public Thing(string Name, ThingCategory Category, int HitPoints)
        {
            name = Name;
            category = Category;
            hitPoints = HitPoints;
        }
        public Thing(string Name, ThingCategory Category, bool UseHitPoints)
        {
            if (UseHitPoints)
                ErrorCather.ErrorMessage($"Данная реализация объекта {Name} не поддерживает значение UseHitPoints = true");               

            name = Name;
            category = Category;
            useHitPoints = UseHitPoints;
        }

        public string name = "";

        public ThingCategory category;

        public bool useHitPoints = true;

        public int hitPoints = -1;

        public void GetInfo()
        {
            Console.WriteLine("Name -> " + name);
            Console.WriteLine("Category -> " + category);
            Console.WriteLine("UseHitPoints is " + useHitPoints);
            Console.WriteLine("HitPoints = " + hitPoints);
        } 
    }
}
