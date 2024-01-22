namespace VeganRPG
{
    class Boots : Item
    {
        public Boots() : base()
        {

        }

        public Boots(int level, string name, int health, int defense, bool isBase = false)
        {
            Level = level;
            Name = name;
            Health = health;
            Defense = defense;
            IsBase = isBase;
        }
    }
}
