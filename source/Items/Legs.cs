namespace VeganRPG
{
    class Legs : Item
    {
        public Legs() : base()
        {

        }

        public Legs(int level, string name, int health, int defense, bool isBase = false)
        {
            Level = level;
            Name = name;
            Health = health;
            Defense = defense;
            IsBase = isBase;
        }
    }
}
