namespace VeganRPG
{
    class Armor : Item
    {
        public Armor() : base()
        {

        }

        public Armor(int level, string name, int health, int defense, bool isBase = false)
        {
            Level = level;
            Name = name;
            Health = health;
            Defense = defense;
            IsBase = isBase;
        }
    }
}
